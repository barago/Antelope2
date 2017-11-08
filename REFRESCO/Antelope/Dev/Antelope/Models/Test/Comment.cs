using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace Antelope.Models.Test
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsAnonymous { get; set; }

        public int ReviewId { get; set; }
        public Review Review { get; set; }


    }
}