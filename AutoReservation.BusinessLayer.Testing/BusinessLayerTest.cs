using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity.Core.Objects;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            Auto auto = Target.GetAuto(1);
            auto.Marke = "BMW";
            auto.Tagestarif = 10;

            Target.UpdateAuto(Target.GetAuto(1), auto);
            Assert.AreEqual("BMW", Target.GetAuto(1).Marke);
            Assert.AreEqual(10, Target.GetAuto(1).Tagestarif);
        }

        [TestMethod]
        public void ReadAutoTest()
        {
            Assert.AreEqual("Fiat Punto", Target.GetAuto(1).Marke);
            Assert.AreEqual(50, Target.GetAuto(1).Tagestarif);
            Assert.AreEqual(ObjectContext.GetObjectType(Target.GetAuto(1).GetType()), typeof(AutoReservation.Dal.StandardAuto));
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde kunde = Target.GetKunde(1);
            DateTime now = DateTime.Now;
            kunde.Geburtsdatum = now;
            kunde.Nachname = "Moser";
            kunde.Vorname = "Hansueli";
            Target.UpdateKunde(Target.GetKunde(1), kunde);

            Kunde newLoaded = Target.GetKunde(1);
            Assert.AreEqual("Moser", newLoaded.Nachname);
            Assert.AreEqual("Hansueli", newLoaded.Vorname);
            Assert.AreEqual(now, newLoaded.Geburtsdatum);
        }

        public void UpdateAutoTestWithNewRelation()
        {
            Auto auto = Target.GetAuto(1);
            int numberOfReservations = auto.Reservations.Count;

            Kunde newKunde = createKunde();

            // reservation
            Reservation newReservation = new Reservation
            {
                Bis = DateTime.Now,
                Von = DateTime.Now,
                Kunde = newKunde

            };
            auto.Reservations.Add(newReservation);

            Target.UpdateAuto(Target.GetAuto(1), auto);
            Assert.AreEqual(numberOfReservations + 1, Target.GetAuto(1).Reservations.Count);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation reservation = Target.GetReservation(1);
            DateTime newDate = DateTime.Now;
            reservation.Von = newDate;
            reservation.Bis = newDate.AddHours(1);
            Target.UpdateReservation(Target.GetReservation(1), reservation);
            Assert.AreEqual(newDate, Target.GetReservation(1).Von);
            Assert.AreEqual(newDate.AddHours(1), Target.GetReservation(1).Bis);
        }

        [TestMethod]
        public void UpdateReservationOwnerTest()
        {
            Reservation reservation = Target.GetReservation(1);
            Kunde oldOwner = reservation.Kunde;
            Kunde newOwner = createKunde();
            Target.AddKunde(newOwner);

            reservation.Kunde = newOwner;
            Target.UpdateReservation(Target.GetReservation(1), reservation);

            Assert.IsFalse(oldOwner.Reservations.Contains(reservation));
            Assert.IsTrue(newOwner.Reservations.Contains(reservation));
            Assert.AreEqual(Target.GetReservation(1).Kunde, newOwner);
            Assert.AreEqual(Target.GetReservation(1).KundeId, newOwner.Id);
        }

        private Kunde createKunde()
        {
            Kunde kunde = new Kunde
            {
                Geburtsdatum = DateTime.Now,
                Nachname = "Müller",
                Vorname = "Karl"
            };
            return kunde;
        }

    }
}
