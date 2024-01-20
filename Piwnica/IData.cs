using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    public abstract class IData
    {
        public int id { get; set; }
       
        public string name { get; set; }

        public string AsString
        {
            get { return $"{id}. {name}"; }
        }
    }
}
