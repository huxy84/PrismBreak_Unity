using Plugin.DeviceInfo;
using Plugin.DeviceInfo.Abstractions;
using System;

namespace PrismBreak_Unity.Models
{
    public class Device
    {
        private IDeviceInfo device => CrossDeviceInfo.Current;
        public string Id { get; set; }
        public string Model { get; set; }
        public string OS { get; set; }

        public Device()
        {
            var device = CrossDeviceInfo.Current;
            Id = device.Id;
            Model = device.Model;
            OS = device.Version;
        }
    }
}