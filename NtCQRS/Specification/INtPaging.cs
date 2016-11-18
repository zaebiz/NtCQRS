namespace NtCQRS.Specification
{
    public interface INtPaging
    {
        int Offset { get; }
        int PageSize { get; set; }
    }
}
