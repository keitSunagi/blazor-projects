using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStudies.Models
{
    class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int PersonId { get; set; }
        public DateTime RecordData { get; set; } = DateTime.UtcNow;

    }
}
