using Entites.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }
        [StringLength(50)]
        public string AdminFirstName { get; set; }
        [StringLength(50)]
        public string AdminLastName { get; set; }
        [StringLength(50)]
        public string AdminUserName { get; set; }
        [StringLength(500)]
        public string AdminPassword { get; set; }
        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
