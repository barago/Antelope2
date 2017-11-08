using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using MySql.Data.MySqlClient.Properties;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Antelope.Domain.Models;
using PagedList;
using Antelope.Infrastructure.EntityFramework;

namespace Antelope.Controllers.IndicateurSI
{
    public class SauvegardeController : Controller
    {
        private AntelopeEntities db = new AntelopeEntities();
        //
        // GET: Sauvegarde
        public ActionResult Sauvegarde()
        {
            return View("~/Views/IndicateurSI/IndicateurSISupport/Sauvegarde.cshtml");
        }

        public int SaveData(string tabData, double date)
        {
            // tabData : chaine formatée comme suit  =>  string ~ string ~ string ~ string | string ~ string ~ string ~ string | ...

            // Tableau de chaines entre les '|'  =>  [string ~ string ~ string ~ string], [string ~ string ~ string ~ string], [...]
            string[] splitTabData = tabData.Split('|');

            // Tableau de tableau de chaines entre les '~'  =>  [[string],[string],[string],[string]], [[string],[string],[string],[string]], [...]
            string[][] tableauData = new string [splitTabData.Count()][];
            
            for (int i = 0; i < splitTabData.Count(); i++)
            {
                tableauData[i] = splitTabData[i].Split('~');
            }

            var sauvegardes =   from s in db.Sauvegardes
                                where s.Date == date
                                select s;

            for (int i = 0; i < tableauData.Count(); i++)
            {
                Sauvegarde SauvegardeSI = new Sauvegarde()
                {
                    Site = tableauData[i][0],
                    Date = date,
                    Volume = float.Parse(tableauData[i][1]),
                    Taux = float.Parse(tableauData[i][2]),
                    Duree = int.Parse(tableauData[i][3])
                };
                db.Sauvegardes.Add(SauvegardeSI);
            }

            db.SaveChanges();
            
            return 0;
        }

        public int EditData(string tabData, string date)
        {
            // tabData : chaine formatée comme suit  =>  string ~ string ~ string ~ string | string ~ string ~ string ~ string | ...

            // Tableau de chaines entre les '|'  =>  [string ~ string ~ string ~ string], [string ~ string ~ string ~ string], [...]
            string[] splitTabData = tabData.Split('|');

            // Tableau de tableau de chaines entre les '~'  =>  [[string],[string],[string],[string]], [[string],[string],[string],[string]], [...]
            string[][] tableauData = new string[splitTabData.Count()][];

            for (int i = 0; i < splitTabData.Count(); i++)
            {
                tableauData[i] = splitTabData[i].Split('~');
            }

            string[] dateSplit = date.Split('/');

            double dateRecupDebut = (new DateTime(int.Parse(dateSplit[1]), int.Parse(dateSplit[0]), 1)).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
            double dateRecupFin = (new DateTime(int.Parse(dateSplit[1]), int.Parse(dateSplit[0]), DateTime.DaysInMonth(int.Parse(dateSplit[1]), int.Parse(dateSplit[0])))).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            var sauvegardes = from s in db.Sauvegardes
                              where s.Date >= dateRecupDebut && s.Date <= dateRecupFin
                              select s;

            sauvegardes = sauvegardes.OrderBy(s => s.SauvegardeID);

            int IDSite = 0;
            foreach (var elem in sauvegardes)
            {
                elem.Volume = float.Parse(tableauData[IDSite][1]);
                elem.Taux = float.Parse(tableauData[IDSite][2]);
                elem.Duree = int.Parse(tableauData[IDSite][3]);
                IDSite++;
            }

            db.SaveChanges();


            return 0;
        }

        public ActionResult Draw()
        {
            string[] moisLettres = new string[] {"Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre"};
            DateTime date = DateTime.Now.AddMonths(-12);

            string JsonTabCat = "\"TabCat\":[";

            string JsonTabVolume = "\"Volume\":[";
            string JsonTabVolumeSites = "\"VolumeSite\":[";
            string JsonTabVolumeMGS = "[";
            string JsonTabVolumeLQN = "[";
            string JsonTabVolumeNSG = "[";
            string JsonTabVolumeSTA = "[";

            string JsonTabTaux = "\"Taux\":[";
            string JsonTabTauxSites = "\"TauxSite\":[";
            string JsonTabTauxLQN = "[";
            string JsonTabTauxNSG = "[";
            string JsonTabTauxSTA = "[";
            string JsonTabTauxMGS = "[";

            string JsonTabDureeSites = "\"DureeSite\":[";
            string JsonTabDureeLQN = "[";
            string JsonTabDureeNSG = "[";
            string JsonTabDureeSTA = "[";
            string JsonTabDureeMGS = "[";

            for (int i = 0; i < 12; i++)
            {
                double dateRecupDebut = (new DateTime(date.Year, date.Month, 1)).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                double dateRecupFin = (new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month))).Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

                var sauvegardes = from s in db.Sauvegardes
                                  where s.Date >= dateRecupDebut && s.Date <= dateRecupFin
                                  select s;

                sauvegardes = sauvegardes.OrderBy(s => s.SauvegardeID);

                List<Sauvegarde> listeSauvegarde = sauvegardes.ToList();
                

                JsonTabCat += "\"" + moisLettres[date.Month - 1] + " " + date.Year + "\",";

