using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class Added
    {
        [Key]
        public int pack_id { get; set; }
        [Key]
        public int user_id { get; set; }
    }
}
