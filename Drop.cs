using OpenTK;
using OpenTK.Graphics;
using storyboard.scriptslibrary.maniaModCharts.effects;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using static StorybrewScripts.Playfield;

namespace StorybrewScripts
{
    public class Drop : StoryboardObjectGenerator
    {

        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = 40606;
            var renderStart = 40607;
            var endtime = 66803;
            var duration = endtime - renderStart;

            // Playfield Scale
            var width = 250f;
            var height = 500f;

            // Note initilization Values
            var bpm = 146f;
            var offset = 1052;
            var sliderAccuracy = 30;

            // Drawinstance Values
            var updatesPerSecond = 30;
            var scrollSpeed = 900f;

            if (Beatmap.Name == "HARD MODE")
            {
                scrollSpeed = 750f;
            }

            if (Beatmap.Name == "EASY MODE")
            {
                scrollSpeed = 1050f;
            }


            var fadeTime = 50;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            for (int i = 0; i < 6; i++)
            {
                using (Playfield field = new Playfield())
                {
                    field.noteStart = 40000;

                    if(i != 0) {
                        endtime = 52010;
                    }

                    field.initilizePlayField(receptors, notes, starttime, endtime, width, -height, 50, Beatmap.OverallDifficulty);

                    if (i == 0)
                    {
                        field.noteEnd = 67627;
                    }

                    field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);
                    field.Scale(OsbEasing.None, starttime, starttime, new Vector2(0.45f, 0.45f));
                    //field.ZoomAndMove(starttime + 1, 0, OsbEasing.OutCirc, new Vector2(0.45f, 0.45f), new Vector2(0, -21.5f));

                    if (i == 1)
                    {
                        int[] timestamps = { 40916, 41325, 41736, 42147, 42558, 42969, 43380 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = 125f / 2;
                            ColumnType[] columns = { ColumnType.four, ColumnType.three, ColumnType.two, ColumnType.one };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 40916 && j > 0) break;
                                if (timestamp == 41325 && j > 1) break;
                                if (timestamp == 41736 && j > 2) break;

                                if (timestamp == 43380)
                                {
                                    moveValue = 125f;
                                }

                                // For the 42558, 42969, and 43380 timestamps, we move all columns by the same value
                                if (timestamp >= 42558)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 41736 && columns[j] == ColumnType.two) moveValue = 187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 3)
                    {
                        int[] timestamps = { 42558, 42969, 43380 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = 125f / 2;
                            ColumnType[] columns = { ColumnType.four, ColumnType.three, ColumnType.two, ColumnType.one };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 42558 && j > 0) break;
                                if (timestamp == 42969 && j > 1) break;

                                if (timestamp == 43380)
                                {
                                    moveValue = 125f;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 42969 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 43380 && columns[j] == ColumnType.two) moveValue = 250f;
                                if (timestamp == 43380 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 2)
                    {
                        int[] timestamps = { 40916, 41325, 41736, 42147, 42558, 42969, 43380 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 40916 && j > 0) break;
                                if (timestamp == 41325 && j > 1) break;
                                if (timestamp == 41736 && j > 2) break;

                                if (timestamp == 43380)
                                {
                                    moveValue = -125f;
                                }

                                // For the 42558, 42969, and 43380 timestamps, we move all columns by the same value
                                if (timestamp >= 42558)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 41736 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 4)
                    {
                        int[] timestamps = { 42558, 42969, 43380 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 42558 && j > 0) break;
                                if (timestamp == 42969 && j > 1) break;

                                if (timestamp == 43380)
                                {
                                    moveValue = -125f;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 42969 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 43380 && columns[j] == ColumnType.three) moveValue = -250f;
                                if (timestamp == 43380 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 5)
                    {
                        int[] timestamps = { 40916, 41325, 41736, 42147, 42558, 42969, 43380 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 40916 && j > 0) break;
                                if (timestamp == 41325 && j > 1) break;
                                if (timestamp == 41736 && j > 2) break;

                                if (timestamp == 43380)
                                {
                                    moveValue = -375f;
                                }

                                // For the 42558, 42969, and 43380 timestamps, we move all columns by the same value
                                if (timestamp >= 42558)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 41736 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.four) moveValue = -250f;
                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    flipColumn(field, 43791, 400, OsbEasing.OutCirc, ColumnType.all);

                    double currentTime = 44202;
                    double snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(OsbEasing.OutCirc, currentTime, currentTime + snapDuration, 250 / 4);
                        currentTime += snapDuration;
                    }

                    flipColumn(field, 47079, 400, OsbEasing.OutCirc, ColumnType.all);


                    currentTime = 47490;
                    snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(OsbEasing.OutCirc, currentTime, currentTime + snapDuration, -250 / 4);
                        currentTime += snapDuration;
                    }


