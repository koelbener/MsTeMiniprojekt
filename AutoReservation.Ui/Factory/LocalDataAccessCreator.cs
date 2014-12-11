using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AutoReservation.Ui.Factory
{
    class LocalDataAccessCreator : Creator
    {
        public IAutoReservationService CreateInstance()
        {
            return new AutoReservationServiceRemote();
        }
    }
}
