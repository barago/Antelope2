using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http; 
using System.Text.RegularExpressions;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

using Antelope.Constants;
using Antelope.Models;
 

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
 

namespace Antelope.Binders
{
    /// <summary>
    /// Model binder pour les paramètres spécifique à Datatable.
    /// </summary>
    public class JsonDatatableBinder : IModelBinder
    {
        /// <summary>Binds the model to a value by using the specified controller context and binding context.</summary>
        /// <returns>true if model binding is successful; otherwise, false.</returns>
        /// <param name="actionContext">The action context.</param>
        /// <param name="bindingContext">The binding context.</param>
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            try
            {
                var dictionary = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                var json = JsonConvert.SerializeObject(Unflatten(dictionary));
                var result = JsonConvert.DeserializeObject(json, bindingContext.ModelType);
                bindingContext.Model = result;

                var jsonDatatable = result as JsonDatatable;
                if (jsonDatatable == null)
                {
                    return true;
                    //throw new Exception("Erreur dans le model binder JsonDatatable");
                }

                if (jsonDatatable.Draw > 1)
                {
                    actionContext.Request.Properties[Cookies.DATATABLE_LENGTH] = jsonDatatable.Length;
                }
                else
                {
                    var cookie = actionContext.Request.Headers.GetCookies(Cookies.DATATABLE_LENGTH).FirstOrDefault();
                    if (cookie != null)
                    {
                        jsonDatatable.Length = int.Parse(cookie[Cookies.DATATABLE_LENGTH].Value);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Unflatten un dictionnaire en json.
        /// </summary>
        /// <param name="keyValues">Dictionnaire de valeurs.</param>
        /// <returns>Jobject.</returns>
        public static JObject Unflatten(IDictionary<string, string> keyValues)
        {
            JContainer result = null;
            JsonMergeSettings setting = new JsonMergeSettings();
            setting.MergeArrayHandling = MergeArrayHandling.Merge;
            foreach (var pathValue in keyValues)
            {
                if (result == null)
                {
                    result = UnflatenSingle(pathValue);
                }
                else
                {
                    result.Merge(UnflatenSingle(pathValue), setting);
                }
            }
            return result as JObject;
        }

        /// <summary>
        /// Unflatten un coupe clé, valeur.
        /// </summary>
        /// <param name="keyValue">Clé, valeur.</param>
        /// <returns>Retourne un containeur Json.</returns>
        private static JContainer UnflatenSingle(KeyValuePair<string, string> keyValue)
        {
            string path = keyValue.Key;
            string value = keyValue.Value;
            var pathSegments = SplitPath(path);

            JContainer lastItem = null;
            //build from leaf to root
            foreach (var pathSegment in pathSegments.Reverse())
            {
                var type = GetJSONType(pathSegment);
                switch (type)
                {
                    case JSONType.OBJECT:
                        var obj = new JObject();
                        if (null == lastItem)
                        {
                            obj.Add(pathSegment, value);
                        }
                        else
                        {
                            obj.Add(pathSegment, lastItem);
                        }
                        lastItem = obj;
                        break;
                    case JSONType.ARRAY:
                        var array = new JArray();
                        int index = GetArrayIndex(pathSegment);
                        array = FillEmpty(array, index);
                        if (lastItem == null)
                        {
                            array[index] = value;
                        }
                        else
                        {
                            array[index] = lastItem;
                        }
                        lastItem = array;
                        break;
                }
            }
            return lastItem;
        }

        /// <summary>
        /// Désaplatit un chemin.
        /// </summary>
        /// <param name="path">Chemin ou clé.</param>
        /// <returns>Liste.</returns>
        public static IList<string> SplitPath(string path)
        {
            IList<string> result = new List<string>();
            Regex reg = new Regex(@"(?!\.)([^. ^\[\]]+)|(?!\[)(\d+)(?=\])");
            foreach (Match match in reg.Matches(path))
            {
                result.Add(match.Value);
            }
            return result;
        }

        private static JArray FillEmpty(JArray array, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                array.Add(null);
            }
            return array;
        }

        /// <summary>
        /// Type Json.
        /// </summary>
        private enum JSONType
        {
            /// <summary>
            /// Objet.
            /// </summary>
            OBJECT,
            /// <summary>
            /// Tableau.
            /// </summary>
            ARRAY
        }

        /// <summary>
        /// Obtient le type Json à partir de la clé.
        /// </summary>
        /// <param name="pathSegment">Clé.</param>
        /// <returns>Retourne le type Json.</returns>
        private static JSONType GetJSONType(string pathSegment)
        {
            int x;
            return int.TryParse(pathSegment, out x) ? JSONType.ARRAY : JSONType.OBJECT;
        }

        /// <summary>
        /// Obtient l'index du tableau à partir de la clé.
        /// </summary>
        /// <param name="pathSegment">Clé.</param>
        /// <returns>Index.</returns>
        private static int GetArrayIndex(string pathSegment)
        {
            int result;
            if (int.TryParse(pathSegment, out result))
            {
                return result;
            }
            throw new Exception("Unable to parse array index: " + pathSegment);
        }
    }

}
