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
    
    public partial class LookupRacePenalties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupRacePenalties()
        {
            this.RaceResults = new HashSet<RaceResults>();
            this.RacetrackPenalties = new HashSet<RacetrackPenalties>();
            this.RacetrackPenalties1 = new HashSet<RacetrackPenalties>();
        }
    
        public int Id { get; set; }
        public bool IsExclude { get; set; }
        public bool IsNoMoney { get; set; }
        public bool IsNoRecord { get; set; }
        public bool IsNoStandart { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Code { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResults> RaceResults { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RacetrackPenalties> RacetrackPenalties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RacetrackPenalties> RacetrackPenalties1 { get; set; }
    }
}
