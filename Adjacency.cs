using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp
{
    public class Adjacency
    {
        public int sourceId { get; set; }
        public int targetId { get; set; }
        public string sourceData { get; set; }
        public string targetData { get; set; }
        public int level { get; set; }
    }
}
