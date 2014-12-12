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
            // TODO change Kundenvorname to correct name
            Assert.AreEqual("Kundenvorname", Target.GetKunde(1).Nachname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            // TODO fix correct auto id in getAuto()
            Assert.AreEqual(Target.GetAuto(1), Target.GetReservation(1).Auto);
            Assert.AreEqual("Von", Target.GetReservation(1).Von);
            Assert.AreEqual("Bis", Target.GetReservation(1).Bis);
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
            Target.InsertAuto(auto);

            AutoDto saved = Target.GetAuto(999);
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

            Target.InsertKunde(kunde);

            KundeDto saved = Target.GetKunde(999);
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
            reservation.Kunde = Target.GetKunde(999);
            reservation.Auto = Target.GetAuto(999);
            reservation.Von = new DateTime(2014, 01, 01);
            reservation.Bis = new DateTime(2015, 01, 01);

            Target.InsertReservation(reservation);

            ReservationDto saved = Target.GetReservation(999);
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
            Target.DeleteKunde(Target.GetKunde(999));
            Assert.IsNull(Target.GetKunde(999));
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            Target.DeleteAuto(Target.GetAuto(999));
            Assert.IsNull(Target.GetAuto(999));
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Target.DeleteReservation(Target.GetReservation(999));
            Assert.IsNull(Target.GetReservation(999));
        }
    }
}
