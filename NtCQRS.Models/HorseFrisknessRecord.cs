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
    
    public partial class HorseFrisknessRecord
    {
        public int Id { get; set; }
        public System.DateTime RecordDate { get; set; }
        public System.TimeSpan RecordTime { get; set; }
        public double Friskness1000 { get; set; }
        public Nullable<int> HorseId { get; set; }
        public Nullable<int> RiderId { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public Nullable<int> AgeCategoryId { get; set; }
        public Nullable<int> GenderId { get; set; }
        public Nullable<int> BreedId { get; set; }
        public Nullable<int> DistanceId { get; set; }
        public Nullable<int> RacetrackId { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
    
        public virtual HorseOwners HorseOwners { get; set; }
        public virtual Horses Horses { get; set; }
        public virtual LookupAgeCategories LookupAgeCategories { get; set; }
        public virtual LookupDistances LookupDistances { get; set; }
        public virtual LookupGenders LookupGenders { get; set; }
        public virtual LookupHorseBreeds LookupHorseBreeds { get; set; }
        public virtual LookupRacetracks LookupRacetracks { get; set; }
        public virtual Riders Riders { get; set; }
    }
}
