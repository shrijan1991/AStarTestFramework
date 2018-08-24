using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarTestFramework
{
    /// <summary>
    /// Coordinate class stores 2-D (x and y) coordinates.
    /// </summary>
    public class Coordinate
    {
        private Coordinate _start;

        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public Coordinate(Coordinate _copyCoordinate) : this(_copyCoordinate.X, _copyCoordinate.Y)
        {
        }

        /// <summary>
        /// Compare coordinates of two Coordinate class objects
        /// </summary>
        /// <param name="_compCoordinate"> Object of coordinate class to compare to </param>
        /// <returns></returns>
        public bool Equals(Coordinate _compCoordinate) {
            return Equals(_compCoordinate.X, _compCoordinate.Y);
        }

        /// <summary>
        /// Compare coordinates with a given x and y value
        /// </summary>
        /// <param name="_x">x coordinate to compare to</param>
        /// <param name="_y">y coordinate to compare to</param>
        /// <returns></returns>
        public bool Equals(int _x, int _y)
        {
            return (X == _x && Y == _y);
        }

        public override string ToString()
        {
            return "( " + X + " , " + Y +" )";
        }
        public string delimitedString()
        {
            return "( " + X + " \",\" " + Y + " )";
        }

    }
}
