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
    
    public partial class LookupDistances
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LookupDistances()
        {
            this.HorseFrisknessRecord = new HashSet<HorseFrisknessRecord>();
            this.Prizes = new HashSet<Prizes>();
            this.RaceCalendar = new HashSet<RaceCalendar>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Code { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorseFrisknessRecord> HorseFrisknessRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prizes> Prizes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceCalendar> RaceCalendar { get; set; }
    }
}