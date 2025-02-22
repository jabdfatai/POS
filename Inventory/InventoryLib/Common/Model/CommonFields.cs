using System;

namespace Common.Model
{
    public class CommonFields
    {
        public Guid uniqueid { get; set; } = Guid.NewGuid();
        public int status { get; set; } = 1;
        public DateTime dt_crtd { get; set; } = DateTime.UtcNow;
        public DateTime dt_modf { get; set; }
    }
 
}
