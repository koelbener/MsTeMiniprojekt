using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
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
            IList<AutoDto> allAutos = Target.GetAllAutos();
            Assert.IsTrue(allAutos.Count > 0);
        }

        [TestMethod]
        public void KundenTest()
        {
            IList<KundeDto> allKunden = Target.GetAllKunden();
            Assert.IsTrue(allKunden.Count > 0);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            IList<ReservationDto> allRes = Target.GetAllReservationen();
            Assert.IsTrue(allRes.Count > 0);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            Assert.AreEqual("Fiat Punto", Target.getAuto(1).Marke);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            // TODO change Kundenvorname to correct name
            Assert.AreEqual("Kundenvorname", Target.getKunde(1).Nachname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            // TODO fix correct auto id in getAuto()
            Assert.AreEqual(Target.getAuto(1), Target.getReservation(1).Auto);
            Assert.AreEqual("Von", Target.getReservation(1).Von);
            Assert.AreEqual("Bis", Target.getReservation(1).Bis);
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            // TODO
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto auto = new AutoDto();
            auto.Marke="Bugatti";
            auto.Tagestarif=1000;
            auto.Id = 999;
            Target.addAuto(auto);

            AutoDto saved = Target.getAuto(999);
            Assert.AreEqual(999, saved.Id);
            Assert.AreEqual("Bugatti", saved.Marke);
            Assert.AreEqual(1000, saved.Tagestarif);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto kunde = new KundeDto();
            kunde.Id = 999;
            kunde.Nachname = "Avsar";
            kunde.Vorname = "Emre";
            kunde.Geburtsdatum = new DateTime(1992, 04, 10);

            Target.addKunde(kunde);

            KundeDto saved = Target.getKunde(999);
            Assert.AreEqual(999, saved.Id);
            Assert.AreEqual("Emre", saved.Vorname);
            Assert.AreEqual("Avsar", saved.Nachname);
            Assert.AreEqual(new DateTime(1992, 04, 10), saved.Geburtsdatum);
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            ReservationDto reservation = new ReservationDto();
            reservation.ReservationNr = 999;
            reservation.Kunde = Target.getKunde(999);
            reservation.Auto = Target.getAuto(999);
            reservation.Von = new DateTime(2014, 01, 01);
            reservation.Bis = new DateTime(2015, 01, 01);

            Target.addReservation(reservation);

            ReservationDto saved = Target.getReservation(999);
            Assert.AreEqual(999, saved.ReservationNr);
            Assert.AreEqual(999, saved.Auto.Id);
            Assert.AreEqual(new DateTime(2014, 01, 01), saved.Von);
            Assert.AreEqual(new DateTime(2015, 01, 01), saved.Bis);

            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            Target.deleteKunde(Target.getKunde(999));
            Assert.IsNull(Target.getKunde(999));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            Target.deleteAuto(Target.getAuto(999));
            Assert.IsNull(Target.getAuto(999));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Target.deleteReservation(Target.getReservation(999));
            Assert.IsNull(Target.getReservation(999));
        }
    }
}
