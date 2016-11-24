using System.ComponentModel.DataAnnotations;

namespace NtCQRS.Repository
{
    public class DbEntityBase : IDbEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
