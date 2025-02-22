using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Model
{
    public abstract class EntityItem
    {
        [DefaultValue(1)]
        public int STATUS { get; set; } = 1;
        public DateTime DT_CRTD { get; set; } = DateTime.Now;
        public DateTime? DT_MODF { get; set; }
        public Guid UNIQUE_ID { get; set; } = Guid.NewGuid();
    }
}
