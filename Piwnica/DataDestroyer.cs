using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Piwnica
{
    public class DataDestroyer
    {

        private readonly IDbConnection _connection;


        public delegate void DeleteAction();
        public static event DeleteAction OnDeleted;


        public DataDestroyer(IDbConnection connection)
        {
            _connection = connection;
        }


        public void Delete(ItemModel item)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = "DELETE FROM Item WHERE id = @ItemId";
                    _connection.Execute(query, new { ItemId = item.id }, transaction: transaction);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnDeleted(); }
            }
        }

        public void Delete(ShelfModel shelf)
        {

            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = "DELETE FROM Item WHERE idShelf = @ShelfId; DELETE FROM Shelf WHERE id = @id";
                    _connection.Execute(query, new { ShelfId = shelf.id, id = shelf.id }, transaction: transaction);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnDeleted(); }
            }
        }

        public void Delete(ContenerModel contener)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {

                    string deleteItemsQuery = "DELETE FROM Item WHERE idContener = @idContener";
                    _connection.Execute(deleteItemsQuery, new { idContener = contener.id }, transaction: transaction);

                    string deleteShelvesQuery = "DELETE FROM Shelf WHERE ContenerId = @ContenerId";
                    _connection.Execute(deleteShelvesQuery, new { ContenerId = contener.id }, transaction: transaction);

                    string deleteContenerQuery = "DELETE FROM Contener WHERE id = @id";
                    _connection.Execute(deleteContenerQuery, new { id = contener.id }, transaction: transaction);

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnDeleted(); }
            }
        }

    }
}
