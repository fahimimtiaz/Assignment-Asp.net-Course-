﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Social_Hub.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Column(TypeName = "varchar"), StringLength(500), Display(Name = "Post")]
        public string PostDetails { get; set; }

        public List<HyperLink> HyperLinks = new List<HyperLink>();

        // public IEnumerable<Comment> Comments { get; set; }
    }
}