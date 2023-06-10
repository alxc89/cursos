using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{   
    public class PostWithTagsCount
    {
        [Key]
        public string Name { get; set; } = "";
        //public int Count { get; set; } = 0;
    }
}