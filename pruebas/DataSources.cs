using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebas
{
    public class ReportRequest
    {
        public string path_report { get; set; }
        public string name_datasource { get; set; }
        public dynamic  metadata { get;set;}


    }
}