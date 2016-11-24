using System.Threading.Tasks;

namespace NtCQRS.Command
{
    /// <summary>
    /// ��� "�������" (Command) - ����� �������� ���������� ������
    /// ����� ���������� ��������� ��������
    /// </summary>
    public interface IDbCommand<in TParam, TResult>
    {
        TResult Execute(TParam data);
        Task<TResult> ExecuteAsync(TParam data);
    }
}