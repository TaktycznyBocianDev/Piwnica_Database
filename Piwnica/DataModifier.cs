using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class DataModifier
    {

        private readonly IDbConnection _connection;


        public delegate void ModAction();
        public static event ModAction OnModified;


        public DataModifier(IDbConnection connection)
        {
            _connection = connection;
        }


        public void Modify(ContenerModel contener, string newName)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = "UPDATE Contener SET name = @newName WHERE id = @id ";
                    _connection.Execute(query, new { newName, id = contener.id }, transaction: transaction);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnModified(); }
            }
        }

        public void Modify(ShelfModel shelf, string newName)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = "UPDATE Shelf SET name = @newName WHERE id = @id ";
                    _connection.Execute(query, new { newName, id = shelf.id }, transaction: transaction);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnModified(); }
            }
        }

        public void Modify(ItemModel item, string newName)
        {
            _connection.Open();

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = "UPDATE Item SET name = @newName WHERE id = @id ";
                    _connection.Execute(query, new { newName, id = item.id }, transaction: transaction);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
                finally { _connection.Close(); OnModified(); }
            }
        }
    }
}
