using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;
using System.Linq;

namespace StorybrewScripts
{
    public class BuildUp : StoryboardObjectGenerator
    {

        Playfield field;
        StoryboardLayer back;

        double phase = 0;
        private double lastPhaseX = 0; // To keep track of last phase value for X (Cosine)
        private double lastPhaseY = Math.PI / 2; // Start at the top point for Y (Sine)
        public override void Generate()
        {


            var receptors = GetLayer("r");
            var notes = GetLayer("n");
            back = GetLayer("b");

            // General values
            var starttime = 79000;
            var renderStart = 79545;
            var endtime = 106873;
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

            if (Beatmap.Name == "HARD MODE")
            {
                scrollSpeed = 750f;
            }
            if (Beatmap.Name == "EASY MODE")
            {
                scrollSpeed = 1050f;
            }


            var fadeTimeOut = 20;
            var fadeTimeIn = 50;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            var leftCover2 = back.CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(0, 240));
            var rightCover2 = back.CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(800, 240));
            var leftCover = back.CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(0, 240));
            var rightCover = back.CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(800, 240));

            leftCover.Color(starttime, new Color4(53, 74, 94, 255));
            rightCover.Color(starttime, new Color4(53, 74, 94, 255));
            leftCover2.Color(starttime, new Color4(23, 34, 43, 255));
            rightCover2.Color(starttime, new Color4(23, 34, 43, 255));

            leftCover.ScaleVec(starttime, 854 / 2, 480f);
            rightCover.ScaleVec(starttime, 854 / 2, 480f);
            leftCover2.ScaleVec(starttime, 854 / 2, 480f);
            rightCover2.ScaleVec(starttime, 854 / 2, 480f);

            leftCover.Fade(renderStart, 1);
            leftCover.Fade(79956, 0);

            leftCover2.Fade(renderStart, 1);
            leftCover2.Fade(79956, 0);

            rightCover.Fade(renderStart, 1);
            rightCover.Fade(79956, 0);

            rightCover2.Fade(renderStart, 1);
            rightCover2.Fade(79956, 0);

            double closeDuration = 350;

            leftCover.MoveX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, -110, 320);
            rightCover.MoveX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, 750, 320);

            leftCover2.MoveX(OsbEasing.OutCirc, renderStart - 10, renderStart + closeDuration - 10, -110, 320);
            rightCover2.MoveX(OsbEasing.OutCirc, renderStart - 10, renderStart + closeDuration - 10, 750, 320);

            field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, width, -height, 60, Beatmap.OverallDifficulty);
            field.noteEnd = 106668 + 1000;
            field.initializeNotes(Beatmap.HitObjects.ToList(), bpm, offset, false, sliderAccuracy);
            field.Scale(OsbEasing.None, starttime, starttime, new Vector2(0.45f, 0.45f));

            field.MoveColumnRelativeX(OsbEasing.OutCirc, starttime, starttime, -450, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, starttime, starttime, -450, ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, starttime, starttime, 450, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, starttime, starttime, 450, ColumnType.four);

            field.MoveOriginRelative(OsbEasing.None, starttime, starttime, new Vector2(0, -250), ColumnType.all);

            field.MoveColumnRelativeX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, 450, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, 450, ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, -450, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, renderStart, renderStart + closeDuration, -450, ColumnType.four);

            field.MoveOriginRelative(OsbEasing.OutCirc, 79545, 79955, new Vector2(0, 250), ColumnType.all);

            field.MoveColumnRelativeX(OsbEasing.OutCirc, 79956, 79956 + 200, -100, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 79956, 79956 + 200, -100, ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.InCirc, 80161, 80161 + 200, 100, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.InCirc, 80161, 80161 + 200, 100, ColumnType.two);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 80367, 80367 + 200, 100, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 80367, 80367 + 200, 100, ColumnType.four);
            field.MoveColumnRelativeX(OsbEasing.InCirc, 80572, 80572 + 200, -100, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.InCirc, 80572, 80572 + 200, -100, ColumnType.four);

            field.MoveReceptorRelative(OsbEasing.OutCirc, 80778, 80880, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutCirc, 80778, 80880, new Vector2(100, 0), ColumnType.all);

            field.MoveReceptorRelative(OsbEasing.InOutCirc, 80881, 81086, new Vector2(200, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutCirc, 80881, 81086, new Vector2(-200, 0), ColumnType.all);

            field.MoveReceptorRelative(OsbEasing.InCirc, 81087, 81188, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InCirc, 81087, 81188, new Vector2(100, 0), ColumnType.all);

            field.moveFieldX(OsbEasing.OutSine, 82113, 82113 + 300, -150);
            field.moveFieldX(OsbEasing.OutSine, 82522, 82522 + 300, 150);

            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84271, 84476, -field.getColumnWidth(width) * 2, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84271, 84476, field.getColumnWidth(width) * 2, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84271, 84476, -field.getColumnWidth(width) * 2, ColumnType.four);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84271, 84476, field.getColumnWidth(width) * 2, ColumnType.two);

            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84682, 84887, field.getColumnWidth(width) * 2, ColumnType.three);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84682, 84887, -field.getColumnWidth(width) * 2, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84682, 84887, field.getColumnWidth(width) * 2, ColumnType.four);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 84682, 84887, -field.getColumnWidth(width) * 2, ColumnType.two);

            flipColumn(85298, 150, OsbEasing.OutCirc, ColumnType.all);
            //field.moveFieldY(OsbEasing.None, 85298, 85298 + 150, -10);

            field.MoveColumnRelativeX(OsbEasing.OutCirc, 85709, 85709 + 50, -50, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 85812, 85812 + 50, -50, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 85915, 85915 + 50, -50, ColumnType.one);
            field.MoveColumnRelativeX(OsbEasing.OutCirc, 86017, 86017 + 50, -50, ColumnType.one);

            field.MoveColumnRelativeX(OsbEasing.InSine, 86120, 86531, 200, ColumnType.one);

            field.MoveOriginRelative(OsbEasing.None, 86942, 86942, new Vector2(100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 86942, 87250, new Vector2(-100, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 87250, 87250, new Vector2(-100, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 87250, 87558, new Vector2(100, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 87558, 87558, new Vector2(200, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 87558, 87867, new Vector2(-200, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 87867, 87867, new Vector2(-150, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 87867, 88175, new Vector2(150, 0), ColumnType.all);

            field.MoveOriginRelative(OsbEasing.None, 88175, 88175, new Vector2(250, 0), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.OutSine, 88175, 88586, new Vector2(-250, 0), ColumnType.all);

            field.Rotate(OsbEasing.OutSine, 88586, 89099, Math.PI * 2);

            field.MoveOriginRelative(OsbEasing.InOutSine, 89716, 90024, new Vector2(0, -300), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutSine, 90024, 90435, new Vector2(0, 300), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutSine, 90435, 90846, new Vector2(0, -300), ColumnType.all);
            field.MoveOriginRelative(OsbEasing.InOutSine, 90846, 91257, new Vector2(0, 300), ColumnType.all);


            flipColumn(92284, 100, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(92387, 100, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(92490, 100, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(92593, 100, OsbEasing.OutCirc, ColumnType.one);


            ApplySineToPlayField(79956, 93106);

            /*var currentHeightR = field.columns[ColumnType.four].receptor.getCurrentPosition(92695).Y;
            var currentHeightO = field.columns[ColumnType.four].origin.getCurrentPosition(92695).Y;*/

            flipColumn(95675, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(95778, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(95880, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(95983, 200, OsbEasing.OutCirc, ColumnType.one);

            flipColumn(99271, 99682 - 99271, OsbEasing.OutSine, ColumnType.all);

            flipColumn(102147, 200, OsbEasing.OutCirc, ColumnType.four);
            flipColumn(102250, 200, OsbEasing.OutCirc, ColumnType.three);
            flipColumn(102353, 200, OsbEasing.OutCirc, ColumnType.two);
            flipColumn(102456, 200, OsbEasing.OutCirc, ColumnType.one);


            ApplySineToPlayFieldFigureEight(93106, 105846);

            field.Scale(OsbEasing.InOutSine, 105846, 106257, new Vector2(.8f, 0.8f));
            field.Rotate(OsbEasing.InOutSine, 105846, 106257, .6, CenterType.middle);
            field.moveField(OsbEasing.InOutSine, 105846, 106257, -200, 100);

            field.ScaleColumn(OsbEasing.OutSine, 106257, 106565, new Vector2(0.5f), ColumnType.all);

            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(226.25f, 50), ColumnType.one);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(288.75f, 50), ColumnType.two);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(351.25f, 50), ColumnType.three);
            field.MoveReceptorAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(413.75f, 50), ColumnType.four);

            field.MoveOriginAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(226.25f, 550), ColumnType.one);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(288.75f, 550), ColumnType.two);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(351.25f, 550), ColumnType.three);
            field.MoveOriginAbsolute(OsbEasing.OutCirc, 106257, 106565, new Vector2(413.75f, 550), ColumnType.four);

            DrawInstance draw = new DrawInstance(field, renderStart, scrollSpeed, 100, OsbEasing.None, false, fadeTimeIn, fadeTimeOut);
            draw.setHoldRotationPrecision(0f);
            draw.setHoldMovementPrecision(1.5f);
            draw.setNoteRotationPrecision(0f);
            draw.drawViaEquation(duration, NoteFunction, true);
        }

        public Vector2 NoteFunction(EquationParameters parameters)
        {
            float x = parameters.position.X;
            float y = parameters.position.Y;
            double currentTime = parameters.time;
            float t = parameters.progress;

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
                OsbEasing easing = OsbEasing.OutSine;

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.CosWaveValue(1, frequencyY, phase);

                field.moveField(easing, starttime, stepDuration, 0, y);

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



                field.moveField(easing, starttime, stepDuration, x, y);

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
