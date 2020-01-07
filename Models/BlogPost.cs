﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_API.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
}