                if (listeSauvegarde.Count > 0){

                    JsonTabVolumeMGS += (listeSauvegarde[0].Volume).ToString().Replace(',','.') + ",";
                    JsonTabVolumeLQN += (listeSauvegarde[1].Volume).ToString().Replace(',','.') + ",";
                    JsonTabVolumeNSG += (listeSauvegarde[2].Volume).ToString().Replace(',','.') + ",";
                    JsonTabVolumeSTA += (listeSauvegarde[3].Volume).ToString().Replace(',','.') + ",";
                    JsonTabVolume += (listeSauvegarde[0].Volume +  listeSauvegarde[1].Volume + listeSauvegarde[2].Volume + listeSauvegarde[3].Volume).ToString().Replace(',','.') + ",";

                    JsonTabTauxMGS += (listeSauvegarde[0].Taux).ToString().Replace(',', '.') + ",";
                    JsonTabTauxLQN += (listeSauvegarde[1].Taux).ToString().Replace(',', '.') + ",";
                    JsonTabTauxNSG += (listeSauvegarde[2].Taux).ToString().Replace(',', '.') + ",";
                    JsonTabTauxSTA += (listeSauvegarde[3].Taux).ToString().Replace(',', '.') + ",";
                    JsonTabTaux += ((listeSauvegarde[0].Taux + listeSauvegarde[1].Taux + listeSauvegarde[2].Taux + listeSauvegarde[3].Taux) / 4).ToString().Replace(',', '.') + ",";

                    JsonTabDureeMGS += (listeSauvegarde[0].Duree).ToString().Replace(',', '.') + ",";
                    JsonTabDureeLQN += (listeSauvegarde[1].Duree).ToString().Replace(',', '.') + ",";
                    JsonTabDureeNSG += (listeSauvegarde[2].Duree).ToString().Replace(',', '.') + ",";
                    JsonTabDureeSTA += (listeSauvegarde[3].Duree).ToString().Replace(',', '.') + ",";
                }
                else
                {
                    JsonTabVolumeMGS += "0,";
                    JsonTabVolumeLQN += "0,";
                    JsonTabVolumeNSG += "0,";
                    JsonTabVolumeSTA += "0,";
                    JsonTabVolume += "0,";

                    JsonTabTauxMGS += "null,";
                    JsonTabTauxLQN += "null,";
                    JsonTabTauxNSG += "null,";
                    JsonTabTauxSTA += "null,";
                    JsonTabTaux += "null,";

                    JsonTabDureeMGS += "null,";
                    JsonTabDureeLQN += "null,";
                    JsonTabDureeNSG += "null,";
                    JsonTabDureeSTA += "null,";
                }
                    

                date = date.AddMonths(1);
            }

            // Suppression de la dernière virgule

            // Catégories (dates)
            JsonTabCat = JsonTabCat.Substring(0, JsonTabCat.Length - 1);
            JsonTabVolume = JsonTabVolume.Substring(0, JsonTabVolume.Length - 1);
            JsonTabVolumeMGS = JsonTabVolumeMGS.Substring(0, JsonTabVolumeMGS.Length - 1);
            JsonTabVolumeLQN = JsonTabVolumeLQN.Substring(0, JsonTabVolumeLQN.Length - 1);
            JsonTabVolumeNSG = JsonTabVolumeNSG.Substring(0, JsonTabVolumeNSG.Length - 1);
            JsonTabVolumeSTA = JsonTabVolumeSTA.Substring(0, JsonTabVolumeSTA.Length - 1);

            // Taux
            JsonTabTaux = JsonTabTaux.Substring(0, JsonTabTaux.Length - 1);
            JsonTabTauxMGS = JsonTabTauxMGS.Substring(0, JsonTabTauxMGS.Length - 1);
            JsonTabTauxLQN = JsonTabTauxLQN.Substring(0, JsonTabTauxLQN.Length - 1);
            JsonTabTauxNSG = JsonTabTauxNSG.Substring(0, JsonTabTauxNSG.Length - 1);
            JsonTabTauxSTA = JsonTabTauxSTA.Substring(0, JsonTabTauxSTA.Length - 1);

            // Durées
            JsonTabDureeMGS = JsonTabDureeMGS.Substring(0, JsonTabDureeMGS.Length - 1);
            JsonTabDureeLQN = JsonTabDureeLQN.Substring(0, JsonTabDureeLQN.Length - 1);
            JsonTabDureeNSG = JsonTabDureeNSG.Substring(0, JsonTabDureeNSG.Length - 1);
            JsonTabDureeSTA = JsonTabDureeSTA.Substring(0, JsonTabDureeSTA.Length - 1);

            // Ajout caractère de fin de tableau

            // Catégories (dates)
            JsonTabCat += "]";
            JsonTabVolume += "]";
            JsonTabVolumeMGS += "]";
            JsonTabVolumeLQN += "]";
            JsonTabVolumeNSG += "]";
            JsonTabVolumeSTA += "]";

            // Taux
            JsonTabTaux += "]";
            JsonTabTauxMGS += "]";
            JsonTabTauxLQN += "]";
            JsonTabTauxNSG += "]";
            JsonTabTauxSTA += "]";

            // Durées
            JsonTabDureeMGS += "]";
            JsonTabDureeLQN += "]";
            JsonTabDureeNSG += "]";
            JsonTabDureeSTA += "]";

            JsonTabVolumeSites += JsonTabVolumeMGS + "," + JsonTabVolumeLQN + "," + JsonTabVolumeNSG + "," + JsonTabVolumeSTA + "]";
            JsonTabTauxSites += JsonTabTauxMGS + "," + JsonTabTauxLQN + "," + JsonTabTauxNSG + "," + JsonTabTauxSTA + "]";
            JsonTabDureeSites += JsonTabDureeMGS + "," + JsonTabDureeLQN + "," + JsonTabDureeNSG + "," + JsonTabDureeSTA + "]";

            string JsonTotal = "{" + JsonTabCat + "," + JsonTabVolume + "," + JsonTabVolumeSites + "," + JsonTabTaux + ","+ JsonTabTauxSites + "," + JsonTabDureeSites + "}";

            return Json(JsonTotal);
        }

    }
}