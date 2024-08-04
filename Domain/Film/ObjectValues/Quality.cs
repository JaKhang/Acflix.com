using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Film.ObjectValues
{
    public class Quality : Enumeration<Quality>
    {
        public static readonly Quality SD = new(0, "sd");
        public static readonly Quality HD = new (1, "hd");
        public static readonly Quality FHD = new(2, "fhd");
        public static readonly Quality QHD = new (3, "qhd");
        public static readonly Quality UHD = new(4, "uhd");
        public Quality(int id, string name) : base(id, name)
        {
        }
    }
}
