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
            ChannelFactory<IAutoReservationService> myChannelFactory = new ChannelFactory<IAutoReservationService>("AutoReservationService");

            // Create a channel.
            return myChannelFactory.CreateChannel();
        }
    }
}
