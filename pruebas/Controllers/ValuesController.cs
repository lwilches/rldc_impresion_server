using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pruebas.Controllers
{
    public class ReporteRdlcController : ApiController
    {
       

        // POST api/values
        public ReportResponse Post([FromBody] ReportRequest  reporte )
        {
            ReportResponse _response = new ReportResponse();

            using (var  _reporte = new Microsoft.Reporting.WinForms.LocalReport())
            {
                _reporte.ReportPath = reporte.path_report;
                _reporte.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(reporte.name_datasource, reporte.metadata));                
                byte[] _fileByteSinPassword=null ;
                try
                {
                    Microsoft.Reporting.WinForms.Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;
                    try
                    {
                        _response.data = _reporte.Render(
                        "PDF", null, Microsoft.Reporting.WinForms.PageCountMode.Actual, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    }
                    catch (System.Exception e)
                    {
                        //_logger.RegistrarEventoErrorLog(e);
                        throw e;
                    }
                    finally
                    {
                        _reporte.DataSources.Clear();
                        _reporte.Dispose();
                        
                    }

                }
                catch (System.Exception e)
                {
                    _response.ex = e;
                    //SetError(e.RecuperarExceptionInicial().Message, "ER002");
                    //throw e;


                }
            }
            return _response;
        }

      
    }
}
