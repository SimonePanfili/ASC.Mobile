using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Mobile.Common.Models
{
    public class Position : IEquatable<Position>
    {
        public static readonly Position Unknown = new Position();

        public double? Latitude { get; private set; }

        public double? Longitude { get; private set; }

        public static Position Create(double latitude, double longitude)
        {
            if (latitude == 0 && longitude == 0)
                return null;

            return new Position
            {
                Latitude = latitude,
                Longitude = longitude,
            };
        }

        public override int GetHashCode() => (int)Latitude ^ (int)Longitude;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Position))
                return false;

            var other = (Position)obj;
            return this.Latitude == other.Latitude && this.Longitude == other.Longitude;
        }

        public bool Equals(Position other)
            => other != null && this.Latitude == other.Latitude && this.Longitude == other.Longitude;

        // Equality operator.
        public static bool operator ==(Position x, Position y)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(x, y))
                return true;

            // If one is null, but not both, return false.
            if (((object)x == null) || ((object)y == null))
                return false;

            // Return true if the fields match:
            return x.Latitude == y.Latitude && x.Longitude == y.Longitude;
        }

        // Inequality operator.
        public static bool operator !=(Position x, Position y) => !(x == y);
    }
}
