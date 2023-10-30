using AForge.Imaging.Filters;
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
using System.Linq;

namespace StorybrewScripts
{
    public class BuildUp : StoryboardObjectGenerator
    {

        Playfield field;

        double phase = 0;
        private double lastPhaseX = 0; // To keep track of last phase value for X (Cosine)
        private double lastPhaseY = Math.PI / 2; // Start at the top point for Y (Sine)
        public override void Generate()
        {


            var receptors = GetLayer("r");
            var notes = GetLayer("n");
            var back = GetLayer("b");

            // General values
            var starttime = 79000;
            var renderStart = 79545;
            var endtime = 106565;
            var duration = endtime - renderStart;

            // Playfield Scale
            var width = 250f;
            var height = 500f;

            // Note initilization Values
            var bpm = 146f;
            var offset = 1052;
            var sliderAccuracy = 25;

            // Drawinstance Values
            var updatesPerSecond = 100;
            var scrollSpeed = 900f;
            var fadeTimeOut = 20;
            var fadeTimeIn = 50;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            var leftCover = back.CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(0, 240));
            var rightCover = back.CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(800, 240));

            leftCover.Color(starttime, new Color4(0, 0, 0, 0));
            rightCover.Color(starttime, new Color4(0, 0, 0, 0));

            leftCover.ScaleVec(starttime, 854 / 2, 480f);
            rightCover.ScaleVec(starttime, 854 / 2, 480f);

            leftCover.Fade(renderStart, 1);
            leftCover.Fade(81188, 0);

            rightCover.Fade(renderStart, 1);
            rightCover.Fade(81188, 0);

            double closeDuration = 350;

