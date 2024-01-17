using Dapper;
using Piwnica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{

    //Target: To get information from DataBase (PiwnicaDB.db)
    public class DataReader
    {
        //new SQLiteConnection(ConnectionManager.LoadConnectionString()
        private readonly IDbConnection _connection;

        public DataReader(IDbConnection connection)
        {
            _connection = connection;
        }

        public List<ContenerModel> LoadAllConteners()
        {
            return _connection.Query<ContenerModel>("SELECT * FROM Contener", new DynamicParameters()).ToList();
        }

        public ContenerModel LoadConcretContener(int contenerId)
        {
            string query = "SELECT * FROM Contener WHERE id = @ContenerId";
            return _connection.QueryFirstOrDefault<ContenerModel>(query, new { ContenerId = contenerId });
        }

        public List<ShelfModel> LoadAllShelfsByContener(int contenerId)
        {

            string query = "SELECT * FROM Shelf WHERE ContenerId = @ContenerId";
            return _connection.Query<ShelfModel>(query, new { ContenerId = contenerId }).ToList();
        }

        public ShelfModel LoadConcreteShelf(int shelfId)
        {
            string query = "SELECT * FROM Shelf WHERE id = @ShelfId";
            return _connection.QueryFirstOrDefault<ShelfModel>(query, new { ShelfId = shelfId });
        }

        public List<ItemModel> LoadItemsByShelf(int shelfId)
        {
            string query = "SELECT * FROM Item WHERE idShelf = @ShelfId";
            return _connection.Query<ItemModel>(query, new { ShelfId = shelfId }).ToList();
        }

        public ItemModel LoadConcreteItem(int itemId)
        {
            string query = "SELECT * FROM Item WHERE id = @ItemId";
            return _connection.QueryFirstOrDefault<ItemModel>(query, new { ItemId = itemId });
        }

    }
}

