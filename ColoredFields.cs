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

namespace StorybrewScripts
{
    public class ColoredFields : StoryboardObjectGenerator
    {
        Playfield field;
        Playfield field2;

        double phase = 0;

        public override void Generate()
        {

            var receptors = GetLayer("r");
            var notes = GetLayer("n");
            var back = GetLayer("b");

            // General values
            var starttime = 66800;
            var renderStart = 66805;
            var endtime = 79956;
            var duration = endtime - renderStart;

            // Playfield Scale
            var width = 250f;
            var height = 440f;

            // Note initilization Values
            var bpm = 146f;
            var offset = 1052;
            var sliderAccuracy = 30;

            // Drawinstance Values
            var updatesPerSecond = 30;
            var scrollSpeed = 900f;
            var rotateNotesToFaceReceptor = false;
            var fadeTime = 100;
            var fadeOutTime = 40;

            var recepotrBitmap = GetMapsetBitmap("sb/sprites/receiver.png"); // The receptor sprite
            var receportWidth = recepotrBitmap.Width;

            var white = back.CreateSprite("sb/white.png");
            white.Color(starttime, new Color4(53, 74, 94, 255));
            white.ScaleVec(starttime, 854, 480);
            white.Fade(starttime, 1);
            white.Fade(endtime, 0);

            var colored = back.CreateSprite("sb/white.png");
            colored.Color(starttime, new Color4(213, 84, 104, 255));
            colored.ScaleVec(starttime, new Vector2(0, 0));
            colored.Fade(starttime, 1);
            colored.Fade(endtime, 0);

            var cube = back.CreateSprite("sb/white.png", OsbOrigin.Centre);
            cube.Color(starttime, new Color4(53, 74, 94, 255));
            cube.ScaleVec(starttime, new Vector2(40, 40));
            cube.Fade(starttime, 1);
            cube.Fade(endtime, 0);

            var cube2 = back.CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(0, 0));
            cube2.Color(starttime, new Color4(53, 74, 94, 255));
            cube2.ScaleVec(starttime, new Vector2(40, 40));
            cube2.Fade(starttime, 1);
            cube2.Fade(endtime, 0);

            var cube3 = back.CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(0, 0));
            cube3.Color(starttime, new Color4(53, 74, 94, 255));
            cube3.ScaleVec(starttime, new Vector2(40, 40));
            cube3.Fade(starttime, 1);
            cube3.Fade(endtime, 0);

