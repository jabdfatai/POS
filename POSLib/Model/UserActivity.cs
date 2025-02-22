using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSLib.Model
{
    public class UserActivity:EntityItem
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid userid { get; set; }
        public string action { get; set; }
        public string rec_affected { get; set; }
        public string entity_affected { get; set; }
        public string ipaddress { get; set; }
    }
}
