using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class UserPack
    {
        [Key]
        public int user_pack_id { get; set; }
        [Key]
        public int user_id { get; set; }

        public string pack_name { get; set; }

        public int index { get; set; }

        public DateTime last_update { get; set; }
    }
}
