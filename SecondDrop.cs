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
using System.Diagnostics;
using System.Linq;

namespace StorybrewScripts
{
    public class SecondDrop : StoryboardObjectGenerator
    {

        public override void Generate()
        {
            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = 106565;
            var renderStart = 106668;
            var endtime = 121873;
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

                    field.initilizePlayField(receptors, notes, starttime, endtime, width, height, 50, Beatmap.OverallDifficulty);
                    field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);

                    field.noteStart = 106565 - 1000;

                    if (i == 0)
                    {
                        field.noteEnd = 117764;
                    }

                    //field.ScalePlayField(starttime, 0, OsbEasing.None, width, height);
                    //field.ZoomAndMove(starttime + 1, 0, OsbEasing.OutCirc, new Vector2(0.45f, 0.45f), new Vector2(0, -24.5f));

                    if (i == 1)
                    {
                        int[] timestamps = { 106668, 107079, 107490, 107901, 108312, 108723, 109134 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = 125f / 2;
                            ColumnType[] columns = { ColumnType.four, ColumnType.three, ColumnType.two, ColumnType.one };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 106668 && j > 0) break;
                                if (timestamp == 107079 && j > 1) break;
                                if (timestamp == 107490 && j > 2) break;

                                if (timestamp == 109134)
                                {
                                    moveValue = 125f;
                                }

                                // For the 108312, 108723, and 109134 timestamps, we move all columns by the same value
                                if (timestamp >= 108312)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 107490 && columns[j] == ColumnType.two) moveValue = 187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 3)
                    {
                        int[] timestamps = { 108312, 108723, 109134 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = 125f / 2;
                            ColumnType[] columns = { ColumnType.four, ColumnType.three, ColumnType.two, ColumnType.one };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 108312 && j > 0) break;
                                if (timestamp == 108723 && j > 1) break;

                                if (timestamp == 109134)
                                {
                                    moveValue = 125f;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 108723 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 109134 && columns[j] == ColumnType.two) moveValue = 250f;
                                if (timestamp == 109134 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 2)
                    {
                        int[] timestamps = { 106668, 107079, 107490, 107901, 108312, 108723, 109134 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 106668 && j > 0) break;
                                if (timestamp == 107079 && j > 1) break;
                                if (timestamp == 107490 && j > 2) break;

                                if (timestamp == 109134)
                                {
                                    moveValue = -125f;
                                }

                                // For the 108312, 108723, and 109134 timestamps, we move all columns by the same value
                                if (timestamp >= 108312)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 107490 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 4)
                    {
                        int[] timestamps = { 108312, 108723, 109134 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 108312 && j > 0) break;
                                if (timestamp == 108723 && j > 1) break;

                                if (timestamp == 109134)
                                {
                                    moveValue = -125f;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 108723 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 109134 && columns[j] == ColumnType.three) moveValue = -250f;
                                if (timestamp == 109134 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    if (i == 5)
                    {
                        int[] timestamps = { 106668, 107079, 107490, 107901, 108312, 108723, 109134 };

                        foreach (int timestamp in timestamps)
                        {
                            float moveValue = -125f / 2;
                            ColumnType[] columns = { ColumnType.one, ColumnType.two, ColumnType.three, ColumnType.four };

                            for (int j = 0; j < 4; j++)
                            {
                                if (timestamp == 106668 && j > 0) break;
                                if (timestamp == 107079 && j > 1) break;
                                if (timestamp == 107490 && j > 2) break;

                                if (timestamp == 109134)
                                {
                                    moveValue = -375f;
                                }

                                // For the 108312, 108723, and 109134 timestamps, we move all columns by the same value
                                if (timestamp >= 108312)
                                {
                                    field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 107490 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.four) moveValue = -250f;
                                field.MoveColumnRelative(OsbEasing.OutCirc, timestamp, timestamp + 200, new Vector2(moveValue, 0), columns[j]);
                            }
                        }
                    }

                    bool didHop = false;

                    switch (i)
                    {
                        case 0:
                            didHop = false;
                            break;
                        case 1:
                            didHop = false;
                            break;
                        case 2:
                            didHop = false;
                            break;
                        case 3:
                            didHop = true;
                            break;
                        case 4:
                            didHop = true;
                            break;
                        case 5:
                            didHop = true;
                            break;
                    }


                    flipColumn(field, 109545, 400, OsbEasing.OutCirc, ColumnType.all);

                    double currentTime = 109956;
                    double snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(OsbEasing.OutCirc, currentTime, currentTime + snapDuration, 250 / 4);

                        if (didHop)
                        {
                            field.moveFieldY(OsbEasing.OutCirc, currentTime, currentTime, -15);
                            field.moveFieldY(OsbEasing.InSine, currentTime + snapDuration / 2, currentTime + snapDuration, 15);
                            field.RotatePlayFieldStatic(OsbEasing.OutSine, currentTime, currentTime + snapDuration / 2, Math.PI);
                        }

                        didHop = !didHop;

                        currentTime += snapDuration;
                    }

                    if (didHop)
                    {
                        field.RotatePlayFieldStatic(OsbEasing.OutSine, currentTime, currentTime, Math.PI);
                    }

                    flipColumn(field, 112832, 400, OsbEasing.OutCirc, ColumnType.all);


                    currentTime = 113243;
                    snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(OsbEasing.OutCirc, currentTime, currentTime + snapDuration, -250 / 4);

                        if (didHop)
                        {
                            field.moveFieldY(OsbEasing.OutCirc, currentTime, 0, 15);
                            field.moveFieldY(OsbEasing.InSine, currentTime + snapDuration / 2, currentTime + snapDuration, -15);
                            field.RotatePlayFieldStatic(OsbEasing.OutSine, currentTime, currentTime + snapDuration / 2, -Math.PI);
                        }

                        didHop = !didHop;
                        currentTime += snapDuration;
                    }

                    if (didHop)
                    {
                        //field.columns.Values.ToList().ForEach((col) => Log($"{i} - {col.type} - {col.getReceptorRotation(currentTime)}"));
                        field.RotatePlayFieldStatic(OsbEasing.None, currentTime + 100, currentTime + 200, -Math.PI);
                    }


                    if (i == 1)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117353, 117353 + 150, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117353, 117353 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117558, 117558 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 2)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116942, 116942 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117147, 117147 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117353, 117353 + 150, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117353, 117353 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117558, 117558 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 3)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 4)
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116120, 116120 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116325, 116325 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 116531, 116531 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 116736, 116736 + 150, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (Beatmap.Name == "EVENT MODE")
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117764, 117764 + 50, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117764 + 50, 117764 + 100, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117867, 117867 + 50, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117867 + 50, 117867 + 100, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117918, 117918 + 50, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117918 + 50, 117918 + 100, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117969, 117969 + 100, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117969 + 100, 117969 + 200, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118072, 118072 + 100, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118072 + 100, 118072 + 200, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118175, 118175 + 100, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118175 + 100, 118175 + 200, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118380, 118380 + 150, new Vector2(0, 25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118380 + 150, 118380 + 300, new Vector2(0, -25), ColumnType.three);
                    }
                    else if (Beatmap.Name == "EASY MODE")
                    {
                        field.MoveColumnRelative(OsbEasing.OutCirc, 117763, 117866, new Vector2(0, 25), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117866, 117968, new Vector2(0, -25), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117968, 118071, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118071, 118174, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118174, 118277, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118277, 118379, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118379, 118482, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118482, 118585, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118585, 118687, new Vector2(0, 25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118687, 118790, new Vector2(0, -25), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118790, 118893, new Vector2(0, 25), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118893, 118996, new Vector2(0, -25), ColumnType.three);
                    }
                    else if (Beatmap.Name == "HARD MODE")
                    {
                        var delay = 75;
                        var lDelay = 150;
                        var shortJ = 20;
                        var longJ = 40;

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117764, 117764 + delay, new Vector2(0, shortJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117764 + delay, 117764 + delay + delay, new Vector2(0, -shortJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117832, 117832 + delay, new Vector2(0, shortJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117832 + delay, 117832 + delay + delay, new Vector2(0, -shortJ), ColumnType.three);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117901, 117901 + delay, new Vector2(0, shortJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117901 + delay, 117901 + delay + delay, new Vector2(0, -shortJ), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 117969, 117969 + delay, new Vector2(0, shortJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 117969 + delay, 117969 + delay + delay, new Vector2(0, -shortJ), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118072, 118072 + delay, new Vector2(0, shortJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118072 + delay, 118072 + delay + delay, new Vector2(0, -shortJ), ColumnType.two);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118175, 118175 + lDelay, new Vector2(0, longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118175 + lDelay, 118175 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 118175, 118175 + lDelay, new Vector2(0, longJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118175 + lDelay, 118175 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118380, 118380 + lDelay, new Vector2(0, longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118380 + lDelay, 118380 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 118380, 118380 + lDelay, new Vector2(0, longJ), ColumnType.four);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118380 + lDelay, 118380 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.four);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118586, 118586 + lDelay, new Vector2(0, longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118586 + lDelay, 118586 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.three);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 118586, 118586 + lDelay, new Vector2(0, longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118586 + lDelay, 118586 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.one);

                        field.MoveColumnRelative(OsbEasing.OutCirc, 118791, 118791 + lDelay, new Vector2(0, longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118791 + lDelay, 118791 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.one);
                        field.MoveColumnRelative(OsbEasing.OutCirc, 118791, 118791 + lDelay, new Vector2(0, longJ), ColumnType.two);
                        field.MoveColumnRelative(OsbEasing.InCirc, 118791 + lDelay, 118791 + lDelay + lDelay, new Vector2(0, -longJ), ColumnType.two);
                    }


                    field.moveFieldY(OsbEasing.OutCirc, 118997 - 150, 118997, 210);
                    field.Scale(OsbEasing.OutCirc, 118997 - 150, 118997, new Vector2(0.8f, 0.8f));
                    field.Scale(OsbEasing.OutCirc, 118997, 118997 + 150, new Vector2(0.8f, 0.0f), true);
                    field.Resize(OsbEasing.OutCirc, 118997, 118997 + 150, 0, height);

                    DrawInstance draw = new DrawInstance(field, renderStart, scrollSpeed, updatesPerSecond, OsbEasing.None, false, fadeTime, fadeTime);
                    //draw.changeUpdateRate(53243, 50);
                    draw.setNoteRotationPrecision(0f);
                    draw.setNoteMovementPrecision(1f);
                    if (i == 0)
                        draw.drawViaEquation(duration, NoteFunction, true);
                    else if (i == 5)
                        draw.drawViaEquation(114476 - starttime, NoteFunction, true);
                    else
                        draw.drawViaEquation(117661 - starttime, NoteFunction, true);

                }
            }
        }

        public Vector2 NoteFunction(EquationParameters parm)
        {
            float y = parm.position.Y;
            float x = parm.position
            .X;

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



