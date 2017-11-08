using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Antelope.Controllers.HSE
{
    public class PhantomController : Controller
    {

        public ActionResult Index()
        {

            

            return View("/Views/HSE/Phantom/Index.cshtml");
        }


        public ActionResult Index2(string param1, string param2, string param3)
        {



            return View("/Views/HSE/Phantom/Index2.cshtml");
        }
        
        
        //
        // GET: /Phantom/
        public ActionResult Print(int? id)
        {
            string serverPath = HttpContext.Server.MapPath("~/Executables/");
            string filename = DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".pdf";

            //string commandParameters = "cd " + serverPath + @" & phantomjs rasterize.js http://localhost:50336/ListProjet/ListeProjet" + id.ToString() + " " + filename + @" ""A4""";
            string commandParameters = "cd " + serverPath + @" & phantomjs rasterize.js http://localhost:50336/Panier/Rasterize?selection=" + "Nombre" + " " + filename + @" ""A4""";
            //string commandParameters = "cd " + serverPath + @" & phantomjs rasterize.js http://www.hardware.fr" + " " + filename + @" ""A4""";

            new Thread(new ParameterizedThreadStart(x =>
            {
                ExecuteCommand(commandParameters);
            })).Start();

            var filePath = Path.Combine(HttpContext.Server.MapPath("~/Executables/"), filename);

            var stream = new MemoryStream();
            byte[] bytes = DoWhile(filePath);

            return File(bytes, "application/pdf", filename);
        }

        private void ExecuteCommand(string Command)
        {
            try
            {
                ProcessStartInfo ProcessInfo;
                Process Process;

                ProcessInfo = new ProcessStartInfo("cmd.exe", "/K " + Command);
                ProcessInfo.CreateNoWindow = true;
                ProcessInfo.UseShellExecute = false;

                Process = Process.Start(ProcessInfo);
            }
            catch { }
        }


        public ViewResult FileToPDF(int? id)
        {
            //var viewModel = file.Get(id);
            return View("/Views/HSE/FicheSecurite/Phantom.cshtml");
        }


        private byte[] DoWhile(string filePath)
        {
            byte[] bytes = new byte[0];
            bool fail = true;

            while (fail)
            {
                try
                {
                    using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        bytes = new byte[file.Length];
                        file.Read(bytes, 0, (int)file.Length);
                    }

                    fail = false;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            System.IO.File.Delete(filePath);
            return bytes;
        }

    }

}