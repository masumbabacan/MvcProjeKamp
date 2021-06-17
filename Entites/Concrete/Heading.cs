﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entites.Abstract;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entites.Concrete
{
    public class Heading : IEntity
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(50)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}

