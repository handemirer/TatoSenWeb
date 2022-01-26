using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Model
{
    public class Sentence
    {
        [Key]
        public int sentence_id { get; set; }
        public string text { get; set; }
        public int pack_id { get; set; }
    }
}

