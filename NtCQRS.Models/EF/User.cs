using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Models.EF
{
    [Table("Users")]
    public class User : DbEntityBase
    {
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
