using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows;

namespace TrackImage
{
    class Program
    {
        static void Main(string[] args)
        {
            String filepath = @"D:\OneDrive\Orienteering\Events\US Champs 2016\Sprint.gpx";

            StringBuilder output = new StringBuilder();

            Track track = new Track();

            using (XmlReader reader = XmlReader.Create(filepath))
            {
                XmlWriterSettings ws = new XmlWriterSettings();
                ws.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(output, ws))
                {

                    // Parse the file and display each of the nodes.
                    while (ConsumeTillNextTrkpt(reader))
                    {
                        TrackPoint tp = GetTrackPointAtReader(reader);
                        track.AddPoint(tp);
                    }

                }
            }

            track.Normalize();

            foreach(TrackPoint tp in track.TrackPoints)
            {
                Console.WriteLine(string.Format("X: {0} Y: {1} Ele: {2}", tp.Point.X, tp.Point.Y, tp.Elevation));
            }

            Console.ReadLine();
        }

        private static TrackPoint GetTrackPointAtReader(XmlReader reader)
        {
            String xStr = reader.GetAttribute("lon");
            String yStr = reader.GetAttribute("lat");
            
            Point p = new Point(Double.Parse(xStr), Double.Parse(yStr));

            ConsumeTillElement(reader, "ele");

            double elevation = Double.Parse(reader.ReadInnerXml());

            return new TrackPoint(p, elevation);
        }

        private static bool ConsumeTillNextTrkpt(XmlReader reader)
        {
            return ConsumeTillElement(reader, "trkpt");
        }

        private static bool ConsumeTillElement(XmlReader reader, string elementName)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.LocalName == elementName)
                    return true;
            }
            return false;
        }
    }
}
