using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using StorybrewCommon.Animations;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class Start : StoryboardObjectGenerator
    {
        Playfield field;

        private double lastPhaseX = 0; // To keep track of last phase value for X (Cosine)
        private double lastPhaseY = Math.PI / 2; // Start at the top point for Y (Sine)


        public override void Generate()
        {
            var receptors = GetLayer("r");
            var notes = GetLayer("n");

            // General values
            var starttime = -2500;
            var endtime = 41017;
            var duration = endtime - starttime - 500;

            // Playfield Scale
            var width = 250f;
            var height = 500f;

            // Note initilization Values
            var bpm = 146f;
            var offset = 1052;
            var sliderAccuracy = 30;

            // Drawinstance Values
            var updatesPerSecond = 100;
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

            Playfield field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, -591, 1051, width, -2500, 0, Beatmap.OverallDifficulty);
            field2.noteEnd = 8000;
            field2.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);
            field2.moveFieldY(OsbEasing.None, -590, -590, 850);
            field2.Scale(OsbEasing.OutCirc, -590, -590, new Vector2(0.1f, .1f));


            DrawInstance draw2 = new DrawInstance(field2, -489, 8000, 30, OsbEasing.None, false, 250, 0);
            draw2.setHoldRotationPrecision(0);
            draw2.drawViaEquation(1051 + 489, NoteFunction2, true, false);

            field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, width, -height, 50, Beatmap.OverallDifficulty);
            field.noteEnd = 41736;
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);
            field.Scale(OsbEasing.OutCirc, -785, 50, new Vector2(0.1f, 0.1f));
            field.moveFieldY(OsbEasing.OutCirc, 1052, 1052 + 500, -150);
            field.Scale(OsbEasing.OutCirc, 1052, 1052 + 500, new Vector2(0.7f, 0.7f));

            double currentTime = 1668;
            double interval = 100;
            double currentRotation = Math.PI / 16;
            float currentScale = field.columns[ColumnType.one].ReceptorScaleAt(currentTime).X;

            for (int i = 0; i < 5; i++)
            {
                currentRotation *= -1;
                currentScale -= 0.05f;
                double localRotation = currentRotation;

                field.moveFieldY(OsbEasing.OutCirc, currentTime, currentTime + interval / 6, 30);

                if (i > 0)
                {
                    localRotation = currentRotation * 2;
                }
                if (i < 5)
                {
                    field.Rotate(OsbEasing.OutCirc, currentTime, currentTime + interval / 6, localRotation);
                }
                field.Scale(OsbEasing.OutCirc, currentTime, currentTime, new Vector2(currentScale, currentScale));
                currentTime += interval;
            }

            // Reset playfield rotation
            field.Rotate(OsbEasing.OutCirc, currentTime, currentTime + interval / 6, -currentRotation);


            field.Resize(OsbEasing.OutCirc, 2695, 2901, 600, -height);
            field.Resize(OsbEasing.OutCirc, 2901, 3309, 250, -height);
            field.Resize(OsbEasing.OutCirc, 3309, 3517, 600, -height);
            field.Resize(OsbEasing.OutSine, 3517, 3928, 250, -height);

            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4339, 4339 + 50, -field.getColumnWidth(width) * 2, ColumnType.four);
            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4339, 4339 + 50, field.getColumnWidth(width) * 2, ColumnType.two);

            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4750, 4750 + 50, -field.getColumnWidth(width) * 2, ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4750, 4750 + 50, field.getColumnWidth(width) * 2, ColumnType.four);

            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4956, 4956 + 50, -field.getColumnWidth(width) * 3, ColumnType.four);
            field.MoveColumnRelativeX(OsbEasing.InOutSine, 4956, 4956 + 50, field.getColumnWidth(width) * 3, ColumnType.one);

            field.MoveColumnRelativeX(OsbEasing.InOutSine, 5161, 5161 + 50, -field.getColumnWidth(width) * 3, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.InOutSine, 5161, 5161 + 50, field.getColumnWidth(width) * 3, ColumnType.four);


            field.MoveOriginRelative(OsbEasing.OutCirc, 6599, 6599 + 100, new Vector2(-150, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutCirc, 6599, 6599 + 100, new Vector2(150, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 6805, 6805 + 250, new Vector2(150, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 6805, 6805 + 250, new Vector2(-150, 0), ColumnType.all);

            field.RotateReceptorRelative(OsbEasing.OutSine, 7421, 7729, Math.PI * 2);

            field.Resize(OsbEasing.OutCirc, 7216, 7216 + 200, 600, -height);
            field.Resize(OsbEasing.OutCirc, 7421, 7421 + 200, 250, -height);


            field.MoveOriginRelative(OsbEasing.None, 8265, 8265, new Vector2(200, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 8265, 8265, new Vector2(-200, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 8266, 8266 + 250, new Vector2(-200, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 8266, 8266 + 250, new Vector2(200, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 8654, 8654, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 8654, 8654, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 8655, 8655 + 150, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 8655, 8655 + 150, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 8860, 8860, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 8860, 8860, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 8860, 8860 + 150, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 8860, 8860 + 150, new Vector2(100, 0), ColumnType.all);

            field.RotateReceptorRelative(OsbEasing.OutSine, 9065, 9065 + 300, Math.PI * 2);


            field.MoveOriginRelative(OsbEasing.None, 9887, 9887, new Vector2(200, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 9887, 9887, new Vector2(-200, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 9887, 9887 + 250, new Vector2(-200, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 9887, 9887 + 250, new Vector2(200, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 10298, 10298, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 10298, 10298, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 10298, 10298 + 150, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 10298, 10298 + 150, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 10504, 10504, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 10504, 10504, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 10504, 10504 + 100, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 10504, 10504 + 100, new Vector2(100, 0), ColumnType.all);

            field.RotateReceptorRelative(OsbEasing.OutSine, 10606, 10606 + 300, Math.PI * 2);

            field.MoveOriginRelative(OsbEasing.None, 11736, 11736, new Vector2(-150, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.None, 11736, 11736, new Vector2(150, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 11736, 11736 + 500, new Vector2(150, 0), ColumnType.all);
            field.MoveReceptorRelative(OsbEasing.OutSine, 11736, 11736 + 500, new Vector2(-150, 0), ColumnType.all);


            double half = 200;
            double full = half * 2;
            currentTime = 12558;
            float movement = 75;
            float localHeight = height;

            //1
            localHeight = height / 0.6f;
            field.moveField(OsbEasing.None, 12557, 12557, 0, -height * 0.15f);
            field.Scale(OsbEasing.None, 12557, 12557, new Vector2(0.6f, 0.6f));
            field.MoveColumnRelative(OsbEasing.OutCirc, 12558, 12558 + half, new Vector2(movement, 0), ColumnType.four);
            field.MoveColumnRelative(OsbEasing.InCirc, 12558 + half, 12558 + full, new Vector2(-movement, 0), ColumnType.four);

            //2
            localHeight = height / 0.6f;
            field.moveField(OsbEasing.None, 12968, 12968, 0, -height * 0.1f);
            field.Scale(OsbEasing.None, 12968, 12968, new Vector2(0.7f, 0.7f));
            field.MoveColumnRelative(OsbEasing.OutCirc, 12969, 12969 + half, new Vector2(-movement, 0), ColumnType.one);
            field.MoveColumnRelative(OsbEasing.OutCirc, 12969, 12969 + half, new Vector2(-movement, 0), ColumnType.two);
            field.MoveColumnRelative(OsbEasing.InCirc, 12969 + half, 12969 + full, new Vector2(movement, 0), ColumnType.one);
            field.MoveColumnRelative(OsbEasing.InCirc, 12969 + half, 12969 + full, new Vector2(movement, 0), ColumnType.two);

            //3
            field.moveField(OsbEasing.None, 13379, 13379, 0, -height * 0.1f);
            field.Scale(OsbEasing.None, 13379, 13379, new Vector2(0.8f, 0.8f));
            field.MoveColumnRelative(OsbEasing.OutCirc, 13380, 13380 + half, new Vector2(movement, 0), ColumnType.two);
            field.MoveColumnRelative(OsbEasing.OutCirc, 13380, 13380 + half, new Vector2(movement, 0), ColumnType.three);
            field.MoveColumnRelative(OsbEasing.OutCirc, 13380, 13380 + half, new Vector2(movement, 0), ColumnType.four);
            field.MoveColumnRelative(OsbEasing.InCirc, 13380 + half, 13380 + full, new Vector2(-movement, 0), ColumnType.two);
            field.MoveColumnRelative(OsbEasing.InCirc, 13380 + half, 13380 + full, new Vector2(-movement, 0), ColumnType.three);
            field.MoveColumnRelative(OsbEasing.InCirc, 13380 + half, 13380 + full, new Vector2(-movement, 0), ColumnType.four);

            //4
            field.moveField(OsbEasing.None, 13790, 13790, 0, -height * 0.2f);
            field.Scale(OsbEasing.None, 13790, 13790, new Vector2(1f, 1f));
            field.moveFieldX(OsbEasing.OutCirc, 13791, 13791 + half, -movement);
            field.moveFieldX(OsbEasing.InCirc, 13791 + half, 13791 + full, movement);

            field.Scale(OsbEasing.None, 14202, 14202, new Vector2(0.45f, 0.45f));
            field.moveField(OsbEasing.None, 14202, 14202, 0, height * .56f);


            var localDuration = 820;
            currentTime = 14202;
            movement = 250;

            for (int i = 0; i < 3; i++)
            {
                field.RotateReceptorRelative(OsbEasing.OutSine, currentTime, currentTime + localDuration, Math.PI * 2);
                field.moveFieldX(OsbEasing.OutSine, currentTime, currentTime + localDuration, movement);
                currentTime += localDuration;
                field.RotateReceptorRelative(OsbEasing.InSine, currentTime, currentTime + localDuration, -Math.PI * 2);
                field.moveFieldX(OsbEasing.InSine, currentTime, currentTime + localDuration, -movement);
                currentTime += localDuration;
                field.RotateReceptorRelative(OsbEasing.OutSine, currentTime, currentTime + localDuration, -Math.PI * 2);
                field.moveFieldX(OsbEasing.OutSine, currentTime, currentTime + localDuration, -movement);
                currentTime += localDuration;
                field.RotateReceptorRelative(OsbEasing.InSine, currentTime, currentTime + localDuration, Math.PI * 2);
                field.moveFieldX(OsbEasing.InSine, currentTime, currentTime + localDuration, movement);
                currentTime += localDuration;
            }

            //ApplyYSineToPlayField(14202, 25709);

            field.RotateReceptorRelative(OsbEasing.OutSine, currentTime, currentTime + localDuration, Math.PI * 2);
            field.moveFieldX(OsbEasing.OutSine, currentTime, currentTime + localDuration, movement);
            currentTime += localDuration;
            field.RotateReceptorRelative(OsbEasing.InSine, currentTime, currentTime + localDuration, -Math.PI * 2);
            field.moveFieldX(OsbEasing.InSine, currentTime, currentTime + localDuration, -movement);


            field.Resize(OsbEasing.OutCirc, 25709, 25709 + 200, width, -height + 150);
            field.moveFieldY(OsbEasing.OutCirc, 25709, 25709 + 200, -70);

            field.Resize(OsbEasing.OutCirc, 26017, 26017 + 200, width, -height + 300);
            field.moveFieldY(OsbEasing.OutCirc, 26017, 26017 + 200, -100);

            field.Resize(OsbEasing.OutCirc, 26325, 26325 + 200, width, height);
            field.moveFieldY(OsbEasing.OutCirc, 26325, 26325 + 200, -185);

            field.Resize(OsbEasing.InSine, 26531, 26942, width, 0);
            field.Resize(OsbEasing.OutCirc, 26942, 27353, width, height);
            field.RotateReceptorRelative(OsbEasing.OutCirc, 26942, 27353, Math.PI * 2f, ColumnType.all);

            flipColumn(29921, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(30024, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(30127, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(30230, 200, OsbEasing.OutCirc, ColumnType.one);

            flipColumn(33517, 33928 - 33517, OsbEasing.OutSine, ColumnType.all);

            flipColumn(36394, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(36497, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(36599, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(36702, 200, OsbEasing.OutCirc, ColumnType.one);


            ApplySineToPlayField(27353, 40093);

            field.Scale(OsbEasing.InOutSine, 40093, 40452, new Vector2(.8f, 0.8f));
            field.Rotate(OsbEasing.InOutSine, 40093, 40452, .4, CenterType.middle);
            field.moveField(OsbEasing.InOutSine, 40093, 40452, -50, -200);

            field.ScaleColumn(OsbEasing.InSine, 40503, 40914, new Vector2(0.5f), ColumnType.all);

            field.MoveReceptorAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(226.25f, 430), ColumnType.one);
            field.MoveReceptorAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(288.75f, 430), ColumnType.two);
            field.MoveReceptorAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(351.25f, 430), ColumnType.three);
            field.MoveReceptorAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(413.75f, 430), ColumnType.four);

            field.MoveOriginAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(226.25f, -70), ColumnType.one);
            field.MoveOriginAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(288.75f, -70), ColumnType.two);
            field.MoveOriginAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(351.25f, -70), ColumnType.three);
            field.MoveOriginAbsolute(OsbEasing.InSine, 40503, 40914, new Vector2(413.75f, -70), ColumnType.four);

            DrawInstance draw = new DrawInstance(field, 1051, scrollSpeed, updatesPerSecond, OsbEasing.None, false, fadeTime, fadeTime);
            //draw.addSV(8038, 2);
            draw.setNoteRotationPrecision(0f);
            draw.setNoteMovementPrecision(0f);
            draw.setHoldRotationPrecision(0f);
            Log(draw.drawViaEquation(duration - 200, NoteFunction, true));

        }

        public Vector2 NoteFunction2(EquationParameters parameters)
        {
            return parameters.position;
        }

        public Vector2 NoteFunction(EquationParameters parameters)
        {
            float x = parameters.position.X;
            float y = parameters.position.Y;
            double currentTime = parameters.time;
            float t = parameters.progress;

            if (currentTime > 2695 && currentTime < 3106 && t < 0.8)
            {
                float duration = 3106 - 2695;
                float relativeT = ((float)currentTime - 2695) / duration;
                x += (float)Utility.SineWaveValue(100, 1, relativeT);
            }

            if (currentTime > 3312 && currentTime < 3723 && t < 0.8)
            {
                float duration = 3723 - 3312;
                float relativeT = ((float)currentTime - 3312) / duration;
                x -= (float)Utility.SineWaveValue(100, 1, relativeT);
            }

            if (currentTime > 5572 && currentTime < 6599)
            {
                double start = 5572;
                double end = 6599;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 0;
                double endAmplitude = 100;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime > 9065 && currentTime < 9887)
            {
                x += ZigZagPath((float)t, 40);
            }

            if (currentTime > 10606 && currentTime < 11634)
            {
                x += ZigZagPath((float)t, 25);
            }

            if (currentTime > 11942 && currentTime < 12558)
            {
                x += ZigZagPath((float)t);
            }

            if (currentTime > 26942 && currentTime < 40093)
            {
                // Determine amplitude for the sine wave
                double currentAmplitude;

                // If within the first time range
                if (currentTime <= 27353)
                {
                    double start = 26942;
                    double end = 27300;  // Ending before the second segment starts

                    // Calculate progress in the range of [0, 1]
                    double progress = (currentTime - start) / (end - start);

                    // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                    double startAmplitude = 0;
                    double endAmplitude = 25;
                    currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);
                }
                else
                {
                    // If within the second time range, the amplitude is constant
                    currentAmplitude = 25;
                }

                // Apply the changes to x and y
                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);

                if (currentTime <= 27353)
                {
                    y -= (float)Utility.CosWaveValue(currentAmplitude, 0.75, t);
                }
                else
                {
                    y -= (float)Utility.CosWaveValue(currentAmplitude, 0.75, t);
                }
            }


            return new Vector2(x, y);
        }

        public void flipColumn(double starttime, double duration, OsbEasing easing, ColumnType type)
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

        public float ZigZagPath(float t, float wiggle = 25)
        {

            if (t < 0 || t > 1) // Out of range
                return 0; // or whatever default value you'd like


            if (t < 0.25f)
                return 25;
            else if (t < 0.375f)
                return -25;
            else if (t < 0.625f)
                return 25;
            else if (t < 0.75f)
                return -25;
            else
                return 0;
        }


        public void ApplySineToPlayField(double starttime, double endtime)
        {

            int count = 1;
            double stepDuration = 20;
            double frequencyX = 0.1;
            double frequencyY = 0.2;

            while (starttime < endtime - stepDuration)
            {
                OsbEasing easing = OsbEasing.None;

                // Using cosine for x-axis 
                float x = (float)Utility.CosWaveValue(6, frequencyX, lastPhaseX);

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.SineWaveValue(1.5, frequencyY, lastPhaseY);

                field.moveField(easing, starttime, starttime + stepDuration, x, y);

                lastPhaseX += frequencyX;
                lastPhaseY += frequencyX;
                starttime += stepDuration;
                count++;
            }
        }

        public void ApplyYSineToPlayField(double starttime, double endtime)
        {

            int count = 1;
            double stepDuration = 40;
            double frequencyX = 0.1;
            double frequencyY = 0.1;
            double phase = 0;

            while (starttime < endtime - stepDuration)
            {
                OsbEasing easing = OsbEasing.None;

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.CosWaveValue(1, frequencyY, phase);

                field.moveField(easing, starttime, starttime + stepDuration, 0, y);

                phase += frequencyX;
                starttime += stepDuration;
                count++;
            }
        }


    }
}
