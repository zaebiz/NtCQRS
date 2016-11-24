using System.Data.Entity;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Command
{
    /// <summary>
    /// ������� ����� ��� ������ ����������/���������� ����� ��������
    /// ����� �� �������������, � �������������� ����� � ����, �������� ���������� ���
    /// </summary>
    public class AddOrUpdateCmd<TEntity>
        : DbCommandBase
        , IDbCommand<TEntity, TEntity>
        where TEntity : class, IDbEntity
    {
        public AddOrUpdateCmd(DbContext ctx) : base(ctx)
        {}

        public virtual TEntity Execute(TEntity entity)
        {
            _db.AddOrUpdate(entity);
            _db.SaveChanges();
            return entity;
        }

        public virtual async Task<TEntity> ExecuteAsync(TEntity entity)
        {
            _db.AddOrUpdate(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}