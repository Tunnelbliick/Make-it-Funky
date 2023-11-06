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
            var starttime = 106462;
            var renderStart = 106565;
            var endtime = 121873;
            var duration = endtime - renderStart;

            // Playfield Scale
            var width = 250f;
            var height = -550f;

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

                    field.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);
                    field.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, false, sliderAccuracy);

                    field.noteStart = 106565 - 1000;

                    if (i == 0)
                    {
                        field.noteEnd = 117764;
                    }

                    field.ScalePlayField(starttime, 0, OsbEasing.None, width, height);
                    field.ZoomAndMove(starttime + 1, 0, OsbEasing.OutCirc, new Vector2(0.45f, 0.45f), new Vector2(0, -24.5f));

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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.three) moveValue = 125;
                                if (timestamp == 107490 && columns[j] == ColumnType.two) moveValue = 187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.one) moveValue = 250f;

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 107490 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.four) moveValue = -250f;

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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

                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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
                                    field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
                                    continue;
                                }

                                // Adjust the moveValue for specific timestamps and columns
                                if (timestamp == 107079 && columns[j] == ColumnType.two) moveValue = -125;
                                if (timestamp == 107490 && columns[j] == ColumnType.three) moveValue = -187.5f;
                                if (timestamp == 107901 && columns[j] == ColumnType.four) moveValue = -250f;
                                field.MoveColumnRelative(timestamp, 200, OsbEasing.OutCirc, new Vector2(moveValue, 0), columns[j]);
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
                        field.moveFieldX(currentTime, snapDuration, OsbEasing.OutCirc, 250 / 4);

                        if (didHop)
                        {
                            field.moveField(currentTime, 0, OsbEasing.OutCirc, 0, -15);
                            field.moveField(currentTime + snapDuration / 2, snapDuration / 2, OsbEasing.InSine, 0, 15);
                            field.RotatePlayFieldStatic(currentTime, snapDuration / 2, OsbEasing.OutSine, Math.PI);
                        }

                        didHop = !didHop;

                        currentTime += snapDuration;
                    }

                    if (didHop)
                    {
                        field.RotatePlayFieldStatic(currentTime, 0, OsbEasing.OutSine, Math.PI);
                    }

                    flipColumn(field, 112832, 400, OsbEasing.OutCirc, ColumnType.all);


                    currentTime = 113243;
                    snapDuration = 44613 - 44202;
                    for (int n = 0; n <= 6; n++)
                    {
                        field.moveFieldX(currentTime, snapDuration, OsbEasing.OutCirc, -250 / 4);

                        if (didHop)
                        {
                            field.moveField(currentTime, 0, OsbEasing.OutCirc, 0, 15);
                            field.moveField(currentTime + snapDuration / 2, snapDuration / 2, OsbEasing.InSine, 0, -15);
                            field.RotatePlayFieldStatic(currentTime + 1, snapDuration / 2, OsbEasing.OutSine, -3.1415);
                        }

                        didHop = !didHop;
                        currentTime += snapDuration;
                    }

                    if (didHop)
                    {
                        field.columns.Values.ToList().ForEach((col) => Log($"{i} - {col.type} - {col.getReceptorRotation(currentTime)}"));
                        field.RotatePlayFieldStatic(currentTime + 100, 100, OsbEasing.None, -Math.PI);
                    }


                    if (i == 1)
                    {
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.one);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(117353, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(117353, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(117558, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 2)
                    {
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.four);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116942, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(117147, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(117353, 150, OsbEasing.OutCirc, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(117353, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(117558, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 3)
                    {
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 4, 0), ColumnType.one);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 3, 0), ColumnType.two);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 2, 0), ColumnType.three);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);

                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(-62.5f * 1, 0), ColumnType.four);
                    }

                    if (i == 4)
                    {
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 4, 0), ColumnType.four);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.three);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116120, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 3, 0), ColumnType.three);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.two);
                        field.MoveColumnRelative(116325, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 2, 0), ColumnType.two);
                        field.MoveColumnRelative(116531, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);

                        field.MoveColumnRelative(116736, 150, OsbEasing.OutCirc, new Vector2(62.5f * 1, 0), ColumnType.one);
                    }

                    if (i == 0)
                    {
                        field.MoveColumnRelative(117764, 50, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(117764 + 50, 50, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(117867, 50, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(117867 + 50, 50, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(117918, 50, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(117918 + 50, 50, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(117969, 100, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(117969 + 100, 100, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(118072, 100, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.four);
                        field.MoveColumnRelative(118072 + 100, 100, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.four);

                        field.MoveColumnRelative(118175, 100, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.two);
                        field.MoveColumnRelative(118175 + 100, 100, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.two);

                        field.MoveColumnRelative(118380, 150, OsbEasing.OutCirc, new Vector2(0, 25), ColumnType.three);
                        field.MoveColumnRelative(118380 + 150, 150, OsbEasing.InCirc, new Vector2(0, -25), ColumnType.three);
                    }

                    field.ZoomAndMove(118997 - 150, 150, OsbEasing.OutCirc, new Vector2(0.8f, 0.8f), new Vector2(0, 350));

                    field.Zoom(118997, 150, OsbEasing.OutCirc, new Vector2(0.8f, 0.0f), true);
                    field.PlayFieldChangeWidth(118997, 150, OsbEasing.OutCirc, 0);

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

        public Vector2 NoteFunction(Vector2 position, double currentTime, double t)
        {
            float y = position.Y;
            float x = position.X;

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