            var cube4 = back.CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(0, 0));
            cube4.Color(starttime, new Color4(53, 74, 94, 255));
            cube4.ScaleVec(starttime, new Vector2(40, 40));
            cube4.Fade(starttime, 1);
            cube4.Fade(endtime, 0);

            var colored2 = back.CreateSprite("sb/white.png");
            colored2.Color(starttime, new Color4(213, 84, 104, 255));
            colored2.ScaleVec(starttime, new Vector2(0, 0));
            colored2.Fade(starttime, 1);
            colored2.Fade(endtime, 0);

            var cover = back.CreateSprite("sb/cover.png");
            cover.Scale(OsbEasing.OutCirc, 65161, starttime, 2, 1);
            cover.Scale(OsbEasing.OutSine, 79545, 79956, 1, 1.5);
            cover.Fade(65161, 1);
            cover.Fade(endtime, 0);
            cover.Color(65161, new Color4(228, 228, 228, 255));
            cover.Color(OsbEasing.InOutCirc, starttime, 68449, new Color4(53, 74, 94, 255), new Color4(0, 148, 174, 255));
            cover.Color(OsbEasing.InOutCirc, 69887, 70093, new Color4(0, 148, 174, 255), new Color4(224, 187, 47, 255));
            cover.Color(OsbEasing.InOutCirc, 70093, 71736, new Color4(224, 187, 47, 255), new Color4(255, 255, 255, 255));
            cover.Color(OsbEasing.InOutCirc, 72558, 73380, new Color4(255, 255, 255, 255), new Color4(53, 74, 94, 255));
            cover.Color(OsbEasing.InOutCirc, 73380, 75024, new Color4(53, 74, 94, 255), new Color4(213, 84, 104, 255));
            cover.Color(OsbEasing.InOutCirc, 75846, 76668, new Color4(213, 84, 104, 255), new Color4(255, 255, 255, 255));
            cover.Color(OsbEasing.InOutCirc, 78312, 79134, new Color4(255, 255, 255, 255), new Color4(53, 74, 94, 255));

            var cover2 = back.CreateSprite("sb/cover.png");
            cover2.Scale(OsbEasing.OutCirc, 65161, starttime, 2, 1);
            cover2.Fade(65161, 0.35);
            cover2.Fade(endtime, 0);
            cover2.Scale(OsbEasing.OutSine, 79545, 79956, 1, 1.5);
            cover2.Color(starttime, new Color4(0, 0, 0, 0));

            colored.ScaleVec(OsbEasing.OutCirc, 66805, 67421, new Vector2(0, 2), new Vector2(500, 2));
            colored.Rotate(OsbEasing.OutSine, 66805, 68449, -Math.PI / 32, -Math.PI);
            colored.ScaleVec(OsbEasing.OutSine, 67421, 68449, new Vector2(854, 2), new Vector2(854, 854));

            cube.MoveX(OsbEasing.OutSine, 69271, 70093, -50, 150);
            cube.MoveY(OsbEasing.OutBounce, 69271, 70093, 0, 120);
            cube.ScaleVec(OsbEasing.OutSine, 70093, 70093 + 500, new Vector2(40, 40), new Vector2(854, 854));
            cube.MoveX(OsbEasing.OutSine, 70094, 70094 + 500, 150, 320);
            cube.MoveY(OsbEasing.OutSine, 70094, 70094 + 500, 120, 240);

            cube.Rotate(72558, 72558 + 1000, 0, Math.PI);
            cube.ScaleVec(OsbEasing.InOutBounce, 72558, 73380, new Vector2(600, 600), new Vector2(0, 0));

            cube4.MoveX(75846, 700);
            cube4.MoveY(75846, 80);
            cube2.MoveX(75846, -50);
            cube2.MoveY(75846, 240);
            cube3.MoveX(75846, 700);
            cube3.MoveY(75846, 400);

            cube4.ScaleVec(75845, new Vector2(0, 160));
            cube2.ScaleVec(75845, new Vector2(0, 160));
            cube3.ScaleVec(75845, new Vector2(0, 160));

            cube3.ScaleVec(OsbEasing.InOutBounce, 75846, 76668, new Vector2(0, 160), new Vector2(700, 160));
            cube2.ScaleVec(OsbEasing.InOutBounce, 75846, 76668, new Vector2(0, 160), new Vector2(700, 160));
            cube4.ScaleVec(OsbEasing.InOutBounce, 75846, 76668, new Vector2(0, 160), new Vector2(700, 160));

            colored2.Rotate(79134, Math.PI / 4);
            colored2.ScaleVec(OsbEasing.InOutBounce, 79134, 79134 + 1000, new Vector2(0, 0), new Vector2(850, 850));

            field2 = new Playfield();
            field2.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);
            field2.ScalePlayField(starttime, 0, OsbEasing.None, width, -height); // Its important that this gets executed AFTER the Playfield is initialized otherwise this will run into "overlapped commands" and break
            field2.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, true, sliderAccuracy);
            field2.ZoomAndMove(starttime + 1, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), new Vector2(0, -20));

            field = new Playfield();
            field.initilizePlayField(receptors, notes, starttime, endtime, receportWidth, 60, 0);
            field.ScalePlayField(starttime, 0, OsbEasing.None, width, height); // Its important that this gets executed AFTER the Playfield is initialized otherwise this will run into "overlapped commands" and break
            field.initializeNotes(Beatmap.HitObjects.ToList(), notes, bpm, offset, true, sliderAccuracy);
            field.ZoomAndMove(starttime + 1, 0, OsbEasing.None, new Vector2(0.45f, 0.45f), new Vector2(0, 60));

            field.fadeAt(67863, 1);

            field.addEffectWithValue(67935, 70100, EffectType.RenderPlayFieldUntil, "0", 0);
            field.addEffectWithValue(70100, 73278, EffectType.RenderPlayFieldUntil, "1", 1);
            field.addEffectWithValue(73278, 75435, EffectType.RenderPlayFieldUntil, "2", 0);
            field.addEffectWithValue(75435, 79956, EffectType.RenderPlayFieldUntil, "3", 1);

            var localDuration = 820;
            double currentTime = 66807;
            float movement = 140;

            for (int i = 0; i < 5; i++)
            {
                field.moveFieldX(currentTime, localDuration, OsbEasing.OutSine, movement);
                field2.moveFieldX(currentTime, localDuration, OsbEasing.OutSine, -movement);
                currentTime += localDuration;
                field.moveFieldX(currentTime, localDuration, OsbEasing.InSine, -movement);
                field2.moveFieldX(currentTime, localDuration, OsbEasing.InSine, movement);
                currentTime += localDuration;
                field.moveFieldX(currentTime, localDuration, OsbEasing.OutSine, -movement);
                field2.moveFieldX(currentTime, localDuration, OsbEasing.OutSine, movement);
                currentTime += localDuration;
                field.moveFieldX(currentTime, localDuration, OsbEasing.InSine, movement);
                field2.moveFieldX(currentTime, localDuration, OsbEasing.InSine, -movement);
                currentTime += localDuration;
            }

            ApplySineToPlayField(starttime, endtime);

            DrawInstance draw2 = new DrawInstance(field2, renderStart, scrollSpeed, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeOutTime);
            draw2.SetColor(new Color4(53, 74, 94, 255));
            DrawInstance draw = new DrawInstance(field, renderStart, scrollSpeed, updatesPerSecond, OsbEasing.None, rotateNotesToFaceReceptor, fadeTime, fadeOutTime);
            draw.SetColor(new Color4(213, 84, 104, 255));
            // All effekts have to be executed before calling the draw Function.
            // Anything that is done after the draw Function call will not be rendered out.
            draw.setHoldRotationPrecision(0f);
            draw2.setHoldRotationPrecision(0f);
            draw2.drawViaEquation(duration, NotePathTop, true);
            draw.drawViaEquation(duration, NotePathBottom, true);

        }

        public Vector2 NotePathTop(Vector2 currentPosition, double currentTime, double t)
        {
            float x = currentPosition.X;
            float y = currentPosition.Y;

            x += (float)Utility.SineWaveValueWithPhase(38, 0.425, t, 0.5);

            return new Vector2(x, y);
        }

        public Vector2 NotePathBottom(Vector2 currentPosition, double currentTime, double t)
        {

            float x = currentPosition.X;
            float y = currentPosition.Y;

            x -= (float)Utility.SineWaveValueWithPhase(38, 0.425, t, 0.5);

            return new Vector2(x, y);
        }

        public void ApplySineToPlayField(double starttime, double endtime)
        {

            int count = 1;
            double stepDuration = 20;
            double frequencyY = 0.125;

            while (starttime < endtime - stepDuration)
            {
                OsbEasing easing = OsbEasing.None;

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.CosWaveValue(0.4, frequencyY, phase);

                field.moveField(starttime, stepDuration, easing, 0, y);
                field2.moveField(starttime, stepDuration, easing, 0, y);

                phase += frequencyY;
                starttime += stepDuration;
                count++;
            }
        }
    }
}
