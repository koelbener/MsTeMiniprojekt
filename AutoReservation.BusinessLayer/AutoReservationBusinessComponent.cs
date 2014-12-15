using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        private AutoReservationEntities context;

        public AutoReservationBusinessComponent()
        {
            context = new AutoReservationEntities();
        }

        public IList<Auto> getAutos()
        {
            return context.Autos.AsNoTracking().ToList();
        }

        public Auto getAuto(int id)
        {
            return context.Autos.AsNoTracking().SingleOrDefault(a => a.Id == id);
        }

        // TODO: Exception handling for all update methods
        public void updateAuto(Auto original, Auto modified)
        {
            context.Autos.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);
            context.SaveChanges();
        }

        public void deleteAuto(Auto auto)
        {
            context.Autos.Attach(auto);
            context.Autos.Remove(auto);
            context.SaveChanges();
        }

        public void addAuto(Auto auto)
        {
            context.Autos.Add(auto);
            context.SaveChanges(); // TODO: SaveChanges always needed?
        }


        /**
         * Kunden
        */

        public IList<Kunde> getKunden()
        {
            return context.Kunden.AsNoTracking().ToList();
        }

        public Kunde getKunde(int id)
        {
            return context.Kunden.AsNoTracking().SingleOrDefault(k => k.Id == id);
        }        

        public void deleteKunde(Kunde kunde)
        {
            context.Kunden.Attach(kunde);
            context.Kunden.Remove(kunde);
            context.SaveChanges();
        }

        public void updateKunde(Kunde original, Kunde modified)
        {
            context.Kunden.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);
            context.SaveChanges();
        }

        public void addKunde(Kunde kunde)
        {
            context.Kunden.Add(kunde);
            context.SaveChanges(); 
        }


        /**
         *  Reservation
        */ 
        public IList<Reservation> Reservationen()
        {
            return context.Reservationen.AsNoTracking().ToList();
        }

        public Reservation getReservation(int reservationNr)
        {
            return context.Reservationen.AsNoTracking().SingleOrDefault(r => r.ReservationNr == reservationNr);
        }        

        public void deleteReservation(Reservation reservation)
        {
            context.Reservationen.Attach(reservation);
            context.Reservationen.Remove(reservation);
            context.SaveChanges();
        }
        public void updateReservation(Reservation original, Reservation modified)
        {
            context.Reservationen.Attach(original);
            context.Entry(original).CurrentValues.SetValues(modified);
            context.SaveChanges();
        }

        public void addReservation(Reservation reservation)
        {
            context.Reservationen.Add(reservation);
            context.SaveChanges();
        }


        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

    }
}