using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pruebas
{
    public class ReportResponse
    {
        public bool procesoExitoso { get; set; } 
        public string mensaje {    get; set; }
        public byte[] data { get; set; }
        public Exception ex { get; set; }

    }
}