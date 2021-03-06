﻿using System;
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
            TrackPoint min = GetMin();

            TrackPoint scaleFactor = max - min;
            List <TrackPoint> normalizedPoints = new List<TrackPoint>();

            foreach (TrackPoint trackPoint in TrackPoints)
            {
                normalizedPoints.Add((trackPoint - min)/scaleFactor);
            }

            TrackPoints = normalizedPoints;
        }

        private TrackPoint GetMax()
        {
            double maxX = TrackPoints[0].Point.X;
            double maxY = TrackPoints[0].Point.Y;
            double maxElevation = TrackPoints[0].Elevation;

            foreach(TrackPoint tp in TrackPoints)
            {
                maxX = Math.Max(maxX, tp.Point.X);
                maxY = Math.Max(maxY, tp.Point.Y);
                maxElevation = Math.Max(maxElevation, tp.Elevation);
            }

            return new TrackPoint(maxX, maxY, maxElevation);
        }

        private TrackPoint GetMin()
        {
            double minX = TrackPoints[0].Point.X;
            double minY = TrackPoints[0].Point.Y;
            double minElevation = TrackPoints[0].Elevation;

            foreach (TrackPoint tp in TrackPoints)
            {
                minX = Math.Min(minX, tp.Point.X);
                minY = Math.Min(minY, tp.Point.Y);
                minElevation = Math.Min(minElevation, tp.Elevation);
            }

            return new TrackPoint(minX, minY, minElevation);
        }
    }
}
