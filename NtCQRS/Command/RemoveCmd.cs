using System.Data.Entity;
using System.Threading.Tasks;
using NtCQRS.Repository;

namespace NtCQRS.Command
{
    /// <summary>
    /// ������� ����� ��� ������ �������� ����� ��������
    /// ����� �� �������������, � �������������� ����� � ����, �������� ���������� ���
    /// </summary>
    public class RemoveCmd<TEntity>
        : DbCommandBase
        , IDbCommand<TEntity, bool>
        where TEntity : class, IDbEntity
    {
        public RemoveCmd(DbContext ctx) : base(ctx)
        { }

        public bool Execute(TEntity entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
            return true;
        }

        public async Task<bool> ExecuteAsync(TEntity entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}