using System;
using Xamarin.Essentials;

namespace eVehicleStartupLog.Extensions
{
    public static class PlaceMarkExtensions
    {
        public static string GetDisplayAddress(this Placemark placemark)
        {
            return $"{placemark.CountryCode}-{placemark.PostalCode} {placemark.Locality} {placemark.Thoroughfare}";
        }
    }
}
