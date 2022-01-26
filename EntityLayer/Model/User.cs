using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        [MaxLength(255)]
        public string username { get; set; }
        [MaxLength(255)]
        public string password { get; set; }
        [MaxLength(255)]
        public string email { get; set; }
        public int role { get; set; }
        public string country_code { get; set; }
    }
}

