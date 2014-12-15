using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public class ServiceTestRemote : ServiceTestBase
    {
        private static ServiceHost serviceHost;
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            serviceHost = new ServiceHost(typeof(AutoReservationService));
            serviceHost.Open();
        }

        [ClassCleanup]
        public static void TearDown()
        {
            if (serviceHost.State != CommunicationState.Closed)
                serviceHost.Close();
        }

        private IAutoReservationService target;
        protected override IAutoReservationService Target
        {
            get
            {
                if (target == null)
                {
                    ChannelFactory<IAutoReservationService> channelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");
                    target = channelFactory.CreateChannel();
                }
                return target;
            }
        }


        [ExpectedException(typeof(FaultException))]
        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            AutoDto old = Target.GetAuto(1);
            AutoDto auto1 = Target.GetAuto(1);

            AutoDto auto2 = Target.GetAuto(1);
            auto2.Marke = "TestMarke";
            Target.UpdateAuto(Target.GetAuto(1), auto2);

            auto1.Marke = "NewTestMarke";
            Target.UpdateAuto(old, auto1);
        }

        [ExpectedException(typeof(FaultException))]
        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            KundeDto old = Target.GetKunde(1);
            KundeDto kunde1 = Target.GetKunde(1);

            KundeDto kunde2 = Target.GetKunde(1);
            kunde2.Nachname = "TestName";
            Target.UpdateKunde(Target.GetKunde(1), kunde2);

            kunde1.Nachname = "NewTestName";
            Target.UpdateKunde(old, kunde1);
        }

        [ExpectedException(typeof(FaultException))]
        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            ReservationDto old = Target.GetReservation(1);
            ReservationDto reservation1 = Target.GetReservation(1);

            ReservationDto reservation2 = Target.GetReservation(1);
            reservation2.Von = DateTime.Now;
            Target.UpdateReservation(Target.GetReservation(1), reservation2);

            reservation1.Von = DateTime.Now.AddHours(1);
            Target.UpdateReservation(old, reservation1);
        }


    }
}