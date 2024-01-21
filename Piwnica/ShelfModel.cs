using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class ShelfModel : IData
    {

        public int id {  get; set; }
        public int ContenerId {  get; set; }
        public string name { get; set; }

        public string AsString
        {
            get { return $"{name}"; }
        }

        public ShelfModel() => name = "Półka";

        public ShelfModel(int idContener, string name)
        {
            this.ContenerId = idContener;
            this.name = name;
        }

    }
}
