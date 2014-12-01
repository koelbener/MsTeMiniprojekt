using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        public IList<AutoDto> GetAllAutos()
        {
            throw new NotImplementedException();
        }

        public AutoDto getAuto(int id)
        {
            throw new NotImplementedException();
        }

        public void addAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void updateAuto(AutoDto original, AutoDto modified)
        {
            throw new NotImplementedException();
        }

        public void deleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public IList<KundeDto> GetAllKunden()
        {
            throw new NotImplementedException();
        }

        public KundeDto getKunde(int id)
        {
            throw new NotImplementedException();
        }

        public void addKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void updateKunde(KundeDto original, KundeDto modified)
        {
            throw new NotImplementedException();
        }

        public void deleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public IList<ReservationDto> GetAllReservationen()
        {
            throw new NotImplementedException();
        }

        public ReservationDto getReservation(int id)
        {
            throw new NotImplementedException();
        }

        public void addReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public void updateReservation(ReservationDto original, ReservationDto modified)
        {
            throw new NotImplementedException();
        }

        public void deleteReservation(ReservationDto auto)
        {
            throw new NotImplementedException();
        }
    }
}