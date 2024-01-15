using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class ItemModel
    {

        public int id { get; private set; }
        public int idContener { get; set; }
        public int idShelf { get; set; }
        public string name { get; set; }

        public string AsString
        {
            get { return $"{id}. {name}"; }
        }

        public ItemModel() => name = "Przedmiot";

        public ItemModel(string name)
        {
            this.name = name;
        }
    }
}
