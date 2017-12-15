using System;
using System.Collections.Generic;
using System.Text;

namespace PrismBreak_Unity.Services
{
    public interface ILocationCoordinates
    {
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
