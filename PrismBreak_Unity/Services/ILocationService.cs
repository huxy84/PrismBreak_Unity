using System;
using System.Collections.Generic;
using System.Text;

namespace PrismBreak_Unity.Services
{
    public interface ILocationService
    {
        void GetMyLocation();

        double GetDistanceTravelled(double latitude, double longitude);

        event EventHandler<ILocationCoordinates> MyLocation;
    }
}