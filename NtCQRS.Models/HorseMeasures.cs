//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NtCQRS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HorseMeasures
    {
        public int Id { get; set; }
        public System.DateTime MeasureDate { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double Bridth { get; set; }
        public double LegWide { get; set; }
        public Nullable<int> HorseId { get; set; }
        public Nullable<int> RacetrackId { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
    
        public virtual Horses Horses { get; set; }
        public virtual LookupRacetracks LookupRacetracks { get; set; }
    }
}