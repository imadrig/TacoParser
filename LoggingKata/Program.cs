﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Runtime.InteropServices;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            if( lines.Length == 0 ) 
            {
                logger.LogError("There are zero lines");
            }
            else
            {
                if( lines.Length == 1 )
                {
                    logger.LogWarning("Warning! There is only 1 line.");
                }
            }

            
            // Create a new instance of your TacoParser class
            TacoParser parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance - DONE
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double distance;
            double newDistance;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`


            //HINT NESTED LOOPS SECTION---------------------



            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`) - DONE
            

            for (int i = 0; i < locations.Length; i++) 
            {
                locations[i] = tacoBell1;
            }

            // Create a new corA Coordinate with your locA's lat and long - DONE
            var corA = new GeoCoordinate(tacoBell1.Location.Latitude , tacoBell1.Location.Longitude);

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`) - DONE

            for (int i = 0; i < locations.Length; i++)
            {
                locations[i] = tacoBell2;
            }

            // Create a new Coordinate with your locB's lat and long - DONE
            var corB = new GeoCoordinate(tacoBell2.Location.Latitude, tacoBell2.Location.Longitude);

            // Now, compare the two using `.GetDistanceTo()`, which returns a double - DONE
            distance = corA.GetDistanceTo(corB);
            newDistance = distance;
            ITrackable newTacoBell1 = null;
            ITrackable newTacoBell2 = null;

            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            if ( distance > newDistance )
            {
                newDistance = distance;
                tacoBell1 = newTacoBell1;
                tacoBell2 = newTacoBell2;
            }
            Console.WriteLine(distance);

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.



        }
    }
}
