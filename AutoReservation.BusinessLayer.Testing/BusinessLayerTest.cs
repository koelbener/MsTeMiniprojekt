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
            Auto auto = Target.getAuto(1);
            auto.Marke = "BMW";
            auto.Tagestarif = 10;

            Target.updateAuto(Target.getAuto(1), auto);
            Assert.AreEqual("BMW", Target.getAuto(1).Marke);
            Assert.AreEqual(10, Target.getAuto(1).Tagestarif);
        }

        [TestMethod]
        public void ReadAutoTest()
        {
            Assert.AreEqual("Fiat Punto", Target.getAuto(1).Marke);
            Assert.AreEqual(50, Target.getAuto(1).Tagestarif);
            Assert.AreEqual(ObjectContext.GetObjectType(Target.getAuto(1).GetType()), typeof(AutoReservation.Dal.StandardAuto));
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            /*
            Kunde kunde = Target.getKunde(1);
            DateTime now = DateTime.Now;
            kunde.Geburtsdatum = now;
            kunde.Nachname = "Moser";
            kunde.Vorname = "Hansueli";
            Target.updateKunde(Target.getKunde(1), kunde);

            newLoaded = Target.getKunde(1)
            Assert.AreEqual("Moser", kunde.Nachname);
            Assert.AreEqual("Hansueli", kunde.Vorname);
            Assert.AreEqual(now, kunde.Geburtsdatum);
            */
        }

        public void UpdateAutoTestWithNewRelation()
        {
            Auto auto = Target.getAuto(1);
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

            Target.updateAuto(Target.getAuto(1), auto);
            Assert.AreEqual(numberOfReservations + 1, Target.getAuto(1).Reservations.Count);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation reservation = Target.getReservation(1);
            DateTime newDate = DateTime.Now;
            reservation.Von = newDate;
            reservation.Bis = newDate.AddHours(1);
            Target.updateReservation(Target.getReservation(1), reservation);
            Assert.AreEqual(newDate, Target.getReservation(1).Von);
            Assert.AreEqual(newDate.AddHours(1), Target.getReservation(1).Bis);
        }

        [TestMethod]
        public void UpdateReservationOwnerTest()
        {
            Reservation reservation = Target.getReservation(1);
            Kunde oldOwner = reservation.Kunde;
            Kunde newOwner = createKunde();
            Target.addKunde(newOwner);

            reservation.Kunde = newOwner;
            Target.updateReservation(Target.getReservation(1), reservation);

            Assert.IsFalse(oldOwner.Reservations.Contains(reservation));
            Assert.IsTrue(newOwner.Reservations.Contains(reservation));
            Assert.AreEqual(reservation.Kunde, newOwner);
            Assert.AreEqual(reservation.KundeId, newOwner.Id);
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
