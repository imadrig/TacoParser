using LoggingKata;
using System.Security.Cryptography.X509Certificates;


namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogError("Somgthing went wrong! Need more information.");
                return null; // TODO Implement - DONE
            }

            // grab the latitude from your array at index 0 - DONE
            double latitude = double.Parse(cells[0]);

            // grab the longitude from your array at index 1 - DONE
            double longitude = double.Parse(cells[1]);

            // grab the name from your array at index 2 - DONE
            string name = cells[2];

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`


            // You'll need to create a TacoBell class
            // that conforms to ITrackable - DONE



            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly - DONE
            TacoBell tacoBell = new TacoBell()
            {
                Name = name,
                Location = new Point { Longitude = longitude, Latitude = latitude }

            };


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable - DONE

            return tacoBell;
        }


        public class TacoBell : ITrackable
        {
            public string Name { get; set; }
            public Point Location { get; set; }
        }
    }
}