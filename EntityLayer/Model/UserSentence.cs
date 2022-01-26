using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class UserSentence
    {
        [Key]
        public int user_sentence_id { get; set; }
        public int user_id { get; set; }
        public int user_pack_id { get; set; }
        public int sentence_id { get; set; }

    }
}

