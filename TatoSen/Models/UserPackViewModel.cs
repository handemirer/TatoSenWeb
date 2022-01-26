using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TatoSen.Model
{
    public class UserPackViewModel
    {
        [Key]
        public int user_pack_id { get; set; }
        [Key]
        public int user_id { get; set; }

        public string pack_name { get; set; }

        public int index { get; set; }
        public int count { get; set; }

        public DateTime last_update { get; set; }
    }
}
