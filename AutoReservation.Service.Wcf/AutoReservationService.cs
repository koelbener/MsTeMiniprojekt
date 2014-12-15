using System;
using System.Collections.Generic;
using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;
using System.Diagnostics;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private AutoReservationBusinessComponent businessComponent;

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public AutoReservationService()
        {
            WriteActualMethod();
            businessComponent = new AutoReservationBusinessComponent();
        }

        public IList<AutoDto> Autos()
        {
            WriteActualMethod();
            return businessComponent.getAutos().ConvertToDtos();
        }

        public AutoDto GetAuto(int id)
        {
            WriteActualMethod();
            return businessComponent.getAuto(id).ConvertToDto();
        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.addAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto original, AutoDto modified)
        {
            WriteActualMethod();
            businessComponent.updateAuto(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.deleteAuto(auto.ConvertToEntity());
        }

        public IList<KundeDto> Kunden()
        {
            WriteActualMethod();
            return businessComponent.getKunden().ConvertToDtos();
        }

        public KundeDto GetKunde(int id)
        {
            WriteActualMethod();
            return businessComponent.getKunde(id).ConvertToDto();
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.addKunde(kunde.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto original, KundeDto modified)
        {
            WriteActualMethod();
            businessComponent.updateKunde(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.deleteKunde(kunde.ConvertToEntity());
        }

        public IList<ReservationDto> Reservationen()
        {
            WriteActualMethod();
            return businessComponent.Reservationen().ConvertToDtos();
        }

        public ReservationDto GetReservation(int id)
        {
            WriteActualMethod();
            return businessComponent.getReservation(id).ConvertToDto();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.addReservation(reservation.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified)
        {
            WriteActualMethod();
            businessComponent.updateReservation(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto auto)
        {
            WriteActualMethod();
            businessComponent.deleteReservation(auto.ConvertToEntity());
        }
    }
}