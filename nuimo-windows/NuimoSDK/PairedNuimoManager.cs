using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace NuimoSDK
{
    public class PairedNuimoManager
    {
        private readonly string _deviceSelector;
        private DeviceWatcher _deviceWatcher { get; set; }

        public EventHandler<INuimoController> FoundNuimoController;
        public EventHandler<string> LostNuimoController;

        public PairedNuimoManager()
        {
            _deviceSelector = BluetoothLEDevice.GetDeviceSelectorFromDeviceName("Nuimo"); //GattDeviceService.GetDeviceSelectorFromUuid(ServiceGuids.NuimoServiceGuid);
            _deviceWatcher = DeviceInformation.CreateWatcher(_deviceSelector);
            _deviceWatcher.Added += _deviceWatcher_Added;
            _deviceWatcher.Removed += _deviceWatcher_Removed;
        }

        public void StartLookingForNuimos()
        {
            if (!DeviceWatcherIsReady())
            {
                _deviceWatcher.Stop();
            }
            if (DeviceWatcherIsReady())
            {
                // DeviceWatcher can only start in the above three states
                _deviceWatcher.Start();
            }
        }

        private bool DeviceWatcherIsReady()
        {
            return _deviceWatcher.Status == DeviceWatcherStatus.Created
                            || _deviceWatcher.Status == DeviceWatcherStatus.Stopped
                            || _deviceWatcher.Status == DeviceWatcherStatus.Aborted;
        }

        public async Task<IEnumerable<INuimoController>> ListPairedNuimosAsync()
        {
            return await Task.WhenAll(
                (await DeviceInformation.FindAllAsync(_deviceSelector))
                .Select(CreateNuimoController)
            );
        }

        private async Task<INuimoController> CreateNuimoController(DeviceInformation deviceInformation)
        {
            return new NuimoBluetoothController(deviceInformation.Id);
        }

        private void _deviceWatcher_Added(DeviceWatcher sender, DeviceInformation foundDevice)
        {
            var foundNuimoController = Task.Run(async () => await CreateNuimoController(foundDevice)).Result;
            FoundNuimoController?.Invoke(this, foundNuimoController);
        }

        private void _deviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate lostDevice)
        {
            LostNuimoController?.Invoke(this, lostDevice.Id);
        }
    }
}