namespace LightSaberGame.Helpers.GameHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Windows.Devices.Geolocation;
    using Windows.Services.Maps;
    using Windows.UI.Notifications;

    public class GeoLocatorHelper
    {
        public async Task<Geoposition> HandeleAccessStatus(GeolocationAccessStatus accessStatus)
        {
            Geoposition geoposition = null;

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = 1000 };
                    geoposition = await geolocator.GetGeopositionAsync();
                    break;

                case GeolocationAccessStatus.Denied:
                    break;

                case GeolocationAccessStatus.Unspecified:
                    break;
            }
            return geoposition;
        }

        public async Task<MapAddress> GetCivilAddresByLocation(double latitude, double longtitude)
        {
            BasicGeoposition location = new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longtitude
            };

            Geopoint pointToReverseGeocode = new Geopoint(location);

            // Reverse geocode the specified geographic location.
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            MapAddress addres = null;

            if (result != null && result.Locations != null && result.Locations.Count > 0)
            {
                addres = result.Locations[0].Address;
            }

            return addres;
        }
    }
}
