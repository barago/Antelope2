using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Antelope.Extensions
{
    /// <summary>
    /// Extensions pour les dictionnaires.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Convertit un dictionnaire en objet.
        /// </summary>
        /// <typeparam name="T">Objet vers lequel convertir.</typeparam>
        /// <param name="source">Dictionnaire.</param>
        /// <returns>Objet.</returns>
        public static T ToObject<T>(this IDictionary<string, string> source) where T : class, new()
        {
            try
            {
                T someObject = new T();
                Type someObjectType = someObject.GetType();

                var propertyNames = someObjectType.GetProperties().Select(x => x.Name).ToArray();

                foreach (KeyValuePair<string, string> item in source)
                {
                    if (propertyNames.Contains(item.Key))
                    {
                        someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
                    }
                }

                return someObject;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}