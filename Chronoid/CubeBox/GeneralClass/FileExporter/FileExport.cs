using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GeneralClass.FileExporter
{
    public static class FileExport
    {
        #region CSV
        public static bool CSV(string data, HttpResponseBase Response) {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(data);
            Response.Flush();
            Response.End();
            return true;
        }


        #endregion

    }
}
