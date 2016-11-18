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
    
    public partial class RaceGitResults
    {
        public int Id { get; set; }
        public int GitNumber { get; set; }
        public System.TimeSpan TimeResult { get; set; }
        public double Friskiness1000 { get; set; }
        public int FailuresCount { get; set; }
        public decimal MoneyWin { get; set; }
        public int PointsWin { get; set; }
        public Nullable<int> RiderId { get; set; }
        public Nullable<int> RaceResultId { get; set; }
        public string OldSystemId { get; set; }
        public string OldSystemId2 { get; set; }
        public string VniikId { get; set; }
    
        public virtual RaceResults RaceResults { get; set; }
        public virtual Riders Riders { get; set; }
    }
}
