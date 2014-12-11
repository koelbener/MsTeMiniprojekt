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
        public IAutoReservationService CreateInstance()
        {
            
            // TODO
            BasicHttpBinding myBinding = new BasicHttpBinding();

            // TODO
            EndpointAddress myEndpoint = new EndpointAddress("http://localhost/MathService/Ep1");

            ChannelFactory<IAutoReservationService> myChannelFactory = new ChannelFactory<IAutoReservationService>(myBinding, myEndpoint);

            // Create a channel.
            return myChannelFactory.CreateChannel();
        }
    }
}
