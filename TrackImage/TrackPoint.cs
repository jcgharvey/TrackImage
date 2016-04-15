using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TrackImage
{
    class TrackPoint
    {
        public TrackPoint(double x, double y, double elevation)
        {
            this.Point = new Point(x, y);
            this.Elevation = elevation;
        }
        
        public TrackPoint(Point p, double elevation)
        {
            this.Point = p;
            this.Elevation = elevation;
        }

        public TrackPoint(Point p, double elevation, int hr) : this(p, elevation)
        {
            this.Hr = hr;
        }

        public Point Point { get; set; }

        public double Elevation { get; set; }

        public int Hr { get; set; }
    }
}
