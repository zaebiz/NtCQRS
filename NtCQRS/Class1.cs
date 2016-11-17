using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NtCQRS
{
    //public interface ISpecification<T> where T : class
    //{
    //    IQueryable<T> GetSatisfiedItems(IQueryable<T> src);
    //}

    //public class SpecificationBase : ISpecification<RtEntityBase>
    //{
    //    private readonly RtFilterBase _filter;

    //    public SpecificationBase(RtFilterBase filter)
    //    {
    //        _filter = filter;
    //    }

    //    public IQueryable<RtEntityBase> GetSatisfiedItems(IQueryable<RtEntityBase> src)
    //    {
    //        if (_filter.Id.GetValueOrDefault() > 0)
    //            src = src.Where(r => r.Id == _filter.Id);

    //        return src;
    //    }
    //}
  
}
