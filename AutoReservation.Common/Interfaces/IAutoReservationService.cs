using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;


namespace AutoReservation.Common.Interfaces
{
    [ServiceContract] // TODO Namespace?
    public interface IAutoReservationService
    {
        /**
         * Auto 
         */

        [OperationContract]
        List<AutoDto> GetAllAutos();
        
        [OperationContract]
        AutoDto getAuto(int id);

        [OperationContract]
        void addAuto(AutoDto auto);

        [OperationContract]
        void updateAuto(AutoDto original, AutoDto modified);

        [OperationContract]
        void deleteAuto(AutoDto auto);


        /**
         * Kunde
         */

        [OperationContract]
        List<KundeDto> GetAllKunden();

        [OperationContract]
        KundeDto getKunde(int id);

        [OperationContract]
        void addKunde(KundeDto kunde);

        [OperationContract]
        void updateKunde(KundeDto original, KundeDto modified);

        [OperationContract]
        void deleteKunde(KundeDto kunde);

        /**
         * Reservation
        */

        [OperationContract]
        List<ReservationDto> GetAllReservationen();

        [OperationContract]
        ReservationDto getReservation(int id);

        [OperationContract]
        void addReservation(ReservationDto reservation);

        [OperationContract]
        void updateReservation(ReservationDto original, ReservationDto modified);

        [OperationContract]
        void deleteReservation(ReservationDto auto);

    }
}
