using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{

    public class ViewModel 
    {

        DataReader _reader;
        DataCreator _creator;
        DataDestroyer _destroyer;

        public ViewModel(DataReader dataReader, DataCreator creator, DataDestroyer destroyer)
        {

            _reader = dataReader;
            _creator = creator;
            _destroyer = destroyer;
        }

        public  List<ContenerModel> GetAllConteenrs()
        { 
            return _reader.LoadAllConteners();
        }

        public List<ShelfModel> GetAllShelfByContener(int superiorId)
        {
            return _reader.LoadAllShelfsByContener(superiorId);
        }

        public List<ItemModel> GetAllItemByShelf(int superiorId)
        {
            return _reader.LoadItemsByShelf(superiorId);
        }

        public void AddToCollection(ContenerModel contener)
        {
            _creator.Create(contener);
        }

        public void AddToCollection(ShelfModel shelf)
        {
            _creator.Create(shelf);
        }

        public void AddToCollection(ItemModel item)
        {
            _creator.Create(item);
        }

        public void Destroy(ContenerModel contener)
        {
            _destroyer.Delete(contener);
        }
        
        public void Destroy(ShelfModel shelf)
        {
            _destroyer.Delete(shelf);
        }

        public void Destroy(ItemModel item)
        {
            _destroyer.Delete(item);
        }

        public void AddToColletcion(int superiorContenerId, int superiorShelfId, string name)
        {
            //_creator.CreateShelf(superiorContenerId, name);
        }
    }
}
