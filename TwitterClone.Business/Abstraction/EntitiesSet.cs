using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterClone.Business.Abstraction
{
    public class EntitiesSet<T>
    {
        public IEnumerable<T> Entities { get; set; }
        public int Total { get; set; }
        public int PageSize { get; set; }

    }
}
