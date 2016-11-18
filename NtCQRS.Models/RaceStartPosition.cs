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
    
    public partial class RaceStartPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RaceStartPosition()
        {
            this.RaceResults = new HashSet<RaceResults>();
        }
    
        public int Id { get; set; }
        public int StartPosition { get; set; }
        public double RiderWeight { get; set; }
        public double HorseHandicap { get; set; }
        public int GitNumber { get; set; }
        public Nullable<int> HorseId { get; set; }
        public Nullable<int> RaceId { get; set; }
    
        public virtual Horses Horses { get; set; }
        public virtual RaceCalendar RaceCalendar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceResults> RaceResults { get; set; }
    }
}
