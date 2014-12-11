using AutoReservation.Ui.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Ui.Factory
{
    abstract class Creator
    {
        public Creator GetCreator()
        {
            Type serviceLayerType = Type.GetType(Settings.Default.ServiceLayerType);
            if (serviceLayerType == null) { return new LocalDataAccessCreator(); }
            return (Creator)Activator.CreateInstance(serviceLayerType);
        }
    }
}
