using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackImage
{
    class Track
    {
        public Track()
        {
            this.TrackPoints = new List<TrackPoint>();
        }

        public Track(int capacity)
        {
            this.TrackPoints = new List<TrackPoint>(capacity);
        }

        public List<TrackPoint> TrackPoints { get; set; }

        public void AddPoint(TrackPoint tp)
        {
            this.TrackPoints.Add(tp);
        }

        public void Normalize()
        {
            TrackPoint max = GetMax();
        }

        private TrackPoint GetMax()
        {
            
            TrackPoint max = TrackPoints[0];

            foreach(TrackPoint tp in TrackPoints)
            {
                max.Point.X = Math.Max(max.Point.X, tp.Point.X);

            }

            /*
            [9:59:41 PM] Dave Carpenter: max = points[0]
            [9:59:50 PM] Dave Carpenter: for (tp in points)
            {
            [10:00:21 PM] Dave Carpenter: tp.x = max(max.x, tp.x)
            [10:00:27 PM] Dave Carpenter: ... for y and ele ...
            [10:00:28 PM] Dave Carpenter: }
            */
        }
    }
}
