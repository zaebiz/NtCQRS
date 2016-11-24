using System;
using System.ComponentModel.DataAnnotations.Schema;
using NtCQRS.Repository;

namespace NtCQRS.Models.EF
{
    [Table("Posts")]
    public class Post : DbEntityBase
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public DateTime PostDate { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }
}