            leftCover.MoveX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, 0, 320);
            rightCover.MoveX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, 800, 320);

            field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);
            field.noteEnd = 106668 + 1000;
            field.ScalePlayField(starttime, 0, OsbEasing.None, width, height); // Its important that this gets executed AFTER the Playfield is initialized otherwise this will run into "overlapped commands" and break
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, false, sliderAccuracy);
            field.ZoomAndMove(starttime + 1, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), new Vector2(0, 6));

            field.MoveColumnRelativeX(starttime + 2, 0, OsbEasing.OutCirc, -450, ColumnType.one);
            field.MoveColumnRelativeX(starttime + 2, 0, OsbEasing.OutCirc, -450, ColumnType.two);
            field.MoveColumnRelativeX(starttime + 2, 0, OsbEasing.OutCirc, 450, ColumnType.three);
            field.MoveColumnRelativeX(starttime + 2, 0, OsbEasing.OutCirc, 450, ColumnType.four);

            field.MoveOriginRelative(starttime + 2, 0, OsbEasing.None, new Vector2(0, -400), ColumnType.all);

            field.MoveColumnRelativeX(renderStart, closeDuration, OsbEasing.OutCirc, 450, ColumnType.one);
            field.MoveColumnRelativeX(renderStart, closeDuration, OsbEasing.OutCirc, 450, ColumnType.two);
            field.MoveColumnRelativeX(renderStart, closeDuration, OsbEasing.OutCirc, -450, ColumnType.three);
            field.MoveColumnRelativeX(renderStart, closeDuration, OsbEasing.OutCirc, -450, ColumnType.four);

            field.MoveOriginRelative(renderStart, closeDuration - 100, OsbEasing.OutCirc, new Vector2(0, 400), ColumnType.all);

            field.MoveColumnRelativeX(79956, 200, OsbEasing.OutCirc, -100, ColumnType.one);
            field.MoveColumnRelativeX(79956, 200, OsbEasing.OutCirc, -100, ColumnType.two);
            field.MoveColumnRelativeX(80161, 200, OsbEasing.InCirc, 100, ColumnType.one);
            field.MoveColumnRelativeX(80161, 200, OsbEasing.InCirc, 100, ColumnType.two);
            field.MoveColumnRelativeX(80367, 200, OsbEasing.OutCirc, 100, ColumnType.three);
            field.MoveColumnRelativeX(80367, 200, OsbEasing.OutCirc, 100, ColumnType.four);
            field.MoveColumnRelativeX(80572, 200, OsbEasing.InCirc, -100, ColumnType.three);
            field.MoveColumnRelativeX(80572, 200, OsbEasing.InCirc, -100, ColumnType.four);

            ApplySineToPlayField(79956, 85295);

            field.MoveReceptorRelative(80778, 80880 - 80778, OsbEasing.OutCirc, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(80778, 80880 - 80778, OsbEasing.OutCirc, new Vector2(100, 0), ColumnType.all);

            field.MoveReceptorRelative(80881, 81086 - 80881, OsbEasing.InOutCirc, new Vector2(200, 0), ColumnType.all);
            field.MoveOriginRelative(80881, 81086 - 80881, OsbEasing.InOutCirc, new Vector2(-200, 0), ColumnType.all);

            field.MoveReceptorRelative(81087, 81188 - 81087, OsbEasing.InCirc, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(81087, 81188 - 81087, OsbEasing.InCirc, new Vector2(100, 0), ColumnType.all);

            field.moveFieldX(82113, 300, OsbEasing.OutSine, -150);
            field.moveFieldX(82522, 300, OsbEasing.OutSine, 150);

            PlayFieldEffect effect = new PlayFieldEffect(field, 84271, 84476, OsbEasing.OutCirc, 100);
            effect.SwapColumn(ColumnType.one, ColumnType.three);
            effect.SwapColumn(ColumnType.two, ColumnType.four);

            PlayFieldEffect effect2 = new PlayFieldEffect(field, 84682, 84887, OsbEasing.OutCirc, 100);
            effect2.SwapColumn(ColumnType.one, ColumnType.three);
            effect2.SwapColumn(ColumnType.two, ColumnType.four);

            flipColumn(85298, 150, OsbEasing.OutCirc, ColumnType.all);

            field.MoveColumnRelativeX(85709, 50, OsbEasing.OutCirc, -50, ColumnType.one);
            field.MoveColumnRelativeX(85812, 50, OsbEasing.OutCirc, -50, ColumnType.one);
            field.MoveColumnRelativeX(85915, 50, OsbEasing.OutCirc, -50, ColumnType.one);
            field.MoveColumnRelativeX(86017, 50, OsbEasing.OutCirc, -50, ColumnType.one);

            field.MoveColumnRelativeX(86120, 86531 - 86120, OsbEasing.InSine, 200, ColumnType.one);

            ApplySineToPlayField(85504, 88586);

            field.MoveOriginRelative(86942, 0, OsbEasing.None, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(86942, 87250 - 86942, OsbEasing.OutSine, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(87250, 0, OsbEasing.None, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(87250, 87558 - 87251, OsbEasing.OutSine, new Vector2(100, 0), ColumnType.all);

            field.MoveOriginRelative(87558, 0, OsbEasing.None, new Vector2(200, 0), ColumnType.all);
            field.MoveOriginRelative(87558, 87867 - 87559, OsbEasing.OutSine, new Vector2(-200, 0), ColumnType.all);

            field.MoveOriginRelative(87867, 0, OsbEasing.None, new Vector2(-150, 0), ColumnType.all);
            field.MoveOriginRelative(87867, 88175 - 87867, OsbEasing.OutSine, new Vector2(150, 0), ColumnType.all);

            field.MoveOriginRelative(88175, 0, OsbEasing.None, new Vector2(250, 0), ColumnType.all);
            field.MoveOriginRelative(88175, 88586 - 88175, OsbEasing.OutSine, new Vector2(-250, 0), ColumnType.all);

            field.RotatePlayField(88586, 89099 - 88586, OsbEasing.None, Math.PI * 2, 200);

            field.MoveOriginRelative(89716, 90024 - 89716, OsbEasing.InOutSine, new Vector2(0, -200), ColumnType.all);
            field.MoveOriginRelative(90024, 90435 - 90024, OsbEasing.InOutSine, new Vector2(0, 200), ColumnType.all);
            field.MoveOriginRelative(90435, 90846 - 90435, OsbEasing.InOutSine, new Vector2(0, -200), ColumnType.all);
            field.MoveOriginRelative(90846, 91257 - 90846, OsbEasing.InOutSine, new Vector2(0, 200), ColumnType.all);

            ApplySineToPlayField(89202, 92284);

            flipColumn(92284, 100, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(92387, 100, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(92490, 100, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(92593, 100, OsbEasing.OutCirc, ColumnType.one);

            var currentHeightR = field.columns[ColumnType.four].receptor.getCurrentPosition(92695).Y;
            var currentHeightO = field.columns[ColumnType.four].origin.getCurrentPosition(92695).Y;

            var difference = currentHeightR - currentHeightO;

            Log(difference);

            if (difference != 500)
            {
                var moveAmount = difference - 500;
                field.MoveOriginRelative(92695, 93106 - 92695, OsbEasing.OutSine, new Vector2(0, moveAmount), ColumnType.all);
            }

            ApplySineToPlayFieldFigureEight(93106, 95675);

            flipColumn(95675, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(95778, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(95880, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(95983, 200, OsbEasing.OutCirc, ColumnType.one);

            ApplySineToPlayFieldFigureEight(95983 + 200, 99271);

            flipColumn(99271, 99682 - 99271, OsbEasing.OutSine, ColumnType.all);

            ApplySineToPlayFieldFigureEight(99682, 102147);

            flipColumn(102147, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(102250, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(102353, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(102456, 200, OsbEasing.OutCirc, ColumnType.one);

            ApplySineToPlayFieldFigureEight(102456 + 200, 105846);

            field.ZoomMoveAndRotate(105846, 106257 - 105846, OsbEasing.OutSine, new Vector2(1f, 1f), new Vector2(350, 250), Math.PI / 7, 50);
            field.Zoom(106257, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), true);
            field.ScalePlayField(106257, 100, OsbEasing.OutSine, 225, -500);

            DrawInstance draw = new DrawInstance(field, renderStart, scrollSpeed, 100, OsbEasing.None, false, fadeTimeIn, fadeTimeOut);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(1.5f);
            draw.setNoteRotationPrecision(0f);
            draw.drawViaEquation(duration, NoteFunction, true);
        }

        public Vector2 NoteFunction(Vector2 currentPosition, double currentTime, double t)
        {
            float x = currentPosition.X;
            float y = currentPosition.Y;

            if (currentTime > 81188 && currentTime < 81599)
            {
                double start = 81188;
                double end = 81599;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 100;
                double endAmplitude = 0;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime > 81599 && currentTime < 82010)
            {
                double start = 81599;
                double end = 82010;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 0;
                double endAmplitude = -100;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime >= 82010 && currentTime < 82216)
            {
                double start = 82010;
                double end = 82216;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = -100;
                double endAmplitude = 0;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime >= 82832 && currentTime < 83860)
            {
                double start = 82832;
                double end = 83860;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 0;
                double endAmplitude = 50;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime >= 83860 && currentTime <= 84168)
            {
                double start = 83860;
                double end = 84168;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 50;
                double endAmplitude = 0;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x += (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime > 86531 && currentTime < 87147)
            {
                double start = 86531;
                double end = 87147;

                // Calculate progress in the range of [0, 1]
                double progress = (currentTime - start) / (end - start);

                // Use a starting amplitude and an ending amplitude to calculate the current amplitude
                double startAmplitude = 100;
                double endAmplitude = 0;
                double currentAmplitude = startAmplitude + progress * (endAmplitude - startAmplitude);

                x -= (float)Utility.SineWaveValue(currentAmplitude, 1, t);
            }

            if (currentTime > 93106 && currentTime < 105848)
            {
                // Determine amplitude for the sine wave
                double currentAmplitude;

                // If within the first time range
                if (currentTime <= 93517)
                {
                    double start = 93106;
                    double end = 93106 + 350;  // Ending before the second segment starts

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

                if (currentTime <= 93517)
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

        public void ApplySineToPlayField(double starttime, double endtime)
        {

            int count = 1;
            double stepDuration = 20;
            double frequencyX = 0.1;
            double frequencyY = 0.1;

            while (starttime < endtime - stepDuration)
            {
                OsbEasing easing = OsbEasing.None;

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.CosWaveValue(1, frequencyY, phase);

                field.moveField(starttime, stepDuration, easing, 0, y);

                phase += frequencyX;
                starttime += stepDuration;
                count++;
            }
        }

        public void ApplySineToPlayFieldFigureEight(double starttime, double endtime)
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
    }
}
