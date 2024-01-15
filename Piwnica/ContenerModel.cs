using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class ContenerModel
    {

        public int id {  get; private set; }
        public string name { get; set; }

        public ContenerModel()  => name = "Szafka";
        public ContenerModel(string name) => this.name = name;

        public string AsString
        {
            get { return $"{id}. {name}"; }
        }


    }
}
