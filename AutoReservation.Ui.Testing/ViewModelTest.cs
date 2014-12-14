using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosLoadTest()
        {
            AutoViewModel avm = new AutoViewModel();
            Assert.IsTrue(avm.Autos.Count > 0);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            KundeViewModel kvm = new KundeViewModel();
            Assert.IsTrue(kvm.Kunden.Count > 0);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            ReservationViewModel rvm = new ReservationViewModel();
            Assert.IsTrue(rvm.Reservationen.Count > 0);
        }
    }
}