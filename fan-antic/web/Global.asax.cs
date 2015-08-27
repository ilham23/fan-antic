using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using log4net;

namespace web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// logger
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();

            System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();

            currentProcess.Refresh();
            _logger.Info("Application_Start start");
            _logger.Info("物理メモリ使用量: " + String.Format("{0:#,0} KB", currentProcess.WorkingSet64 / 1024));
            _logger.Info("仮想メモリ使用量: " + String.Format("{0:#,0} KB", currentProcess.VirtualMemorySize64 / 1024));

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            _logger.Info("Application_Start end");
            _logger.Info("物理メモリ使用量: " + String.Format("{0:#,0} KB", currentProcess.WorkingSet64 / 1024));
            _logger.Info("仮想メモリ使用量: " + String.Format("{0:#,0} KB", currentProcess.VirtualMemorySize64 / 1024));
        }
    }
}