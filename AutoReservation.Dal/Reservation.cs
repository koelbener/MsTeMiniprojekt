//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoReservation.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservation
    {
        public int ReservationNr { get; set; }
        public int AutoId { get; set; }
        public int KundeId { get; set; }
        public System.DateTime Von { get; set; }
        public System.DateTime Bis { get; set; }
    
        public virtual Auto Auto { get; set; }
        public virtual Kunde Kunde { get; set; }
    }
}
