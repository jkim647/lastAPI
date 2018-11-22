using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace English.Models
{
    public class EnglishItems
    {
        public int Id { get; set; }
        public string English { get; set; }
        public string Spanish { get; set; }
        public string Accent { get; set; }
        public string Note { get; set; }
        public object Tags { get; internal set; }
    }
}
