using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        public IList<AutoDto> Autos()
        {
            throw new NotImplementedException();
        }

        public AutoDto GetAuto(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuto(AutoDto original, AutoDto modified)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public IList<KundeDto> Kunden()
        {
            throw new NotImplementedException();
        }

        public KundeDto GetKunde(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void UpdateKunde(KundeDto original, KundeDto modified)
        {
            throw new NotImplementedException();
        }

        public void DeleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public IList<ReservationDto> Reservationen()
        {
            throw new NotImplementedException();
        }

        public ReservationDto GetReservation(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified)
        {
            throw new NotImplementedException();
        }

        public void DeleteReservation(ReservationDto auto)
        {
            throw new NotImplementedException();
        }
    }
}