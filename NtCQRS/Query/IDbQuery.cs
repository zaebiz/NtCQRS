using System.Threading.Tasks;

namespace NtCQRS.Query
{
    /// <summary>
    /// ��� "������" (Query) - �������� ������������ ������ 
    /// �� ����� ����� ������ ������ 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TSpecification"></typeparam>
    public interface IDbQuery<TEntity, TSpecification> where TEntity : class
    {
        TSpecification Spec { get; set; }

        TEntity GetResult();
        Task<TEntity> GetResultAsync();
    }

    // todo ����� ��������������� ��� �������, �������� ���������� � ����������� �������, ��������
    //public interface IDbQuery<out TEntity, TSpecification> 
    //    where TEntity : class
    //{
    //    TSpecification Spec { get; set; }
    //    TEntity GetResult();
    //}

    //public interface IDbAsyncQuery<TEntity, TSpecification> 
    //    : IDbQuery<Task<TEntity>, TSpecification>
    //    where TEntity : class
    //{
    //}
}