using System.Threading.Tasks;

namespace NtCQRS.Command
{
    /// <summary>
    /// “ип "команда" (Command) - люба€ операци€ измен€юща€ данные
    /// может возвращать результат операции
    /// </summary>
    public interface IDbCommand<in TParam, TResult>
    {
        TResult Execute(TParam data);
        Task<TResult> ExecuteAsync(TParam data);
    }
}