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
        IList<AutoDto> Autos();
        
        [OperationContract]
        AutoDto GetAuto(int id);

        [OperationContract]
        void InsertAuto(AutoDto auto);

        [OperationContract]
        void UpdateAuto(AutoDto original, AutoDto modified);

        [OperationContract]
        void DeleteAuto(AutoDto auto);


        /**
         * Kunde
         */

        [OperationContract]
        IList<KundeDto> Kunden();

        [OperationContract]
        KundeDto GetKunde(int id);

        [OperationContract]
        void InsertKunde(KundeDto kunde);

        [OperationContract]
        void UpdateKunde(KundeDto original, KundeDto modified);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);

        /**
         * Reservation
        */

        [OperationContract]
        IList<ReservationDto> Reservationen();

        [OperationContract]
        ReservationDto GetReservation(int id);

        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        [OperationContract]
        void UpdateReservation(ReservationDto original, ReservationDto modified);

        [OperationContract]
        void DeleteReservation(ReservationDto auto);



    }
}
