using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosTest()
        {
            IList<AutoDto> allAutos = Target.Autos();
            Assert.IsTrue(allAutos.Count > 0);
        }

        [TestMethod]
        public void KundenTest()
        {
            IList<KundeDto> allKunden = Target.Kunden();
            Assert.IsTrue(allKunden.Count > 0);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            IList<ReservationDto> allRes = Target.Reservationen();
            Assert.IsTrue(allRes.Count > 0);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            Assert.AreEqual("Fiat Punto", Target.GetAuto(1).Marke);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            Assert.AreEqual("Nass", Target.GetKunde(1).Nachname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            Assert.AreEqual(Target.GetAuto(1).ToString(), Target.GetReservation(1).Auto.ToString());
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            Assert.IsNull(Target.GetReservation(9999));
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            int lastIdBeforeInsert = Target.Autos().Count;

            AutoDto auto = new AutoDto();
            auto.Marke = "Bugatti";
            auto.Tagestarif = 1000;
            auto.Basistarif = 200;
            auto.AutoKlasse = AutoKlasse.Luxusklasse;
            Target.InsertAuto(auto);

            AutoDto saved = Target.GetAuto(lastIdBeforeInsert+1);
            Assert.AreEqual("Bugatti", saved.Marke);
            Assert.AreEqual(1000, saved.Tagestarif);
            Assert.AreEqual(AutoKlasse.Luxusklasse, saved.AutoKlasse);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            int lastIdBeforeInsert = Target.Kunden().Count;
            KundeDto kunde = new KundeDto();
            kunde.Nachname = "Avsar";
            kunde.Vorname = "Emre";
            kunde.Geburtsdatum = new DateTime(1992, 04, 10);
            Target.InsertKunde(kunde);

            KundeDto saved = Target.GetKunde(lastIdBeforeInsert + 1);
            Assert.AreEqual("Emre", saved.Vorname);
            Assert.AreEqual("Avsar", saved.Nachname);
            Assert.AreEqual(new DateTime(1992, 04, 10), saved.Geburtsdatum);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            int lastKundenId = Target.Kunden().Count;
            int lastAutoId = Target.Autos().Count;
            int lastReservationId = Target.Reservationen().Count;

            ReservationDto reservation = new ReservationDto();
            reservation.Kunde = Target.GetKunde(lastKundenId);
            reservation.Auto = Target.GetAuto(lastAutoId);
            reservation.Von = new DateTime(2014, 01, 01);
            reservation.Bis = new DateTime(2015, 01, 01);

            Target.InsertReservation(reservation);

            ReservationDto saved = Target.GetReservation(lastReservationId + 1);
            Assert.AreEqual(lastAutoId, saved.Auto.Id);
            Assert.AreEqual(lastKundenId, saved.Kunde.Id);
            Assert.AreEqual(new DateTime(2014, 01, 01), saved.Von);
            Assert.AreEqual(new DateTime(2015, 01, 01), saved.Bis);
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            AutoDto auto = Target.GetAuto(1);
            auto.Marke = "BMW";
            auto.Tagestarif = 10;

            Target.UpdateAuto(Target.GetAuto(1), auto);
            Assert.AreEqual("BMW", Target.GetAuto(1).Marke);
            Assert.AreEqual(10, Target.GetAuto(1).Tagestarif);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            KundeDto kunde = Target.GetKunde(1);
            DateTime now = DateTime.Now;
            kunde.Geburtsdatum = now;
            kunde.Nachname = "Moser";
            kunde.Vorname = "Hansueli";
            Target.UpdateKunde(Target.GetKunde(1), kunde);

            KundeDto newLoaded = Target.GetKunde(1);
            Assert.AreEqual("Moser", newLoaded.Nachname);
            Assert.AreEqual("Hansueli", newLoaded.Vorname);
            CompareDates(now, newLoaded.Geburtsdatum);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            ReservationDto reservation = Target.GetReservation(1);
            DateTime newDate = DateTime.Now;
            reservation.Von = newDate;
            reservation.Bis = newDate.AddHours(1);
            Target.UpdateReservation(Target.GetReservation(1), reservation);

            CompareDates(newDate, Target.GetReservation(1).Von);
            Assert.IsTrue(newDate.AddHours(1).CompareTo(Target.GetReservation(1).Bis) == 1);
            CompareDates(newDate.AddHours(1), Target.GetReservation(1).Bis);
            CompareDates(newDate, Target.GetReservation(1).Von);
            CompareDates(newDate.AddHours(1), Target.GetReservation(1).Bis);
        }

        public void CompareDates(DateTime first, DateTime second)
        {
            Assert.AreEqual(first.ToString("MM/dd/yy H:mm:ss"), second.ToString("MM/dd/yy H:mm:ss"));
        }



        [TestMethod]
        public void DeleteReservationTest()
        {
            int lastId = Target.Reservationen().Count;
            Target.DeleteReservation(Target.GetReservation(lastId));
            Assert.IsNull(Target.GetReservation(lastId));
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            int lastId = Target.Kunden().Count;
            Target.DeleteKunde(Target.GetKunde(lastId));
            Assert.IsNull(Target.GetKunde(lastId));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            int lastId = Target.Autos().Count;
            Target.DeleteAuto(Target.GetAuto(lastId));
            Assert.IsNull(Target.GetAuto(lastId));
        }
    }
}
