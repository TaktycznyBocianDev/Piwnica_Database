using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piwnica
{
    internal interface IData
    {
        public int id { get; set; }
       
        public string name { get; set; }

        public string AsString
        {
            get { return $"{id}. {name}"; }
        }
    }
}
