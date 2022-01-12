﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }
        [StringLength(100)]
        public string WriterName { get; set; }
        [StringLength(100)]
        public string WriterSurname { get; set; }
        [StringLength(800)]
        public string WriterImage { get; set; }
        [StringLength(80)]
        public string WriterMail { get; set; }
        [StringLength(40)]
        public string WriterPassword { get; set; }
        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}