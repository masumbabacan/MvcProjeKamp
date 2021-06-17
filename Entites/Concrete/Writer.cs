using System;
using System.Collections.Generic;
using System.Linq;
using Entites.Abstract;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entites.Concrete
{
    public class Writer : IEntity
    {
        [Key]
        public int WriterId { get; set; }
        [StringLength(50)]
        public string WriterName { get; set; }
        [StringLength(50)]
        public string WriterSurName { get; set; }
        [StringLength(200)]
        public string WriterImage { get; set; }
        [StringLength(50)]
        public string WriterMail{ get; set; }
        [StringLength(50)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }
    }
}
