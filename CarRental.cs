//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarzRentals
{
    using System;
    using System.Collections.Generic;
    
    public partial class CarRental
    {
        public int CarRentalId { get; set; }
        public int CarId { get; set; }
        public int EmplyeeId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public decimal DailyRate { get; set; }
        public int Odometer { get; set; }
        public Nullable<int> TotalTrip { get; set; }
        public Nullable<short> TotalDays { get; set; }
        public Nullable<decimal> TotalCost { get; set; }
        public string Notes { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime Dated { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
