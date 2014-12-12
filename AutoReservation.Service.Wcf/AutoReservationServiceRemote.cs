using System;
using System.Collections.Generic;
using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationServiceRemote : IAutoReservationService
    {
        private AutoReservationBusinessComponent businessComponent;

        public AutoReservationServiceRemote()
        {
            businessComponent = new AutoReservationBusinessComponent();
        }

        public IList<AutoDto> Autos()
        {
            return businessComponent.getAutos().ConvertToDtos();
        }

        public AutoDto GetAuto(int id)
        {
            return businessComponent.getAuto(id).ConvertToDto();
        }

        public void InsertAuto(AutoDto auto)
        {
            businessComponent.addAuto(auto.ConvertToEntity());
        }

        public void UpdateAuto(AutoDto original, AutoDto modified)
        {
            businessComponent.updateAuto(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteAuto(AutoDto auto)
        {
            businessComponent.deleteAuto(auto.ConvertToEntity());
        }

        public IList<KundeDto> Kunden()
        {
            return businessComponent.getKunden().ConvertToDtos();
        }

        public KundeDto GetKunde(int id)
        {
            return businessComponent.getKunde(id).ConvertToDto();
        }

        public void InsertKunde(KundeDto kunde)
        {
            businessComponent.addKunde(kunde.ConvertToEntity());
        }

        public void UpdateKunde(KundeDto original, KundeDto modified)
        {
            businessComponent.updateKunde(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteKunde(KundeDto kunde)
        {
            businessComponent.deleteKunde(kunde.ConvertToEntity());
        }

        public IList<ReservationDto> Reservationen()
        {
            return businessComponent.Reservationen().ConvertToDtos();
        }

        public ReservationDto GetReservation(int id)
        {
            return businessComponent.getReservation(id).ConvertToDto();
        }

        public void InsertReservation(ReservationDto reservation)
        {
            businessComponent.addReservation(reservation.ConvertToEntity());
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified)
        {
            businessComponent.updateReservation(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void DeleteReservation(ReservationDto auto)
        {
            businessComponent.deleteReservation(auto.ConvertToEntity());
        }
    }
}