using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Piwnica
{
    public class ContenerModel : IData
    {

        public int id {  get; set; }
        public string name { get; set; }

        public ContenerModel()  => name = "Szafka";
        public ContenerModel(string name) => this.name = name;

        public string AsString
        {
            get { return $"{name}";}
        }


    }
}
