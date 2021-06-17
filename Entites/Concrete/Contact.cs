using System;
using System.Collections.Generic;
using System.Linq;
using Entites.Abstract;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entites.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int ContactId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string UserMail { get; set; }
        [StringLength(1000)]
        public string Subject { get; set; }
        [StringLength(1000)]
        public string Message { get; set; }

    }
}
