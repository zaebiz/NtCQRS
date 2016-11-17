namespace NtCQRS.Repository
{
    public interface INtPaging
    {
        int Offset { get; }
        int Limit { get; }
    }
}
