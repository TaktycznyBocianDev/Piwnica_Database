using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class DataReader
    {

        public static List<ContenerModel> LoadConteners()
        {
            using (IDbConnection con = new SQLiteConnection(ConnectionManager.LoadConnectionString()))
            {
                return con.Query<ContenerModel>("SELECT * FROM Contener", new DynamicParameters()).ToList(); ;

            }

        }

        public static List<ShelfModel> LoadShelfs(int contenerId)
        {
            using (IDbConnection con = new SQLiteConnection(ConnectionManager.LoadConnectionString()))
            {


                string query = "SELECT * FROM Shelf WHERE ContenerId = @ContenerId";


                var parameters = new DynamicParameters();
                parameters.Add("@ContenerId", contenerId);

                var result = con.Query<ShelfModel>(query, parameters);
                return result.ToList();

            }
        }

        

    }
}
