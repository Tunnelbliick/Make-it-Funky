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
            var endtime = 40606;
            var duration = endtime - starttime;

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
            var fadeTime = 50;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            Playfield field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, -591, 1052, receportWidth, 60, 0);
            field2.noteEnd = 5000;
            field2.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, false, sliderAccuracy);
            field2.ScalePlayField(-591, 0, OsbEasing.None, width, 2500);
            field2.moveField(-591 + 1, 0, OsbEasing.None, 0, -20);
            field2.ZoomAndMove(-591 + 2, 50, OsbEasing.OutCirc, new Vector2(0.1f, .1f), new Vector2(0, -200));

            DrawInstance draw2 = new DrawInstance(field2, -489, 5000, 30, OsbEasing.None, false, 250, 0);
            draw2.drawNotesByOriginToReceptor(1050 + 489, true);

            field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);
            field.noteEnd = 43120;
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, false, sliderAccuracy);
            field.ScalePlayField(starttime, 0, OsbEasing.None, width, height);
            field.moveField(starttime + 1, 0, OsbEasing.None, 0, -20);
            field.ZoomAndMove(starttime + 2, 0, OsbEasing.OutCirc, new Vector2(0.1f, 0.1f), new Vector2(0, 200));
            field.ZoomAndMove(1052, 500, OsbEasing.OutCirc, new Vector2(1f, 1f), new Vector2(0, -850));

            double currentTime = 1668;
            double interval = 100;
            double currentRotation = Math.PI / 16;
            float currentScale = 1f;

            for (int i = 0; i < 5; i++)
            {
                currentRotation *= -1;
                currentScale -= 0.1f;
                double localRotation = currentRotation;

                if (i > 0)
                {
                    localRotation = currentRotation * 2;
                }
                field.RotatePlayField(currentTime, 0, OsbEasing.None, localRotation, 1);
                field.ZoomAndMove(currentTime + 1, 0, OsbEasing.None, new Vector2(currentScale, currentScale), new Vector2(0, 50));
                currentTime += interval;
            }

            field.RotatePlayField(currentTime, 0, OsbEasing.None, -currentRotation, 1);
            field.PlayFieldChangeWidth(2695, 2901 - 2695, OsbEasing.OutCirc, 600);
            field.PlayFieldChangeWidth(2901, 3309 - 2901, OsbEasing.OutCirc, 250);
            field.PlayFieldChangeWidth(3309, 3517 - 3309, OsbEasing.OutCirc, 600);
            field.PlayFieldChangeWidth(3517, 3928 - 3517, OsbEasing.OutSine, 250);

            PlayFieldEffect columnSwap = new PlayFieldEffect(field, 4339, 4339 + 50, OsbEasing.InOutSine, 10);
            columnSwap.SwapColumn(ColumnType.four, ColumnType.two);
            PlayFieldEffect columnSwap2 = new PlayFieldEffect(field, 4750, 4750 + 50, OsbEasing.InOutSine, 10);
            columnSwap2.SwapColumn(ColumnType.two, ColumnType.four);
            PlayFieldEffect columnSwap3 = new PlayFieldEffect(field, 4956, 4956 + 50, OsbEasing.InOutSine, 10);
            columnSwap3.SwapColumn(ColumnType.four, ColumnType.one);
            PlayFieldEffect columnSwap4 = new PlayFieldEffect(field, 5161, 5161 + 50, OsbEasing.InOutSine, 10);
            columnSwap4.SwapColumn(ColumnType.one, ColumnType.four);

            field.MoveOriginRelative(6599, 50, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(6599, 50, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(6805, 250, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(6805, 250, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

            field.RotatePlayFieldStatic(7421, 300, OsbEasing.None, Math.PI * 2);

            field.PlayFieldChangeWidth(7216, 200, OsbEasing.OutCirc, 600);
            field.PlayFieldChangeWidth(7421, 200, OsbEasing.OutCirc, 250);

            field.MoveOriginRelative(8265, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
            field.MoveReceptorRelative(8265, 0, OsbEasing.None, new Vector2(-200, 0), ColumnType.all);
            field.MoveOriginRelative(8266, 250, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);
            field.MoveReceptorRelative(8266, 250, OsbEasing.OutSine, new Vector2(200, 0), ColumnType.all);

            field.MoveOriginRelative(8654, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(8654, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(8655, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(8655, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(8860, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(8860, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(8860, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(8860, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);

            field.RotatePlayFieldStatic(9065, 300, OsbEasing.None, Math.PI * 2);


            field.MoveOriginRelative(9887, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
            field.MoveReceptorRelative(9887, 0, OsbEasing.None, new Vector2(-200, 0), ColumnType.all);
            field.MoveOriginRelative(9887, 250, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);
            field.MoveReceptorRelative(9887, 250, OsbEasing.OutSine, new Vector2(200, 0), ColumnType.all);

            field.MoveOriginRelative(10298, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(10298, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(10298, 150, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(10298, 150, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(10504, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveReceptorRelative(10504, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(10504, 100, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);
            field.MoveReceptorRelative(10504, 100, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);

            field.RotatePlayFieldStatic(10606, 300, OsbEasing.None, Math.PI * 2);

            field.MoveOriginRelative(11736, 0, OsbEasing.None, new Vector2(-150, 0), ColumnType.all);
            field.MoveReceptorRelative(11736, 0, OsbEasing.None, new Vector2(150, 0), ColumnType.all);
            field.MoveOriginRelative(11736, 500, OsbEasing.OutSine, new Vector2(150, 0), ColumnType.all);
            field.MoveReceptorRelative(11736, 500, OsbEasing.OutSine, new Vector2(-150, 0), ColumnType.all);

            double half = 200;
            currentTime = 12558;
            float movement = 75;

            //1
            field.ZoomAndMove(12557, 0, OsbEasing.None, new Vector2(0.6f, 0.6f), new Vector2(0, -50));
            field.MoveColumnRelative(12558, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.four);
            field.MoveColumnRelative(12558 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.four);

            //2
            field.ZoomAndMove(12968, 0, OsbEasing.None, new Vector2(0.7f, 0.7f), new Vector2(0, -50));
            field.MoveColumnRelative(12969, half, OsbEasing.OutCirc, new Vector2(-movement, 0), ColumnType.one);
            field.MoveColumnRelative(12969, half, OsbEasing.OutCirc, new Vector2(-movement, 0), ColumnType.two);
            field.MoveColumnRelative(12969 + half, half, OsbEasing.InCirc, new Vector2(movement, 0), ColumnType.one);
            field.MoveColumnRelative(12969 + half, half, OsbEasing.InCirc, new Vector2(movement, 0), ColumnType.two);

            //3
            field.ZoomAndMove(13379, 0, OsbEasing.None, new Vector2(0.8f, 0.8f), new Vector2(0, -50));
            field.MoveColumnRelative(13380, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.two);
            field.MoveColumnRelative(13380, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.three);
            field.MoveColumnRelative(13380, half, OsbEasing.OutCirc, new Vector2(movement, 0), ColumnType.four);
            field.MoveColumnRelative(13380 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.two);
            field.MoveColumnRelative(13380 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.three);
            field.MoveColumnRelative(13380 + half, half, OsbEasing.InCirc, new Vector2(-movement, 0), ColumnType.four);

            //4
            field.ZoomAndMove(13790, 0, OsbEasing.None, new Vector2(1f, 1f), new Vector2(0, -90));
            field.moveFieldX(13791, half, OsbEasing.OutCirc, -movement);
            field.moveFieldX(13791 + half, half, OsbEasing.InCirc, movement);

            var localDuration = 820;
            currentTime = 14202;
            movement = 250;

            field.ZoomAndMove(14202, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), new Vector2(0, 290));

            for (int i = 0; i < 3; i++)
            {
                field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.OutSine, Math.PI * 2);
                field.moveField(currentTime, localDuration, OsbEasing.OutSine, movement, 0);
                currentTime += localDuration;
                field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.InSine, -Math.PI * 2);
                field.moveField(currentTime, localDuration, OsbEasing.InSine, -movement, 0);
                currentTime += localDuration;
                field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.OutSine, -Math.PI * 2);
                field.moveField(currentTime, localDuration, OsbEasing.OutSine, -movement, 0);
                currentTime += localDuration;
                field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.InSine, Math.PI * 2);
                field.moveField(currentTime, localDuration, OsbEasing.InSine, movement, 0);
                currentTime += localDuration;
            }

            field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.OutSine, Math.PI * 2);
            field.moveField(currentTime, localDuration, OsbEasing.OutSine, movement, 0);
            currentTime += localDuration;
            field.RotatePlayFieldStatic(currentTime, localDuration, OsbEasing.InSine, -Math.PI * 2);
            field.moveField(currentTime, localDuration, OsbEasing.InSine, -movement, 0);

            field.MoveReceptorRelative(25709, 200, OsbEasing.OutCirc, new Vector2(0, -50), ColumnType.all);
            field.MoveReceptorRelative(26017, 200, OsbEasing.OutCirc, new Vector2(0, -100), ColumnType.all);
            field.MoveReceptorRelative(26325, 200, OsbEasing.OutCirc, new Vector2(0, -200), ColumnType.all);
            field.MoveOriginRelative(25709, 200, OsbEasing.OutCirc, new Vector2(0, 50), ColumnType.all);
            field.MoveOriginRelative(26325, 200, OsbEasing.OutCirc, new Vector2(0, height - 50), ColumnType.all);

            ApplySineToPlayField(26942, 29921);

            flipColumn(29921, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(30024, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(30127, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(30230, 200, OsbEasing.OutCirc, ColumnType.one);

            ApplySineToPlayField(30230 + 200, 33517);

            flipColumn(33517, 33928 - 33517, OsbEasing.OutSine, ColumnType.all);

            ApplySineToPlayField(33928, 36394);

            flipColumn(36394, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(36497, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(36599, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(36702, 200, OsbEasing.OutCirc, ColumnType.one);

            ApplySineToPlayField(36702 + 200, 40093);

            field.ZoomMoveAndRotate(40093, 40504 - 40093 - 50, OsbEasing.OutSine, new Vector2(1f, 1f), new Vector2(-50, -50), Math.PI / 7, 50);
            field.Zoom(40504, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), true);
            field.ScalePlayField(40504, 100, OsbEasing.OutSine, 225, 500);

            Log(field.columns[ColumnType.one].origin.getCurrentPosition(41017));
            Log(field.columns[ColumnType.one].receptor.getCurrentPosition(41017));

            DrawInstance draw = new DrawInstance(field, 900, scrollSpeed, updatesPerSecond, OsbEasing.None, false, fadeTime, fadeTime);
            draw.setNoteRotationPrecision(0f);
            draw.setNoteMovementPrecision(0f);
            draw.setHoldRotationPrecision(0f);
            draw.drawViaEquation(duration, NoteFunction, true);

        }

        public Vector2 NoteFunction(Vector2 position, double currentTime, double t)
        {
            float y = position.Y;
            float x = position.X;

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

                field.moveField(starttime, stepDuration, easing, x, y);

                lastPhaseX += frequencyX;
                lastPhaseY += frequencyX;
                starttime += stepDuration;
                count++;
            }
        }


    }
}
