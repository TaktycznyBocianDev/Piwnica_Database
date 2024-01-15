using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public class ShelfModel
    {

        public int id {  get; private set; }
        [Column("ContenerId")]
        public int idContener {  get; set; }
        public string name { get; set; }

        public string AsString
        {
            get { return $"{id}. {name}"; }
        }

        public ShelfModel() => name = "Półka";

        public ShelfModel(int idContener, string name)
        {
            this.idContener = idContener;
            this.name = name;
        }

    }
}
