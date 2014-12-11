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

        public IList<AutoDto> GetAllAutos()
        {
            return businessComponent.getAutos().ConvertToDtos();
        }

        public AutoDto getAuto(int id)
        {
            return businessComponent.getAuto(id).ConvertToDto();
        }

        public void addAuto(AutoDto auto)
        {
            businessComponent.addAuto(auto.ConvertToEntity());
        }

        public void updateAuto(AutoDto original, AutoDto modified)
        {
            businessComponent.updateAuto(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void deleteAuto(AutoDto auto)
        {
            businessComponent.deleteAuto(auto.ConvertToEntity());
        }

        public IList<KundeDto> GetAllKunden()
        {
            return businessComponent.getKunden().ConvertToDtos();
        }

        public KundeDto getKunde(int id)
        {
            return businessComponent.getKunde(id).ConvertToDto();
        }

        public void addKunde(KundeDto kunde)
        {
            businessComponent.addKunde(kunde.ConvertToEntity());
        }

        public void updateKunde(KundeDto original, KundeDto modified)
        {
            businessComponent.updateKunde(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void deleteKunde(KundeDto kunde)
        {
            businessComponent.deleteKunde(kunde.ConvertToEntity());
        }

        public IList<ReservationDto> GetAllReservationen()
        {
            return businessComponent.getReservationen().ConvertToDtos();
        }

        public ReservationDto getReservation(int id)
        {
            return businessComponent.getReservation(id).ConvertToDto();
        }

        public void addReservation(ReservationDto reservation)
        {
            businessComponent.addReservation(reservation.ConvertToEntity());
        }

        public void updateReservation(ReservationDto original, ReservationDto modified)
        {
            businessComponent.updateReservation(original.ConvertToEntity(), modified.ConvertToEntity());
        }

        public void deleteReservation(ReservationDto auto)
        {
            businessComponent.deleteReservation(auto.ConvertToEntity());
        }
    }
}