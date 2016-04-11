using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackImage
{
    class GPXParser
    {
        private Track track;
        public GPXParser(String filePath)
        {
            ParseXml();
        }

        private void ParseXml()
        {

        }

        public Track GetTrack()
        {
            return track;
        }
    }
}
