namespace NtCQRS.Specification
{
    // todo - можно переделать в класс
    public class QuerySpecification<T> where T : class 
    {
        public QuerySpecification()
        {
            Paging = new QueryPaging(20, 0);
        }

        public IQueryFilter<T> Filter { get; set; }
        public IQueryJoin<T> Join { get; set; }
        public IQueryPaging Paging { get; set; }
    }
}
