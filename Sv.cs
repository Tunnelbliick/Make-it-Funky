using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StorybrewScripts
{
    public class SVTrigger
    {
        public double StartTime { get; set; }
        public double Value { get; set; }
    }

    public class Sv : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            // Example list of HitObjects
            List<OsuHitObject> hitObjects = Beatmap.HitObjects.ToList();

            List<SVTrigger> svTriggers = new List<SVTrigger>();
            HashSet<double> processedStartTimes = new HashSet<double>();
            double[] svValues = { -10000, -10 };
            int svIndex = 0;

            foreach (var hitObject in hitObjects)
            {
                if (!processedStartTimes.Contains(hitObject.StartTime))
                {
                    svTriggers.Add(new SVTrigger
                    {
                        StartTime = hitObject.StartTime,
                        Value = svValues[svIndex]
                    });

                    processedStartTimes.Add(hitObject.StartTime);
                    svIndex = 1 - svIndex; // Alternate between 0 and 1
                }
            }

            string logDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");

            // Ensure that the log directory exists
            Directory.CreateDirectory(logDirectoryPath);

            // Define the full path for the log file
            string logFilePath = Path.Combine(logDirectoryPath, "sv.log");

            // For demonstration purposes, print the SVTriggers
            foreach (var svTrigger in svTriggers)
            {
                File.AppendAllText(logFilePath, $"{svTrigger.StartTime},{svTrigger.Value},4,2,0,20,0,0{Environment.NewLine}" );
            }

        }
    }
}
