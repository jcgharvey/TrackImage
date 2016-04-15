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

        public double X { get; set; }
        public double Y { get; set; }

        public static TrackPoint operator -(TrackPoint tp1, TrackPoint tp2)
        {
            return new TrackPoint(new Point(tp1.X - tp2.X, tp1.Y - tp2.Y), tp1.Elevation - tp2.Elevation);
        }

        public static TrackPoint operator /(TrackPoint tp1, TrackPoint tp2)
        {
            return new TrackPoint(new Point(tp1.X / tp2.X, tp1.Y / tp2.Y), tp1.Elevation / tp2.Elevation);
        }

        public Point Point {
            get
            {
                return new Point(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public double Elevation { get; set; }

        public int Hr { get; set; }
    }
}
