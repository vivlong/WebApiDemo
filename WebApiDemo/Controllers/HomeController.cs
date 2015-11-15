using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebApiDemo.Controllers
{
    public class HomeController : Controller
    {
        private static string AssemblyFileVersion()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            else
            {
                return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            }
        }
        private static string strVersion = AssemblyFileVersion();
        private static string strNetVersion = Environment.Version.ToString();
        private static string strServiceIIS = System.Web.HttpContext.Current.Request.ServerVariables["SERVER_SOFTWARE"];
        private static string strServiceTime = DateTime.Now.ToString();

        public ActionResult Index()
        {
            ViewBag.Title = "Index";
            ViewBag.Version = strVersion;
            ViewBag.NetVersion = strNetVersion;
            ViewBag.ServiceIIS = strServiceIIS;
            return View();
        }
    }
}
