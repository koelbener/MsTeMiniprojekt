using AutoReservation.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AutoReservation.Ui.Factory
{
    class RemoteDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateInstance()
        {
            BasicHttpBinding myBinding = new BasicHttpBinding();
            EndpointAddress myEndpoint = new EndpointAddress("net.tcp://localhost:7876/AutoReservationService");

            ChannelFactory<IAutoReservationService> myChannelFactory = new ChannelFactory<IAutoReservationService>(myBinding, myEndpoint);

            // Create a channel.
            return myChannelFactory.CreateChannel();
        }
    }
}
