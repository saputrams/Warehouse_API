using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace Warehouse_API.Helper
{
    public class Connection
    {
        string connection = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public IEnumerable<T> Get<T>(string sqlPath, object param = null)
        {
            IDbConnection db = new SqlConnection(connection);

            return db.Query<T>(GetText(sqlPath),param : param);
        }

        public string GetText(string text)
        {
            string sqlPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Sql/"),text)  + ".sql";
            string sql = "";

            sql = File.ReadAllText(sqlPath);


            return sql;
        }

    }
}