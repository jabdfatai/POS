using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Model
{
    public class PosScanEntry:EntityItem
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string UPC { get; set; }
        public Guid userid { get; set; }
        public string scantime { get; set; }
        public DateTime scandate { get; set; }
        public char dir { get; set; }
        public int source { get; set; }
        public string tranxid { get; set; }

    }
}
