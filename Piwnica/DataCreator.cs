using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Piwnica
{
    public class DataCreator 
    {

        public delegate void AddedAction();
        public static event AddedAction OnAdded;


        private readonly IDbConnection _connection;

        public DataCreator(IDbConnection connection)
        {
            _connection = connection;
        }




        public void Create(ContenerModel contener)
        {
            try
            {
                _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    string query = "INSERT INTO Contener (name) VALUES (@name);";
                    _connection.Execute(query, new { name = contener.name }, transaction: transaction);

                    // Commit the transaction to make the changes permanent
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and optionally roll back the transaction
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                // Close the connection outside the try-catch block
                _connection.Close();
                OnAdded();
            }
        }

        public void Create(ShelfModel shelf)
        {
            try
            {
                _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    string query = "INSERT INTO Shelf(ContenerId, name) VALUES (@ContenerId, @name);";
                    _connection.Execute(query, new { ContenerId = shelf.idContener, name = shelf.name }, transaction: transaction);

                    // Commit the transaction to make the changes permanent
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and optionally roll back the transaction
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                // Close the connection outside the try-catch block
                _connection.Close();
                OnAdded();
            }
        }

        public void Create(ItemModel item)
        {
            try
            {
                _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    string query = "INSERT INTO Item(idContener, idShelf, name) VALUES (@ContenerId, @idShelf, @name);";
                    _connection.Execute(query, new { ContenerId = item.idContener, idShelf = item.idShelf, name = item.name }, 
                        transaction: transaction);

                    // Commit the transaction to make the changes permanent
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and optionally roll back the transaction
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            finally
            {
                // Close the connection outside the try-catch block
                _connection.Close();
                OnAdded();
            }
        }
    }
}
