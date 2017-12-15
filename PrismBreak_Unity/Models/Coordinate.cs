using PrismBreak_Unity.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismBreak_Unity.Models
{
    public class Coordinate : EventArgs, ILocationCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Coordinate()
        {

        }

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}