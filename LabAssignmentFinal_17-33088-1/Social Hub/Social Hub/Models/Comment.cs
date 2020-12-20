using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_Hub.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Column(TypeName = "varchar"), StringLength(100)]
        [Required(ErrorMessage = "Comment")]
        public string CommentDetails { get; set; }

        public int PostId { get; set; }

       //public Post Post { get; set; }

    }
}