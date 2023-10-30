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
            var height = 550f;

            // Note initilization Values
            var bpm = 146f;
            var offset = 1052;
            var sliderAccuracy = 30;

            // Drawinstance Values
            var updatesPerSecond = 30;
            var scrollSpeed = 900f;
            var fadeTime = 50;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            for (int i = 0; i < 6; i++)
            {
                using (Playfield field = new Playfield())
                {
                    field.noteStart = 40000;

                    field.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);

                    if (i == 0)
                    {
                        field.noteEnd = 67627;
                    }

                    field.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, false, sliderAccuracy);
                    field.ScalePlayField(starttime, 0, OsbEasing.None, width, height);
                    field.ZoomAndMove(starttime + 1, 0, OsbEasing.OutCirc, new Vector2(0.45f, 0.45f), new Vector2(0, -21.5f));

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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 41736 && columns[j] == ColumnType.two) moveValue = 187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 41736 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 41325 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 41736 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 42147 && columns[j] == ColumnType.four) moveValue = -250f;
                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    flipColumn(field, 43791, 400, OsbEasing.OutCirc, ColumnType.all);

                    double currentTime = 44202;
                    double snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(currentTime, snapDuration, OsbEasing.OutCirc, 250 / 4);
                        currentTime += snapDuration;
                    }

                    flipColumn(field, 47079, 400, OsbEasing.OutCirc, ColumnType.all);


                    currentTime = 47490;
                    snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(currentTime, snapDuration, OsbEasing.OutCirc, -250 / 4);
                        currentTime += snapDuration;
                    }

                    if (i == 1)
                    {
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(51599, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(51599, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(51805, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 2)
                    {
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(51205, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(51394, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(51599, 150, OsbEasing.OutCirc, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(51599, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(51805, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 3)
                    {
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 4)
                    {
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50367, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(50572, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(50778, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(50983, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 0)
                    {
                        field.MoveColumnRelative(52010, 50, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(52010 + 50, 50, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(52079, 50, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(52079 + 50, 50, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(52147, 50, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(52147 + 50, 50, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(52216, 100, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(52216 + 100, 100, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(52319, 100, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.four);
                        field.MoveColumnRelative(52319 + 100, 100, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.four);

                        field.MoveColumnRelative(52421, 100, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.two);
                        field.MoveColumnRelative(52421 + 100, 100, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.two);

                        field.MoveColumnRelative(52627, 150, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.three);
                        field.MoveColumnRelative(52627 + 150, 150, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.three);

                        field.MoveColumnRelative(52832, 150, OsbEasing.OutCirc, new Vector2(0, -25), ColumnType.one);
                        field.MoveColumnRelative(52832 + 150, 150, OsbEasing.InCirc, new Vector2(0, 25), ColumnType.one);

                        flipColumn(field, 53243, 400, OsbEasing.OutCirc, ColumnType.all);

                        field.RotatePlayField(54271, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);
                        field.RotatePlayField(54373, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54476, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54579, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54682, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54784, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54887, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(54990, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(55093, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);

                        field.RotatePlayField(56017, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);
                        field.RotatePlayField(56120, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56223, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56325, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56428, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56531, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56634, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56736, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(56839, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);

                        field.RotatePlayField(57558, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);
                        field.RotatePlayField(57661, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(57764, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(57867, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(57969, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(58072, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(58175, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(58278, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(58380, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);

                        field.RotatePlayField(58586, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);
                        field.RotatePlayField(58791, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(59312, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(59510, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(59613, 100, OsbEasing.OutCirc, Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(59716, 100, OsbEasing.OutCirc, -Math.PI / 16, 20, CenterType.receptor);
                        field.RotatePlayField(59828, 100, OsbEasing.OutCirc, Math.PI / 32, 20, CenterType.receptor);

                        field.RotatePlayFieldStatic(60024, 60230 - 60024, OsbEasing.None, Math.PI * 2);

                        flipColumn(field, 60024, 100, OsbEasing.OutCirc, ColumnType.one);
                        flipColumn(field, 60127, 100, OsbEasing.OutCirc, ColumnType.two);
                        flipColumn(field, 60230, 100, OsbEasing.OutCirc, ColumnType.three);
                        flipColumn(field, 60332, 100, OsbEasing.OutCirc, ColumnType.four);

                        field.MoveOriginRelative(60846, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
                        field.MoveReceptorRelative(60846, 0, OsbEasing.None, new Vector2(-200, 0), ColumnType.all);
                        field.MoveOriginRelative(60846, 250, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);
                        field.MoveReceptorRelative(60846, 250, OsbEasing.OutSine, new Vector2(200, 0), ColumnType.all);

                        field.MoveOriginRelative(61257, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
                        field.MoveReceptorRelative(61257, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
                        field.MoveOriginRelative(61257, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);
                        field.MoveReceptorRelative(61257, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

                        field.MoveOriginRelative(61462, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
                        field.MoveReceptorRelative(61462, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
                        field.MoveOriginRelative(61462, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);
                        field.MoveReceptorRelative(61462, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);

                        field.RotatePlayFieldStatic(61876, 60230 - 60024, OsbEasing.None, Math.PI * 2);

                        field.MoveOriginRelative(62490, 0, OsbEasing.None, new Vector2(-200, 0), ColumnType.all);
                        field.MoveReceptorRelative(62490, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
                        field.MoveOriginRelative(62490, 250, OsbEasing.OutSine, new Vector2(200, 0), ColumnType.all);
                        field.MoveReceptorRelative(62490, 250, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);

                        field.MoveOriginRelative(62901, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
                        field.MoveReceptorRelative(62901, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
                        field.MoveOriginRelative(62901, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);
                        field.MoveReceptorRelative(62901, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);

                        field.MoveOriginRelative(63106, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
                        field.MoveReceptorRelative(63106, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
                        field.MoveOriginRelative(63106, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);
                        field.MoveReceptorRelative(63106, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

                        field.RotatePlayFieldStatic(63517, 60230 - 60024, OsbEasing.None, Math.PI * 2);

                        field.MoveOriginRelative(64339, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
                        field.MoveReceptorRelative(64339, 0, OsbEasing.None, new Vector2(-200, 0), ColumnType.all);
                        field.MoveOriginRelative(64339, 600, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);
                        field.MoveReceptorRelative(64339, 600, OsbEasing.OutSine, new Vector2(200, 0), ColumnType.all);


                        double half = 200;
                        currentTime = 12558;
                        float movement = 75;

                        //1
                        field.ZoomAndMove(65161, 0, OsbEasing.None, new Vector2(0.6f, 0.6f), new Vector2(0, -100));
                        field.MoveColumnRelative(65161, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.four);
                        field.MoveColumnRelative(65161 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.four);

                        //2
                        field.ZoomAndMove(65572, 0, OsbEasing.None, new Vector2(0.7f, 0.7f), new Vector2(0, -50));
                        field.MoveColumnRelative(65572, half, OsbEasing.OutCirc, new Vector2(-movement, 0), ColumnType.one);
                        field.MoveColumnRelative(65572, half, OsbEasing.OutCirc, new Vector2(-movement, 0), ColumnType.two);
                        field.MoveColumnRelative(65572 + half, half, OsbEasing.InCirc, new Vector2(movement, 0), ColumnType.one);
                        field.MoveColumnRelative(65572 + half, half, OsbEasing.InCirc, new Vector2(movement, 0), ColumnType.two);

                        //3
                        field.ZoomAndMove(65983, 0, OsbEasing.None, new Vector2(0.8f, 0.8f), new Vector2(0, -50));
                        field.MoveColumnRelative(65983, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.two);
                        field.MoveColumnRelative(65983, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.three);
                        field.MoveColumnRelative(65983, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.four);
                        field.MoveColumnRelative(65983 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.two);
                        field.MoveColumnRelative(65983 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.three);
                        field.MoveColumnRelative(65983 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.four);

                        //4
                        field.ZoomAndMove(66394, 0, OsbEasing.None, new Vector2(1f, 1f), new Vector2(0, -90));
                        field.moveFieldX(66394, half, OsbEasing.OutCirc, -movement);
                        field.moveFieldX(66394 + half, half, OsbEasing.InCirc, movement);
                    }

                    DrawInstance draw = new DrawInstance(field, renderStart, scrollSpeed, updatesPerSecond, OsbEasing.None, false, fadeTime, fadeTime);
                    //draw.changeUpdateRate(53243, 50);
                    draw.setNoteRotationPrecision(0f);
                    draw.setNoteMovementPrecision(1f);
                    if (i == 0)
                        draw.drawViaEquation(duration, NoteFunction, true);
                    else if (i == 5)
                        draw.drawViaEquation(49742 - starttime, NoteFunction, true);
                    else
                        draw.drawViaEquation(52010 - starttime, NoteFunction, true);
                }
            }
        }

        public Vector2 NoteFunction(Vector2 position, double currentTime, double t)
        {
            float y = position.Y;
            float x = position.X;

            /*x += (float)Utility.SineWaveValue(40, 1, t);
            if ((currentTime > 0 && currentTime < 43791) || (currentTime > 47079 && currentTime < 53243))
                y += (float)Utility.CosWaveValue(200, 0.75, t);
            else
                y -= (float)Utility.CosWaveValue(200, 0.75, t);*/

            if (currentTime > 53346 && currentTime < 65161)
            {
                x += (float)Utility.SineWaveValue(30, 1, t);
            }

            return new Vector2(x, y);
        }

        public void flipColumn(Playfield field, double starttime, double duration, OsbEasing easing, ColumnType type)
        {
            foreach (Column currentColumn in field.columns.Values.ToList())
            {

                if (currentColumn.type == type || type == ColumnType.all)
                {

                    Vector2 receptorPos = currentColumn.getReceptorPosition(starttime);
                    Vector2 originPos = currentColumn.getOriginPosition(starttime);
                    Vector2 center = new Vector2(receptorPos.X, 240);

                    Vector2 flippedReceptorPos = center + (center - receptorPos);
                    Vector2 flippedOriginPos = center + (center - originPos);

                    currentColumn.receptor.MoveReceptor(starttime, flippedReceptorPos, easing, duration);
                    currentColumn.origin.MoveOrigin(starttime, flippedOriginPos, easing, duration);
                }

            }
        }
    }
}