                    if (i == 1)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51599, 51599 + 150, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51599, 51599 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51805, 51805 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 2)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51205, 51205 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51394, 51394 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51599, 51599 + 150, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 51599, 51599 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 51805, 51805 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 3)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 4)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50367, 50367 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50572, 50572 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 50778, 50778 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 50983, 50983 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (Beatmap.Name == "EVENT MODE")
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 52010, 52010 + 50, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52010 + 50, 52010 + 50 + 50, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52079, 52079 + 50, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52079 + 50, 52079 + 50 + 50, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52147, 52147 + 50, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52147 + 50, 52147 + 50 + 50, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52216, 52216 + 100, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52216 + 100, 52216 + 100 + 100, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52319, 52319 + 100, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52319 + 100, 52319 + 100 + 100, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52421, 52421 + 100, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52421 + 100, 52421 + 100 + 100, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52627, 52627 + 150, new Vector2(0, -25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52627 + 150, 52627 + 150 + 150, new Vector2(0, 25), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52832, 52832 + 150, new Vector2(0, -25), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52832 + 150, 52832 + 150 + 150, new Vector2(0, 25), ColumnType.one);
                    }
                    else if (Beatmap.Name == "EASY MODE")
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 52010, 52112, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52112, 52215, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52215, 52318, new Vector2(0, -25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52318, 52420, new Vector2(0, 25), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52420, 52523, new Vector2(0, -25), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52523, 52626, new Vector2(0, 25), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52626, 52729, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52729, 52831, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52831, 52934, new Vector2(0, -25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52934, 53037, new Vector2(0, 25), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 53037, 53140, new Vector2(0, -25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 53140, 53140, new Vector2(0, 25), ColumnType.three);
                    }
                    else if (Beatmap.Name == "HARD MODE")
                    {
                        var delay = 75;
                        var lDelay = 150;
                        var shortJ = 20;
                        var longJ = 40;

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52010, 52010 + delay, new Vector2(0, -shortJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52010 + delay, 52010 + delay + delay, new Vector2(0, shortJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52079, 52079 + delay, new Vector2(0, -shortJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52079 + delay, 52079 + delay + delay, new Vector2(0, shortJ), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52147, 52147 + delay, new Vector2(0, -shortJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52147 + delay, 52147 + delay + delay, new Vector2(0, shortJ), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52216, 52216 + delay, new Vector2(0, -shortJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52216 + delay, 52216 + delay + delay, new Vector2(0, shortJ), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52319, 52319 + delay, new Vector2(0, -shortJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52319 + delay, 52319 + delay + delay, new Vector2(0, shortJ), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52421, 52421 + lDelay, new Vector2(0, -longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52421 + lDelay, 52421 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 52421, 52421 + lDelay, new Vector2(0, -longJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52421 + lDelay, 52421 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52627, 52627 + lDelay, new Vector2(0, -longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52627 + lDelay, 52627 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 52627, 52627 + lDelay, new Vector2(0, -longJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52627 + lDelay, 52627 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 52832, 52832 + lDelay, new Vector2(0, -longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52832 + lDelay, 52832 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 52832, 52832 + lDelay, new Vector2(0, -longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 52832 + lDelay, 52832 + lDelay + lDelay, new Vector2(0, longJ), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 53038, 53038 + lDelay, new Vector2(0, -longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 53038 + lDelay, 53243 - 25, new Vector2(0, longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 53038, 53038 + lDelay, new Vector2(0, -longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 53038 + lDelay, 53243 - 25, new Vector2(0, longJ), ColumnType.two);
                    }

                    if(i == 0) {

                    flipColumn(field, 53243, 400, OsbEasing.OutCirc, ColumnType.all);

                    field.Rotate(OsbEasing.OutCirc, 54271, 54271 + 100, Math.PI / 32, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54373, 54373 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54476, 54476 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54579, 54579 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54682, 54682 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54784, 54784 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54887, 54887 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 54990, 54990 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 55093, 55093 + 100, Math.PI / 32, CenterType.receptor);

                    field.Rotate(OsbEasing.OutCirc, 56017, 56017 + 100, Math.PI / 32, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56120, 56120 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56223, 56223 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56325, 56325 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56428, 56428 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56531, 56531 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56634, 56634 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56736, 56736 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 56839, 56839 + 100, Math.PI / 32, CenterType.receptor);

                    field.Rotate(OsbEasing.OutCirc, 57558, 57558 + 100, Math.PI / 32, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 57661, 57661 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 57764, 57764 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 57867, 57867 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 57969, 57969 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 58072, 58072 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 58175, 58175 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 58278, 58278 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 58380, 58380 + 100, Math.PI / 32, CenterType.receptor);

                    field.Rotate(OsbEasing.OutCirc, 58586, 58586 + 100, Math.PI / 32, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 58791, 58791 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 59312, 59312 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 59510, 59510 + 100, -Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 59613, 59613 + 100, Math.PI / 16, CenterType.receptor);
                    field.Rotate(OsbEasing.OutCirc, 59716, 59716 + 100, -Math.PI / 32, CenterType.receptor);

                    field.RotateReceptorRelative(OsbEasing.None, 60024, 60230 - 60024, Math.PI * 2);

                    flipColumn(field, 60024, 100, OsbEasing.OutCirc, ColumnType.one);
                    flipColumn(field, 60127, 100, OsbEasing.OutCirc, ColumnType.two);
                    flipColumn(field, 60230, 100, OsbEasing.OutCirc, ColumnType.three);
                    flipColumn(field, 60332, 100, OsbEasing.OutCirc, ColumnType.four);

                    field.MoveOriginRelative(OsbEasing.None, 60846, 60846 + 0, new Vector2(200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 60846, 60846 + 0, new Vector2(-200, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 60846, 60846 + 250, new Vector2(-200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 60846, 60846 + 250, new Vector2(200, 0), ColumnType.all);

                    field.MoveOriginRelative(OsbEasing.None, 61257, 61257 + 0, new Vector2(-100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 61257, 61257 + 0, new Vector2(100, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 61257, 61257 + 150, new Vector2(100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 61257, 61257 + 150, new Vector2(-100, 0), ColumnType.all);

                    field.MoveOriginRelative(OsbEasing.None, 61462, 61462 + 0, new Vector2(100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 61462, 61462 + 0, new Vector2(-100, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 61462, 61462 + 150, new Vector2(-100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 61462, 61462 + 150, new Vector2(100, 0), ColumnType.all);

                    field.RotateReceptorRelative(OsbEasing.OutSine, 61873, 62079, Math.PI * 2);

                    field.MoveOriginRelative(OsbEasing.None, 62490, 62490 + 0, new Vector2(-200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 62490, 62490 + 0, new Vector2(200, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 62490, 62490 + 250, new Vector2(200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 62490, 62490 + 250, new Vector2(-200, 0), ColumnType.all);

                    field.MoveOriginRelative(OsbEasing.None, 62901, 62901 + 0, new Vector2(100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 62901, 62901 + 0, new Vector2(-100, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 62901, 62901 + 150, new Vector2(-100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 62901, 62901 + 150, new Vector2(100, 0), ColumnType.all);

                    field.MoveOriginRelative(OsbEasing.None, 63106, 63106 + 0, new Vector2(-100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 63106, 63106 + 0, new Vector2(100, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 63106, 63106 + 150, new Vector2(100, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 63106, 63106 + 150, new Vector2(-100, 0), ColumnType.all);

                    field.RotatePlayFieldStatic(OsbEasing.OutSine, 63517, 63723, Math.PI * 2);

                    field.MoveOriginRelative(OsbEasing.None, 64339, 64339 + 0, new Vector2(200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.None, 64339, 64339 + 0, new Vector2(-200, 0), ColumnType.all);
                    field.MoveOriginRelative(OsbEasing.OutSine, 64339, 64339 + 600, new Vector2(-200, 0), ColumnType.all);
                    field.MoveReceptorRelative(OsbEasing.OutSine, 64339, 64339 + 600, new Vector2(200, 0), ColumnType.all);


                    double half = 200;
                    double full = 400;
                    currentTime = 65161;
                    float movement = 75;


                    //1
                    field.moveField(OsbEasing.None, 65161, 65161, 0, -height * 0.1f);
                    field.Scale(OsbEasing.None, 65161, 65161, new Vector2(0.6f, 0.6f));
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65161, 65161 + half, new Vector2(movement, 0), ColumnType.four);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65161 + half, 65161 + full, new Vector2(-movement, 0), ColumnType.four);

                    //2
                    field.moveField(OsbEasing.None, 65572, 65572, 0, -height * 0.1f);
                    field.Scale(OsbEasing.None, 65572, 65572, new Vector2(0.7f, 0.7f));
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65572, 65572 + half, new Vector2(-movement, 0), ColumnType.one);
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65572, 65572 + half, new Vector2(-movement, 0), ColumnType.two);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65572 + half, 65572 + full, new Vector2(movement, 0), ColumnType.one);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65572 + half, 65572 + full, new Vector2(movement, 0), ColumnType.two);

                    //3
                    field.moveField(OsbEasing.None, 65983, 65983, 0, -height * 0.1f);
                    field.Scale(OsbEasing.None, 65983, 65983, new Vector2(0.8f, 0.8f));
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65983, 65983 + half, new Vector2(movement, 0), ColumnType.two);
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65983, 65983 + half, new Vector2(movement, 0), ColumnType.three);
                    field.MoveColumnRelative(OsbEasing.OutCirc, 65983, 65983 + half, new Vector2(movement, 0), ColumnType.four);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65983 + half, 65983 + full, new Vector2(-movement, 0), ColumnType.two);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65983 + half, 65983 + full, new Vector2(-movement, 0), ColumnType.three);
                    field.MoveColumnRelative(OsbEasing.InCirc, 65983 + half, 65983 + full, new Vector2(-movement, 0), ColumnType.four);

                    //4
                    field.moveField(OsbEasing.None, 66393, 66394, 0, -height * 0.2f);
                    field.Scale(OsbEasing.None, 66394, 66394, new Vector2(1f, 1f));
                    field.moveFieldX(OsbEasing.OutCirc, 66394, 66394 + half, -movement);
                    field.moveFieldX(OsbEasing.InCirc, 66394 + half, 66394 + full, movement);

                }

                DrawInstance draw = new DrawInstance(field, 40914, scrollSpeed, updatesPerSecond, OsbEasing.None, false, fadeTime, fadeTime);
                //draw.changeUpdateRate(53243, 50);
                draw.setHoldRotationPrecision(0f);
                draw.setNoteRotationPrecision(0f);
                draw.setNoteMovementPrecision(1f);
                if (i == 0)
                    draw.drawViaEquation(duration, NoteFunction, true);
                else if (i == 5)
                    draw.drawViaEquation(49742 - starttime, NoteFunction, true);
                else
                    draw.drawViaEquation(51907 - starttime, NoteFunction, true);
            }
        }
    }
    public Vector2 NoteFunction(EquationParameters parameters)
    {
        float y = parameters.position.Y;
        float x = parameters.position.X;

        if (parameters.time > 53346 && parameters.time < 65161)
        {
            x += (float)Utility.SineWaveValue(30, 1, parameters.progress);
        }

        return new Vector2(x, y);
    }

    public void flipColumn(Playfield field, double starttime, double duration, OsbEasing easing, ColumnType type)
    {
        foreach (Column currentColumn in field.columns.Values.ToList())
        {

            if (currentColumn.type == type || type == ColumnType.all)
            {

                Vector2 receptorPos = currentColumn.ReceptorPositionAt(starttime);
                Vector2 originPos = currentColumn.OriginPositionAt(starttime);
                Vector2 center = new Vector2(427, 240);

                // Calculate the change needed to flip the positions
                Vector2 changeReceptorPos = (center - receptorPos) * 2;
                Vector2 changeOriginPos = (center - originPos) * 2;

                currentColumn.receptor.MoveReceptorRelativeY(easing, starttime, starttime + duration, changeReceptorPos.Y);
                currentColumn.origin.MoveOriginRelativeY(easing, starttime, starttime + duration, changeOriginPos.Y);
            }

        }
    }
}
}

