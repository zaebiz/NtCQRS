namespace NtCQRS.Specification
{
    public interface IQueryPaging
    {
        int Offset { get; }
        int PageSize { get; set; }
    }
}
