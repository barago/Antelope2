using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Antelope.Models.Test
{
    public class Review
    {

        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(128)]
        public string Topic { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }



    }
}