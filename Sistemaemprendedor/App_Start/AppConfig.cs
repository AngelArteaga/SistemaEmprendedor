using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Sistemaemprendedor.App_Start
{
    public static class AppConfig
    {
        public static string SE_stg { get { return ConfigurationManager.AppSettings["SE_stg"]; } }
        public static string SE_stgContainer { get { return ConfigurationManager.AppSettings["SE_stgContainer"]; } }
        public static string SEBlobUrl { get { return ConfigurationManager.AppSettings["SEBlobUrl"]; } }
    }
}