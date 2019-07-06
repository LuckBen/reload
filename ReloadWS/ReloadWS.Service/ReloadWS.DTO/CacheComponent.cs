using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReloadWS.DTO
{
    public class CacheComponent
    {
        public string id { get; set; }
        public object objeto { get; set; }
        public DateTime tiempo { get; set; }
        public Type tipo { get; set; }
    }
}
