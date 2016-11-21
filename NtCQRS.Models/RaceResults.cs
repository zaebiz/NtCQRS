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
    
    public partial class RaceResults
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceResults()
        {
            this.RaceGitResults = new HashSet<RaceGitResults>();
        }
    
        public int Id { get; set; }
        public int GitNumber { get; set; }
        public int Place { get; set; }
        public System.TimeSpan TimeResult { get; set; }
        public int FailuresCount { get; set; }
        public decimal MoneyWin { get; set; }
        public int PointsWin { get; set; }
        public Nullable<int> HorseId { get; set; }
        public Nullable<int> RaceId { get; set; }
        public Nullable<int> RiderId { get; set; }
        public Nullable<int> PenaltyId { get; set; }
        public Nullable<int> RaceClaimId { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
        public double Friskiness1000 { get; set; }
        public Nullable<int> StartPositionId { get; set; }
        public Nullable<int> RacetrackPenaltyId { get; set; }
    
        public virtual Horses Horses { get; set; }
        public virtual LookupRacePenalties LookupRacePenalties { get; set; }
        public virtual RaceCalendar RaceCalendar { get; set; }
        public virtual RaceClaims RaceClaims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceGitResults> RaceGitResults { get; set; }
        public virtual RaceStartPosition RaceStartPosition { get; set; }
        public virtual RacetrackPenalties RacetrackPenalties { get; set; }
        public virtual Riders Riders { get; set; }
    }
}