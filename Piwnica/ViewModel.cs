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

        public ViewModel(DataReader dataReader, DataCreator creator)
        {

            _reader = dataReader;
            _creator = creator;
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

        public void AddToColletcion(int superiorContenerId, int superiorShelfId, string name)
        {
            //_creator.CreateShelf(superiorContenerId, name);
        }
    }
}
