using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NtCQRS.Repository;

namespace NtCQRS.Models.EF
{
    [Table("Blogs")]
    public class Blog : DbEntityBase
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }

        [ForeignKey("Author")]
        public int UserId { get; set; }
        public virtual User Author { get; set; }

        public virtual ICollection<Post> BlogPosts { get; set; }
    }
}