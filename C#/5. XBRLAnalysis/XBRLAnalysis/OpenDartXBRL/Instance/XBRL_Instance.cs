using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDartXBRL.Instance
{
    public class XBRL_Instance : ODXBRL
    {

        public XBRL_Instance() { }


        public override DataSet MakeDataSet()
        {
            #pragma warning disable 8602
            DataSet ds = new DataSet();

            ds.Tables.Add("link");
            ds.Tables.Add("context");
            ds.Tables.Add("unit");
            ds.Tables.Add("dart-gcd");
            ds.Tables.Add("dart");
            ds.Tables.Add("entity00126380");
            ds.Tables.Add("ifrs-full");

            // Table["link"]
            ds.Tables["link"].Columns.Add("link#xlink:type", typeof(string));
            ds.Tables["link"].Columns.Add("link#xlink:href", typeof(string));

            // Table["context"]
            ds.Tables["context"].Columns.Add("id", typeof(string));
            ds.Tables["context"].Columns.Add("entity_identifier", typeof(string));
            ds.Tables["context"].Columns.Add("period_startDate", typeof(string));
            ds.Tables["context"].Columns.Add("period_endDate", typeof(string));
            ds.Tables["context"].Columns.Add("period_instant", typeof(string));
            ds.Tables["context"].Columns.Add("dimension_id1", typeof(string));
            ds.Tables["context"].Columns.Add("dimension_value1", typeof(string));
            ds.Tables["context"].Columns.Add("dimension_id2", typeof(string));
            ds.Tables["context"].Columns.Add("dimension_value2", typeof(string));

            // Table["unit"]
            ds.Tables["unit"].Columns.Add("unit_id", typeof(string));
            ds.Tables["unit"].Columns.Add("unit_value", typeof(string));

            // Table["dart-gcd"]
            ds.Tables["dart-gcd"].Columns.Add("namespace", typeof(string));
            ds.Tables["dart-gcd"].Columns.Add("contextRef", typeof(string));
            ds.Tables["dart-gcd"].Columns.Add("xml:lang", typeof(string));
            ds.Tables["dart-gcd"].Columns.Add("decimals", typeof(string));
            ds.Tables["dart-gcd"].Columns.Add("unitRef", typeof(string));
            ds.Tables["dart-gcd"].Columns.Add("value", typeof(string));

            // Table["dart"]
            ds.Tables["dart"].Columns.Add("namespace", typeof(string));
            ds.Tables["dart"].Columns.Add("contextRef", typeof(string));
            ds.Tables["dart"].Columns.Add("decimals", typeof(string));
            ds.Tables["dart"].Columns.Add("unitRef", typeof(string));
            ds.Tables["dart"].Columns.Add("value", typeof(double));

            // Table["entity00126380"]
            ds.Tables["entity00126380"].Columns.Add("namespace", typeof(string));
            ds.Tables["entity00126380"].Columns.Add("contextRef", typeof(string));
            ds.Tables["entity00126380"].Columns.Add("decimals", typeof(string));
            ds.Tables["entity00126380"].Columns.Add("unitRef", typeof(string));
            ds.Tables["entity00126380"].Columns.Add("value", typeof(double));

            // Table["ifrs-full"]
            ds.Tables["ifrs-full"].Columns.Add("namespace", typeof(string));
            ds.Tables["ifrs-full"].Columns.Add("contextRef", typeof(string));
            ds.Tables["ifrs-full"].Columns.Add("decimals", typeof(string));
            ds.Tables["ifrs-full"].Columns.Add("unitRef", typeof(string));
            ds.Tables["ifrs-full"].Columns.Add("value", typeof(double));

            return ds;
        }
    }
}
