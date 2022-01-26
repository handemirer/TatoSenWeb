using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class Pack
    {
        [Key]
        public int pack_id { get; set; }
    }
}
