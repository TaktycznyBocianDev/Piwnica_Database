using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class ItemModel : IData
    {

        public int id { get; set; }
        public int idContener { get; set; }
        public int idShelf { get; set; }
        public string name { get; set; }

        public string AsString
        {
            get { return $"{name}"; }
        }

        public ItemModel() => name = "Przedmiot";

        public ItemModel(string name)
        {
            this.name = name;
        }

        public ItemModel(int idContener, int idShelf, string name)
        {
            this.idContener = idContener;
            this.idShelf = idShelf;
            this.name = name;
        }
    }
}
