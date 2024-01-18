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

        public ViewModel(DataReader dataReader) 
        {

            _reader = dataReader;

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
    }
}
