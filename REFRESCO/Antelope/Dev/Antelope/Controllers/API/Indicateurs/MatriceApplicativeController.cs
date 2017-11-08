using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;




namespace Antelope.Controllers.API.Indicateurs
{
    public class MatriceApplicativeController : ApiController
    {



        public HttpResponseMessage GetApplication()
        {

            string ConnexionString = System.Configuration.ConfigurationManager.ConnectionStrings["GLPI"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(ConnexionString);

            MySqlCommand cmd;
            MySqlDataReader reader;

            cmd = connection.CreateCommand();

            //cmd.CommandText =
            //    "SELECT " +
            //    "glpi_softwares.name" +
            //    "FROM glpi_softwares " +
            //    "WHERE glpi_softwares.is_deleted = '0' " +
            //    "AND glpi_softwares.is_template = '0' ";

            //connection.Open();
            //reader = cmd.ExecuteReader();

            //List<Dictionary<string, Dictionary<string,string>>> AllApplication = new List<Dictionary<string, Dictionary<string,string>>>();


            cmd.CommandText =
                "SELECT " +
                "glpi_softwares.id, glpi_softwares.name, glpi_computers.id, glpi_computers.name, glpi_softwareversions.name " +
                "FROM glpi_softwares " +
                //"LEFT JOIN glpi_softwarelicenses ON glpi_softwares.id = glpi_softwarelicenses.softwares_id "+
                "LEFT JOIN glpi_softwareversions ON glpi_softwares.id = glpi_softwareversions.softwares_id " +
                "LEFT JOIN glpi_computers_softwareversions ON glpi_softwareversions.id = glpi_computers_softwareversions.softwareversions_id " +
                "LEFT JOIN glpi_computers ON glpi_computers_softwareversions.computers_id = glpi_computers.id " +
                "WHERE glpi_softwares.is_deleted = '0' " +
                //"AND (glpi_softwarelicenses.expire IS NULL OR glpi_softwarelicenses.expire > NOW() ) " +
                "AND glpi_softwares.is_template = '0' " +
                "AND glpi_computers.is_deleted = '0' " +
                "AND glpi_computers.is_template = '0' "+
                //"AND glpi_softwares.name = 'Qubes'" +
                "ORDER BY glpi_softwares.name";

                //"GROUP BY glpi_softwares.id ";
            

            connection.Open();
            reader = cmd.ExecuteReader();


            List<Dictionary<string, string>> AllApplication = new List<Dictionary<string, string>>();
            //Dictionary<string, string> AllApplication = new Dictionary<string, string>();
            
            while (reader.Read())
            {


                Dictionary<string, string> application = new Dictionary<string, string>() { { "softwareId", reader.GetString(0) }, { "softwareName", reader.GetString(1) }, { "computerId", reader.GetString(2) }, { "computerName", reader.GetString(3) }, { "versionName", reader.GetString(4) } };
                //AllApplication.Add(new Dictionary<string, string>(){"applicationName", reader.GetString(0)});
                
                AllApplication.Add(application);
            }
            connection.Close();

            Object Response = new { AllApplication = AllApplication};

            return Request.CreateResponse(HttpStatusCode.OK, Response);

        }




    }
}