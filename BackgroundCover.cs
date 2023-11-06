using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

namespace StorybrewScripts
{
    public class BackgroundCover : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            GetLayer("").CreateSprite(Beatmap.BackgroundPath).Fade(0, 0);

            var bgCover = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre);
            bgCover.ScaleVec(-2500, new Vector2(854, 480));
            bgCover.Color(-2500, new Color4(0, 0, 0, 0));
            bgCover.Fade(0, 1);
            bgCover.Fade(121873, 0);

            var bg = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre);
            bg.ScaleVec(-2500, new Vector2(854, 480));
            bg.Fade(0, 1);
            bg.Fade(66800, 0);
            bg.Fade(79956, 1);
            bg.Fade(121873, 0);

            var secondary = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre);
            var one = GetLayer("").CreateSprite("sb/numb/one.png", OsbOrigin.Centre);
            var two = GetLayer("").CreateSprite("sb/numb/two.png", OsbOrigin.Centre);
            var three = GetLayer("").CreateSprite("sb/numb/three.png", OsbOrigin.Centre);
            var four = GetLayer("").CreateSprite("sb/numb/four.png", OsbOrigin.Centre);


            bg.Color(-2500, new Color4(59, 81, 104, 255));
            bg.Color(1052, new Color4(255, 255, 255, 255));

            vectors(1052, 2695, new Vector2(-100, -500), 500);
            vectors(1052, 2695, new Vector2(750, 0), -500);

            bg.Color(2695, new Color4(223, 186, 47, 255));
            cube();


            bg.Color(4339, new Color4(0, 133, 158, 255));
            Trumpet();

            bg.Color(7627, new Color4(173, 68, 84, 255));
            CubeCar();
            bg.Color(8243, new Color4(254, 212, 53, 255));

            bg.Color(9271, new Color4(0, 135, 159, 255));
            MakeIT();

            bg.Color(9887, new Color4(45, 62, 79, 255));
            FunkyCubes();
            bg.Color(10915, new Color4(160, 63, 78, 255));
            Stomp();

            bg.Color(11325, new Color4(203, 119, 60, 255));
            bg.Color(11735, new Color4(58, 80, 103, 255));
            FunkyNow();

            one.Scale(12558, 0.75f);
            one.MoveY(12558, 250);
            one.MoveX(OsbEasing.OutCirc, 12558, 12969, 400, 320);
            one.Fade(12558, 1);
            one.Fade(12969, 1);

            two.Scale(12969, 0.75f);
            two.MoveY(12969, 250);
            two.MoveX(OsbEasing.OutCirc, 12969, 13380, 400, 320);
            two.Fade(12969, 1);
            two.Fade(13380, 1);

            three.Scale(13380, 0.75f);
            three.MoveY(13380, 250);
            three.MoveX(OsbEasing.OutCirc, 13380, 13791, 400, 320);
            three.Fade(13380, 1);
            three.Fade(13791, 1);

            four.Scale(13791, 0.75f);
            four.MoveY(13791, 250);
            four.MoveX(OsbEasing.OutCirc, 13791, 14202, 400, 320);
            four.Fade(13791, 1);
            four.Fade(14202, 1);

            PreDrop();
            Puzzel();
            Holes();
            Transiton();
            bg.Color(14202, new Color4(228, 228, 228, 255));
            bg.Color(16668, new Color4(173, 68, 84, 255));
            bg.Color(17490, new Color4(190, 190, 190, 255));
            bg.Color(19956, new Color4(173, 68, 84, 255));
            bg.Color(20778, new Color4(228, 228, 228, 255));
            bg.Color(23243, new Color4(173, 68, 84, 255));
            bg.Color(24065, new Color4(255, 255, 255, 255));
            bg.Color(25709, new Color4(0, 142, 168, 255));
            bg.Color(26325, new Color4(255, 151, 77, 255));
            bg.Color(26942, new Color4(254, 212, 54, 255));

            BuildUpFirst();
            bg.Color(27353, new Color4(173, 68, 84, 255));
            bg.Color(28997, new Color4(46, 65, 82, 255));
            bg.Color(30641, new Color4(255, 225, 52, 255));
            bg.Color(31873, new Color4(228, 228, 228, 255));
            bg.Color(32695, new Color4(0, 185, 219, 255));
            bg.Color(33928 + 200, new Color4(57, 80, 101, 255));
            bg.Color(35572, new Color4(228, 228, 228, 255));
            bg.Color(37216, new Color4(228, 190, 48, 255));
            bg.Color(38449, new Color4(54, 75, 96, 255));
            bg.Color(40093, new Color4(219, 130, 66, 255));
            bg.Color(40504 + 200, new Color4(1, 184, 218, 255));
            bg.Color(40915, new Color4(228, 190, 48, 255));
            bg.Color(43791, new Color4(188, 74, 92, 255));
            bg.Color(44202, new Color4(49, 69, 88, 255));
            bg.Color(47079, new Color4(1, 184, 218, 255));
            bg.Color(47490, new Color4(254, 212, 53, 255));
            bg.Color(50362, new Color4(49, 69, 88, 255));
            bg.Color(53654, new Color4(228, 228, 228, 255));
            Drop();
            DropAnimation();
            InterMission();
            MultiCubeCs();
            Countdown();

            BuildUp();
            bg.Color(79956, new Color4(228, 190, 48, 255));
            bg.Color(80778, new Color4(54, 76, 97, 255));
            bg.Color(81599, new Color4(231, 137, 70, 255));
            bg.Color(82216, new Color4(2, 144, 171, 255));
            bg.Color(82832, new Color4(231, 137, 70, 255));
            bg.Color(83243, new Color4(2, 144, 171, 255));
            bg.Color(83654, new Color4(228, 228, 228, 255));
            bg.Color(84476, new Color4(54, 76, 97, 255));
            bg.Color(84887, new Color4(228, 190, 48, 255));
            bg.Color(85504, new Color4(54, 76, 97, 255));
            bg.Color(86120, new Color4(2, 144, 171, 255));
            bg.Color(86531, new Color4(231, 137, 70, 255));
            bg.Color(88586, new Color4(2, 144, 171, 255));
            bg.Color(89202, new Color4(54, 76, 97, 255));
            bg.Color(89613, new Color4(228, 228, 228, 255));
            bg.Color(91257, new Color4(231, 137, 70, 255));

            BuildUpLast();
            bg.Color(93106, new Color4(173, 68, 84, 255));
            bg.Color(94750, new Color4(46, 65, 82, 255));
            bg.Color(96394, new Color4(255, 225, 52, 255));
            bg.Color(97627, new Color4(228, 228, 228, 255));
            bg.Color(98449, new Color4(0, 185, 219, 255));
            bg.Color(99682 + 200, new Color4(57, 80, 101, 255));
            bg.Color(101325, new Color4(228, 228, 228, 255));
            bg.Color(102969, new Color4(228, 190, 48, 255));
            bg.Color(104202, new Color4(54, 75, 96, 255));
            bg.Color(105024, new Color4(219, 130, 66, 255));
            bg.Color(106257 + 200, new Color4(1, 184, 218, 255));

            LastDrop();
            bg.Color(106668, new Color4(228, 190, 48, 255));
            bg.Color(109545, new Color4(49, 69, 88, 255));
            bg.Color(109956, new Color4(1, 184, 218, 255));
            bg.Color(112832, new Color4(49, 69, 88, 255));
            bg.Color(113243, new Color4(254, 212, 53, 255));
            bg.Color(118997, new Color4(59, 81, 104, 255));


            var cover = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre);
            cover.Color(-2500, new Color4(0, 0, 0, 0));
            cover.ScaleVec(-2500, new Vector2(854, 480));
            cover.Fade(0, 0.35);
            cover.Fade(66800, 0.0);
            cover.Fade(79956, 0.35);
            cover.Fade(121873, 0.0);
        }

        public void horizontalStreamTransition(double start, double transitionEnd, double fadeOut, Color4 color, int segments, OsbEasing ease)
        {
            double duration = transitionEnd - start;
            float height = 480f;
            float segmentHeight = height / segments;
            double interval = duration / segments;
            float scale = 900;
            float x = -110;

            for (int i = 1; i <= segments; i++)
            {

                OsbOrigin org = OsbOrigin.BottomLeft;

                if (i % 2 == 0)
                {
                    org = OsbOrigin.BottomRight;
                    scale *= -1;
                    x = 900 - 110;
                }
                else
                {
                    x = -110;
                }

                var sprite = GetLayer("").CreateSprite("sb/white.png", org, new Vector2(x, segmentHeight * i));
                sprite.ScaleVec(ease, start, start + interval, new Vector2(0, segmentHeight), new Vector2(scale, segmentHeight));
                sprite.Color(start, color);
                sprite.Fade(start, 1);
                sprite.Fade(fadeOut, 0);

                start += interval;

            }

        }

        public void horizontalRotatedStreamTransition(double start, double transitionEnd, double fadeOut, double fadeOutTime, Color4 color, int segments, OsbEasing ease)
        {
            double duration = transitionEnd - start;
            float height = 480f;
            float segmentHeight = height / segments;
            double interval = duration / segments;
            float scale = 900;
            float x = -110;
            float movement = 500;

            for (int i = 1; i <= segments; i++)
            {

                float currentHeight = segmentHeight * i;

                OsbOrigin org = OsbOrigin.BottomLeft;

                if (i % 2 == 0)
                {
                    org = OsbOrigin.TopRight;
                    scale *= -1;
                    x = 870;
                    movement = 500;
                }
                else
                {
                    x = -180;
                    currentHeight = 480f - currentHeight;
                    movement = -500;
                }

                var sprite = GetLayer("").CreateSprite("sb/white.png", org, new Vector2(x, currentHeight));
                sprite.ScaleVec(ease, start, start + interval, new Vector2(0, 0), new Vector2(scale, segmentHeight));
                sprite.Rotate(start, Math.PI / 4);
                sprite.Color(start, color);
                sprite.Fade(start, 1);
                sprite.ScaleVec(OsbEasing.OutSine, fadeOut, fadeOut + fadeOutTime, new Vector2(scale, segmentHeight), new Vector2(scale * 5, segmentHeight * 5));
                sprite.Fade(25000, 0);

                start += interval;

            }

        }

        public void vectors(double start, double end, Vector2 initialPos, double movement)
        {

            float offset = 150;

            for (int i = 0; i < 10; i++)
            {

                var sprite = GetLayer("").CreateSprite("sb/vec.png", OsbOrigin.Centre, new Vector2(initialPos.X, initialPos.Y + offset * i));

                if (i % 2 == 0)
                {
                    sprite.Color(start, new Color4(211, 84, 104, 255));
                }
                else
                {
                    sprite.Color(start, new Color4(0, 143, 168, 255));
                }

                sprite.Scale(start, 0.5);
                sprite.MoveY(start, end, sprite.PositionAt(start).Y, sprite.PositionAt(start).Y + movement);
                sprite.Fade(start, 1);
                sprite.Fade(end, 0);

            }

        }

        public void cube()
        {

            var sprite = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            sprite.Scale(2695, 0.1);
            sprite.Rotate(2695, -0.1);
            sprite.Fade(2695, 1);
            sprite.Fade(4339, 0);
            sprite.Color(2695, new Color4(59, 81, 104, 255));

            double theta = -0.1; // 45 degrees in radians for example
            double distance = -20;     // Adjust this to move the sprite further or closer
            double dx = distance * Math.Cos(theta);
            double dy = distance * Math.Sin(theta);

            Vector2 startPosition = new Vector2(50, 180);
            Vector2 endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);
            sprite.Move(OsbEasing.OutSine, 2695, 3106, startPosition, endPosition);

            distance = 100;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);
            sprite.Move(OsbEasing.OutCubic, 3106, 3312, startPosition, endPosition);

            distance = -20;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);
            sprite.Move(OsbEasing.OutSine, 3312, 3723, startPosition, endPosition);

            distance = 200;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);
            sprite.Move(OsbEasing.OutCubic, 3723, 4339, startPosition, endPosition);

        }

        public void FunkyCubes()
        {

            Vector2 initial = new Vector2(-150, 240);
            double theta = -0.025; // 45 degrees in radians for example
            double distance = 20;     // Adjust this to move the sprite further or closer
            double dx = distance * Math.Cos(theta);
            double dy = distance * Math.Sin(theta);

            Vector2 startPosition = initial;
            Vector2 endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            var zero = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre, endPosition);
            zero.ScaleVec(9887, 200, 200);
            zero.Rotate(9887, -0.025);
            zero.Fade(9887, 1);
            zero.Color(9887, new Color4(0, 166, 196, 255));

            distance = 180;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            var one = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre, endPosition);
            one.ScaleVec(9887, 120, 200);
            one.Rotate(9887, -0.025);
            one.Fade(9887, 1);
            one.Color(9887, new Color4(47, 70, 92, 255));

            distance = 220;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            var two = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre, endPosition);
            two.ScaleVec(9887, 280, 200);
            two.Rotate(9887, -0.025);
            two.Fade(9887, 1);
            two.Color(9887, new Color4(254, 212, 53, 255));

            distance = 280;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            var three = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre, endPosition);
            three.ScaleVec(9887, 250, 200);
            three.Rotate(9887, -0.025);
            three.Fade(9887, 1);
            three.Color(9887, new Color4(213, 84, 104, 255));


            distance = 220;     // Adjust this to move the sprite further or closer
            dx = distance * Math.Cos(theta);
            dy = distance * Math.Sin(theta);

            startPosition = endPosition;
            endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            var four = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.Centre, endPosition);
            four.ScaleVec(9887, 150, 200);
            four.Rotate(9887, -0.025);
            four.Fade(9887, 1);
            four.Color(9887, new Color4(228, 228, 228, 255));


            zero.ScaleVec(OsbEasing.InOutBounce, 9887, 10915, new Vector2(200, 200), new Vector2(150, 200));
            one.ScaleVec(OsbEasing.InOutBounce, 9887, 10915, new Vector2(120, 200), new Vector2(180, 200));
            two.ScaleVec(OsbEasing.InOutBounce, 9887, 10915, new Vector2(280, 200), new Vector2(215, 200));
            three.ScaleVec(OsbEasing.InOutBounce, 9887, 10915, new Vector2(250, 200), new Vector2(300, 200));
            four.ScaleVec(OsbEasing.InOutBounce, 9887, 10915, new Vector2(150, 200), new Vector2(100, 200));


            zero.Fade(10915, 0);
            one.Fade(10915, 0);
            two.Fade(10915, 0);
            three.Fade(10915, 0);
            four.Fade(10915, 0);


        }

        public void CubeCar()
        {
            var sprite = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            var sprite2 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(160, 290));
            sprite.Color(7627, new Color4(255, 255, 255, 255));
            sprite.ScaleVec(7627, 0.1f, 0.1);
            sprite.Fade(7627, 1);
            sprite.Fade(9271, 0);
            sprite.MoveY(7627, 250);
            sprite.MoveX(OsbEasing.OutSine, 7627, 8038, -150, -50);
            sprite.MoveY(8243, 270);
            sprite.MoveX(OsbEasing.OutCirc, 8243, 8449, -50, 50);
            sprite.MoveY(8654, 290);
            sprite.MoveX(OsbEasing.OutCirc, 8654, 8757, 50, 150);
            sprite.MoveX(OsbEasing.OutCirc, 8860, 9065, 120, -160);
            sprite2.Color(8860, new Color4(47, 70, 92, 255));
            sprite2.ScaleVec(OsbEasing.OutCirc, 8860, 9065, new Vector2(0.0f, 100f), new Vector2(300f, 100f));
            sprite2.MoveX(OsbEasing.OutCirc, 9065, 9271, 160, -400);
            sprite2.Fade(8860, 1);
            sprite2.Fade(9271, 0);
        }

        public void Trumpet()
        {
            //4339 5572 6599 6805 7216

            var sprite = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            sprite.ScaleVec(4339, 0.1, 0.1);
            sprite.Fade(4339, 1);
            sprite.Fade(7619, 0);
            sprite.Color(4339, new Color4(240, 215, 69, 255));
            sprite.Move(4339, new Vector2(0, 240));

            sprite.Move(OsbEasing.OutCirc, 4339, 4545, new Vector2(-50, 240), new Vector2(25, 240));
            sprite.ScaleVec(OsbEasing.InBounce, 4339, 4339 + 150, new Vector2(0.1f, 0.1f), new Vector2(0.2f, 0.1f));
            sprite.ScaleVec(OsbEasing.OutBounce, 4339 + 150, 4339 + 300, new Vector2(0.2f, 0.1f), new Vector2(0.1f, 0.1f));

            sprite.Move(OsbEasing.OutCirc, 4750, 4956, new Vector2(50, 120), new Vector2(25, 120));
            sprite.Move(OsbEasing.OutCirc, 4956, 5161, new Vector2(25, 120), new Vector2(100, 120));
            sprite.Move(OsbEasing.OutCirc, 5161, 5469, new Vector2(100, 120), new Vector2(150, 120));
            sprite.ScaleVec(OsbEasing.InBounce, 4750, 4750 + 150, new Vector2(0.1f, 0.1f), new Vector2(0.2f, 0.1f));
            sprite.ScaleVec(OsbEasing.OutBounce, 4750 + 150, 4750 + 300, new Vector2(0.2f, 0.1f), new Vector2(0.1f, 0.1f));
            sprite.ScaleVec(OsbEasing.InBounce, 5161, 5161 + 150, new Vector2(0.1f, 0.1f), new Vector2(0.2f, 0.1f));
            sprite.ScaleVec(OsbEasing.OutBounce, 5161 + 150, 5161 + 300, new Vector2(0.2f, 0.1f), new Vector2(0.1f, 0.1f));

            sprite.Move(OsbEasing.InOutSine, 5778, 6599, new Vector2(150, 120), new Vector2(600, 220));
            sprite.Rotate(5778, 6499, 0, Math.PI * 5);

            sprite.Move(OsbEasing.OutCirc, 6599, 6805, new Vector2(600, 220), new Vector2(625, 220));
            sprite.Move(OsbEasing.OutCirc, 6805, 7216, new Vector2(550, 220), new Vector2(550, 220));
            sprite.ScaleVec(OsbEasing.InBounce, 6599, 6599 + 150, new Vector2(0.1f, 0.1f), new Vector2(0.2f, 0.1f));
            sprite.ScaleVec(OsbEasing.OutBounce, 6599 + 150, 6599 + 300, new Vector2(0.2f, 0.1f), new Vector2(0.1f, 0.1f));
            sprite.ScaleVec(OsbEasing.InCirc, 7216, 7319, new Vector2(0.1f, 0.1f), new Vector2(0.3f, 0.1f));
            sprite.Rotate(7419, 7627, 0, Math.PI);
            sprite.ScaleVec(OsbEasing.OutCirc, 7319, 7627, new Vector2(0.3f, 0.1f), new Vector2(0f, 0f));
        }

        public void MakeIT()
        {
            var sprite = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(160, 150));
            var sprite2 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(470, 150));

            sprite.ScaleVec(9271, 200, 100);
            sprite2.ScaleVec(9271, 100, 100);

            sprite.ScaleVec(OsbEasing.OutBounce, 9271, 9887 - 150, new Vector2(200, 100), new Vector2(75f, 100));
            sprite2.ScaleVec(OsbEasing.OutBounce, 9271, 9887 - 150, new Vector2(100, 100), new Vector2(200 - 75f + 100f, 100));

            sprite.Fade(9271, 1);
            sprite.Fade(9887, 0);
            sprite2.Fade(9271, 1);
            sprite2.Fade(9887, 0);
        }

        public void Stomp()
        {

            var ball = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 350));
            var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(650, 100));

            ball.ScaleVec(10915, 0.05, 0.05);
            cube.ScaleVec(10915, 0.125, 0.125);

            cube.MoveY(OsbEasing.OutExpo, 10915, 11325, -50, 320);
            ball.ScaleVec(OsbEasing.OutExpo, 11017, 11325, new Vector2(0.05f, 0.05f), new Vector2(0.12f, 0.025f));
            ball.MoveY(OsbEasing.OutExpo, 11017, 11325, 350, 380);

            cube.MoveY(OsbEasing.OutExpo, 11325, 11736, 320, -150);
            ball.ScaleVec(OsbEasing.OutExpo, 11325, 11325 + 100, new Vector2(0.12f, 0.025f), new Vector2(0.05f, 0.05f));

            ball.Fade(10915, 1);
            ball.Fade(11736, 0);
            cube.Fade(10915, 1);
            cube.Fade(11736, 0);


        }

        public void FunkyNow()
        {
            var sprite = GetLayer("").CreateAnimation("sb/ani/funkynow/frame-.jpeg", 14, (12558 - 11736) / 14, OsbLoopType.LoopOnce, OsbOrigin.Centre);
            sprite.Scale(11736, 0.3);
            sprite.Fade(11736, 1);
            sprite.Fade(12558, 0);
        }

        public void PreDrop()
        {
            var cube = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(-150, 240));
            var ball = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 240));

            var ball1 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(-160, 240));
            var ball2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(-160, 240));
            var ball3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 100));
            var ball4 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 170));
            var ball5 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 310));
            var ball6 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 380));
            var ball7 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 240));
            var ball8 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(900, 240));

            ball.ScaleVec(14202, 0.05, 0.05);
            cube.ScaleVec(14202, 0.05, 0.05);

            ball.Color(14202, new Color4(173, 68, 84, 255));
            cube.Color(14202, new Color4(59, 81, 104, 255));
            ball1.Color(14202, new Color4(59, 81, 104, 255));
            ball2.Color(14202, new Color4(59, 81, 104, 255));
            ball3.Color(14202, new Color4(59, 81, 104, 255));
            ball4.Color(14202, new Color4(59, 81, 104, 255));
            ball5.Color(14202, new Color4(59, 81, 104, 255));
            ball6.Color(14202, new Color4(59, 81, 104, 255));
            ball7.Color(14202, new Color4(59, 81, 104, 255));
            ball8.Color(14202, new Color4(59, 81, 104, 255));

            cube.MoveX(OsbEasing.None, 14202, 16668, -100, 320);
            ball.MoveX(OsbEasing.None, 14202, 16668, 400, 320);

            ball.Color(16668, new Color4(255, 255, 255, 255));

            cube.ScaleVec(16668, new Vector2(0.00f, 0.05f));
            ball.ScaleVec(OsbEasing.InCirc, 17079, 17284, new Vector2(0.05f, 0.05f), new Vector2(0.00f, 0.025f));
            cube.ScaleVec(OsbEasing.OutCirc, 17284, 17490, new Vector2(0.00f, 0.025f), new Vector2(0.025f, 0.025f));

            cube.ScaleVec(17490, 0.025, 0.025);
            ball1.ScaleVec(17490, 0.025, 0.025);
            ball2.ScaleVec(17490, 0.025, 0.025);
            ball3.ScaleVec(17490, 0.025, 0.025);
            ball4.ScaleVec(17490, 0.025, 0.025);
            ball5.ScaleVec(17490, 0.025, 0.025);
            ball6.ScaleVec(17490, 0.025, 0.025);
            ball7.ScaleVec(17490, 0.025, 0.025);
            ball8.ScaleVec(17490, 0.025, 0.025);

            ball1.MoveX(OsbEasing.OutSine, 17490, 19134, -160, 220);
            ball2.MoveX(OsbEasing.OutSine, 17490, 19134, -310, 120);
            ball7.MoveX(OsbEasing.OutSine, 17490, 19134, 900, 420);
            ball8.MoveX(OsbEasing.OutSine, 17490, 19134, 1020, 520);
            ball4.MoveX(OsbEasing.OutSine, 17490, 19134, 1020, 470);
            ball5.MoveX(OsbEasing.OutSine, 17490, 19134, 1020, 470);
            ball3.MoveX(OsbEasing.OutSine, 17490, 19134, 1020, 370);
            ball6.MoveX(OsbEasing.OutSine, 17490, 19134, 1020, 370);

            FlipDot(ball8, 19134);
            FlipDot(ball4, 19134 + 50);
            FlipDot(ball5, 19134 + 50);
            FlipDot(ball7, 19134 + 100);
            FlipDot(ball3, 19134 + 150);
            FlipDot(ball6, 19134 + 150);
            FlipDot(cube, 19134 + 200);
            FlipDot(ball1, 19134 + 250);
            FlipDot(ball2, 19134 + 300);

            ball1.Fade(14202, 1);
            ball2.Fade(14202, 1);
            ball3.Fade(14202, 1);
            ball4.Fade(14202, 1);
            ball5.Fade(14202, 1);
            ball6.Fade(14202, 1);
            ball7.Fade(14202, 1);
            ball8.Fade(14202, 1);

            ball1.Fade(19956, 0);
            ball2.Fade(19956, 0);
            ball3.Fade(19956, 0);
            ball4.Fade(19956, 0);
            ball5.Fade(19956, 0);
            ball6.Fade(19956, 0);
            ball7.Fade(19956, 0);
            ball8.Fade(19956, 0);

            var dots = GetLayer("").CreateSprite("sb/arrow.png", OsbOrigin.Centre);
            double theta = -2;

            dots.ScaleVec(19956, 0.1, 0.1);
            dots.Rotate(19956, 0);
            dots.Move(OsbEasing.OutCirc, 19956, 20367, new Vector2(250, 240), new Vector2(320, 240));
            dots.Rotate(OsbEasing.OutCirc, 20264, 20475, 0, theta);

            double distance = 100;     // Adjust this to move the sprite further or closer
            double dx = distance * Math.Cos(theta);
            double dy = distance * Math.Sin(theta);

            Vector2 startPosition = new Vector2(320, 240);
            Vector2 endPosition = new Vector2(startPosition.X + (float)dx, startPosition.Y + (float)dy);

            dots.Move(OsbEasing.OutCirc, 20367, 20769, startPosition, endPosition);

            dots.Fade(19956, 1);
            dots.Fade(20784, 0);

            cube.Fade(14202, 1);
            cube.Fade(19956, 0);
            ball.Fade(14202, 1);
            ball.Fade(19956, 0);
        }

        public void Puzzel()
        {

            var square0 = GetLayer("").CreateSprite("sb/white.png");
            var gap = GetLayer("").CreateSprite("sb/gapped.png");

            square0.ScaleVec(20780, 50, 50);
            gap.ScaleVec(20780, 0.5, 0.5);

            square0.Rotate(OsbEasing.OutCirc, 20780, 21188 - 50, -2.5, 0);
            gap.Rotate(20780, 21188 - 50, -0.3, 0);

            square0.Color(20780, new Color4(213, 84, 104, 255));
            gap.Color(20780, new Color4(56, 79, 100, 255));

            gap.MoveY(20778, 220);
            square0.MoveY(20778, 160);

            gap.MoveX(OsbEasing.OutCirc, 20778, 21188, 280, 320);
            gap.MoveY(OsbEasing.OutCirc, 20778, 21188, 220, 240);
            square0.MoveX(OsbEasing.OutCirc, 20778, 21188, 150, 293);
            square0.MoveY(OsbEasing.OutCirc, 21086, 21188, 160, 214);

            var squares = GetLayer("").CreateSprite("sb/squares.png", OsbOrigin.Centre, gap.PositionAt(21188));
            squares.Rotate(21188, gap.RotationAt(21188));
            squares.ScaleVec(21188, gap.ScaleAt(21188));

            var extension0 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.BottomCentre, new Vector2(320 - 27.5f, 240 - 50));
            var extension1 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, new Vector2(320 + 50, 240 - 27.5f));
            var extension2 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, new Vector2(320 + 27.5f, 240 + 50));
            var extension3 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, new Vector2(320 - 50, 240 + 27.5f));

            extension0.Color(21188, new Color4(213, 84, 104, 255));
            extension1.Color(21188, new Color4(56, 79, 100, 255));
            extension2.Color(21188, new Color4(56, 79, 100, 255));
            extension3.Color(21188, new Color4(56, 79, 100, 255));

            extension0.Rotate(21188, 0);

            double interval = 21599 - 21188;
            double currentTime = 21188;

            extension0.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));
            extension1.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));
            extension2.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));
            extension3.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));

            currentTime += interval;

            var extension4 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, Vector2.Add(extension0.PositionAt(currentTime), new Vector2(25, -75)));
            var extension5 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension1.PositionAt(currentTime), new Vector2(75, 25)));
            var extension6 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension2.PositionAt(currentTime), new Vector2(0, 100)));
            var extension7 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension3.PositionAt(currentTime), new Vector2(-75, 25)));

            extension4.Color(currentTime, new Color4(56, 79, 100, 255));
            extension5.Color(currentTime, new Color4(56, 79, 100, 255));
            extension6.Color(currentTime, new Color4(56, 79, 100, 255));
            extension7.Color(currentTime, new Color4(56, 79, 100, 255));

            extension4.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));
            extension5.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));
            extension6.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));
            extension7.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));

            currentTime += interval;

            var extension8 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, Vector2.Add(extension5.PositionAt(currentTime), new Vector2(25, 75)));
            var extension9 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, Vector2.Add(extension6.PositionAt(currentTime), new Vector2(-25, 75)));
            var extension10 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, Vector2.Add(extension7.PositionAt(currentTime), new Vector2(-25, 75)));

            extension8.Color(currentTime, new Color4(56, 79, 100, 255));
            extension9.Color(currentTime, new Color4(56, 79, 100, 255));
            extension10.Color(currentTime, new Color4(56, 79, 100, 255));

            extension8.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));
            extension9.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));
            extension10.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));

            interval *= 0.5;

            currentTime += interval;

            var extension11 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension8.PositionAt(currentTime), new Vector2(75, 25)));
            var extension16 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension9.PositionAt(currentTime), new Vector2(-75, 25)));

            extension11.Color(currentTime, new Color4(56, 79, 100, 255));
            extension16.Color(currentTime, new Color4(56, 79, 100, 255));

            extension11.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));
            extension16.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + (interval * 2), new Vector2(50, 0), new Vector2(50, 100));

            currentTime += interval;

            var extension12 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, Vector2.Add(extension11.PositionAt(currentTime), new Vector2(25, 75)));
            var extension17 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreRight, Vector2.Add(extension9.PositionAt(currentTime), new Vector2(-50, 100)));

            extension12.Color(currentTime, new Color4(56, 79, 100, 255));
            extension17.Color(currentTime, new Color4(56, 79, 100, 255));

            extension12.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));
            extension17.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));

            currentTime += interval;

            var extension13 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension12.PositionAt(currentTime), new Vector2(75, 25)));

            extension13.Color(currentTime, new Color4(56, 79, 100, 255));

            extension13.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));

            currentTime += interval;

            var extension14 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.CentreLeft, Vector2.Add(extension13.PositionAt(currentTime), new Vector2(25, 75)));

            extension14.Color(currentTime, new Color4(56, 79, 100, 255));

            extension14.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(0, 50), new Vector2(100, 50));

            currentTime += interval;

            var extension15 = GetLayer("").CreateSprite("sb/white.png", OsbOrigin.TopCentre, Vector2.Add(extension14.PositionAt(currentTime), new Vector2(75, 25)));

            extension15.Color(currentTime, new Color4(56, 79, 100, 255));

            extension15.ScaleVec(OsbEasing.OutCirc, currentTime, currentTime + interval, new Vector2(50, 0), new Vector2(50, 100));

            triggerMovement(squares);
            triggerMovement(extension0);
            triggerMovement(extension1);
            triggerMovement(extension2);
            triggerMovement(extension3);
            triggerMovement(extension4);
            triggerMovement(extension5);
            triggerMovement(extension6);
            triggerMovement(extension7);
            triggerMovement(extension8);
            triggerMovement(extension9);
            triggerMovement(extension10);
            triggerMovement(extension11);
            triggerMovement(extension12);
            triggerMovement(extension13);
            triggerMovement(extension14);
            triggerMovement(extension15);
            triggerMovement(extension16);
            triggerMovement(extension17);

            extension0.Fade(21188, 1);
            extension0.Fade(23243, 0);
            extension1.Fade(21188, 1);
            extension1.Fade(23243, 0);
            extension2.Fade(21188, 1);
            extension2.Fade(23243, 0);
            extension3.Fade(21188, 1);
            extension3.Fade(23243, 0);
            extension4.Fade(21188, 1);
            extension4.Fade(23243, 0);
            extension5.Fade(21188, 1);
            extension5.Fade(23243, 0);
            extension6.Fade(21188, 1);
            extension6.Fade(23243, 0);
            extension7.Fade(21188, 1);
            extension7.Fade(23243, 0);
            extension8.Fade(21188, 1);
            extension8.Fade(23243, 0);
            extension9.Fade(21188, 1);
            extension9.Fade(23243, 0);
            extension10.Fade(21188, 1);
            extension10.Fade(23243, 0);

            squares.Fade(21188, 1);
            squares.Fade(23243, 0);
            square0.Fade(20778, 1);
            square0.Fade(21188, 0);
            gap.Fade(20778, 1);
            gap.Fade(21188, 0);

            var circle = GetLayer("").CreateSprite("sb/circle.png");
            circle.ScaleVec(23243, 0.05, 0.02);
            circle.Color(23243, new Color4(56, 79, 100, 255));
            circle.Fade(23243, 1);
            circle.Fade(24065, 0);

            var cube = GetLayer("").CreateSprite("sb/cube.png");
            cube.Scale(23243, 0.05);
            cube.Rotate(23243, 24065, -Math.PI / 4, Math.PI / 4);
            cube.Fade(23243, 1);
            cube.Fade(24065, 0);

            var cut = GetLayer("").CreateSprite("sb/cut.png", OsbOrigin.TopCentre);
            cut.ScaleVec(23243, 0.335, 0.335);
            cut.Fade(23243, 1);
            cut.Fade(24065, 0);

            cube.MoveX(OsbEasing.OutSine, 23243, 24065, 250, 330);
            cube.MoveY(OsbEasing.OutCirc, 23243, 23640, 160, 150);
            cube.MoveY(OsbEasing.InCirc, 23640, 24057 - 250, 150, 300);
        }

        public void Holes()
        {
            var xStart = -50;
            var xOffset = 150;

            for (int i = 0; i < 8; i++)
            {
                var circle = GetLayer("").CreateSprite("sb/circle.png");
                circle.ScaleVec(24065, 0.05, 0.02);
                circle.Color(24065, new Color4(56, 79, 100, 255));
                circle.Fade(24065, 1);
                circle.Fade(25709, 0);

                circle.MoveY(24065, 300);

                circle.MoveX(24065, xStart + xOffset * i);

                circle.MoveX(OsbEasing.OutSine, 24065, 25504, xStart + xOffset * i, xStart + xOffset * i - xOffset * 2);

            }

            var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.TopCentre);
            cube.Scale(24065, 0.075);
            cube.Fade(24065, 1);
            cube.Fade(25709, 0);
            cube.Color(24065, new Color4(173, 68, 84, 255));
            cube.MoveY(24065, 200 + 60);
            cube.MoveY(OsbEasing.InSine, 24468, 24887, 200 + 60, 280 + 60);
            cube.MoveX(OsbEasing.OutSine, 24065, 25504, xStart + xOffset * 2, xStart + xOffset * 2 - xOffset * 2);

            var cube2 = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.TopCentre);
            cube2.Scale(24065, 0.075);
            cube2.Fade(24065, 1);
            cube2.Fade(25709, 0);
            cube2.Color(24065, new Color4(173, 68, 84, 255));
            cube2.MoveY(24065, 280 + 60);
            cube2.MoveY(OsbEasing.OutSine, 25093, 25298, 280 + 60, 200 + 60);
            cube2.MoveX(OsbEasing.OutSine, 24065, 25504, xStart + xOffset * 5, xStart + xOffset * 5 - xOffset * 2);

            var cut = GetLayer("").CreateSprite("sb/white_cut.png", OsbOrigin.TopCentre);
            cut.ScaleVec(24065, 0.335, 0.335);
            cut.Fade(24065, 1);
            cut.Fade(25709, 0);
            cut.Color(24065, new Color4(255, 255, 255, 255));
            cut.MoveY(24065, 240 + 60);
            cut.MoveX(OsbEasing.OutSine, 24065, 25504, xStart + xOffset * 2, xStart + xOffset * 2 - xOffset * 2);

            var cut2 = GetLayer("").CreateSprite("sb/white_cut.png", OsbOrigin.TopCentre);
            cut2.ScaleVec(24065, 0.335, 0.335);
            cut2.Fade(24065, 1);
            cut2.Fade(25709, 0);
            cut2.MoveY(24065, 240 + 60);
            cut2.Color(24065, new Color4(255, 255, 255, 255));
            cut2.MoveX(OsbEasing.OutSine, 24065, 25504, xStart + xOffset * 5, xStart + xOffset * 5 - xOffset * 2);

            var hammer = GetLayer("").CreateSprite("sb/hammer.jpg", OsbOrigin.Centre);
            hammer.Fade(24065, 1);
            hammer.Scale(24065, 0.4);
            hammer.Fade(25709, 0);
            hammer.Move(OsbEasing.OutSine, 24476, 25401, new Vector2(800, 160), new Vector2(550, 150));
            hammer.Rotate(OsbEasing.OutCirc, 25401, 25709, 0, 1.1);
            hammer.Move(OsbEasing.OutSine, 25401, 25709, new Vector2(550, 150), new Vector2(600, 150));

        }

        public void triggerMovement(OsbSprite sprite)
        {

            Vector2 movement = new Vector2(-500, -250);
            sprite.Move(OsbEasing.InOutSine, 21599, 23243, sprite.PositionAt(21599), Vector2.Add(sprite.PositionAt(21599), movement));

        }

        public void Transiton()
        {
            var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            cube.ScaleVec(25709, new Vector2(0.1f, 0.1f));
            cube.Color(25709, new Color4(255, 255, 255, 255));

            var cubeMirror = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            cubeMirror.ScaleVec(25709, new Vector2(0.1f, 0.1f));
            cubeMirror.Color(25709, new Color4(255, 255, 255, 255));

            cube.ScaleVec(OsbEasing.OutCirc, 25709, 26017, new Vector2(0.4f, 0.5f), new Vector2(0.3f, 0.3f));
            cube.ScaleVec(OsbEasing.OutCirc, 26017, 26325, new Vector2(0.3f, 0.3f), new Vector2(0.2f, 0.2f));
            cube.ScaleVec(OsbEasing.OutCirc, 26325, 26634, new Vector2(0.1f, 0.2f), new Vector2(0.1f, 0.1f));

            cubeMirror.ScaleVec(OsbEasing.OutCirc, 25709, 26017, new Vector2(0.4f, 0.5f), new Vector2(0.3f, 0.3f));
            cubeMirror.ScaleVec(OsbEasing.OutCirc, 26017, 26325, new Vector2(0.3f, 0.3f), new Vector2(0.2f, 0.2f));
            cubeMirror.ScaleVec(OsbEasing.OutCirc, 26325, 26634, new Vector2(0.1f, 0.2f), new Vector2(0.1f, 0.1f));

            cube.MoveX(OsbEasing.OutCirc, 25709, 26017, 800, 700);
            cube.MoveX(OsbEasing.OutCirc, 26017, 26325, 700, 500);
            cube.MoveX(OsbEasing.OutCirc, 26325, 26634, 500, 320);

            cubeMirror.MoveX(OsbEasing.OutCirc, 25709, 26017, -160, -60);
            cubeMirror.MoveX(OsbEasing.OutCirc, 26017, 26325, -60, 140);
            cubeMirror.MoveX(OsbEasing.OutCirc, 26325, 26634, 140, 320);

            double radians = Math.PI / 4;

            cube.Rotate(OsbEasing.OutCirc, 26634, 26736, 0, radians);
            cube.Rotate(OsbEasing.OutCirc, 26736, 26839, radians, radians * 2);
            cube.Rotate(OsbEasing.OutCirc, 26839, 26942, radians * 2, radians * 3);

            cube.Rotate(OsbEasing.OutCirc, 26944, 30000, radians * 3, -radians * 5);
            cube.MoveY(OsbEasing.OutSine, 26944, 27147, 240, 150);
            cube.MoveY(OsbEasing.InSine, 27147, 27353, 150, 300);

            cubeMirror.Fade(25709, 1);
            cubeMirror.Fade(26634, 0);

            cube.Fade(25709, 1);
            cube.Fade(27353 - 100, 27353, 1, 0);
        }

        public void BuildUpFirst()
        {

            var cube3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube1 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);

            cube.ScaleVec(OsbEasing.OutBounce, 27352, 27764, new Vector2(0, 0), new Vector2(0.05f, 0.05f));
            cube1.ScaleVec(OsbEasing.OutBounce, 27352, 27764, new Vector2(0, 0), new Vector2(0.05f, 0.05f));
            cube2.ScaleVec(OsbEasing.OutBounce, 27352, 27764, new Vector2(0, 0), new Vector2(0.05f, 0.05f));
            cube3.ScaleVec(OsbEasing.OutBounce, 27352, 27764, new Vector2(0, 0), new Vector2(0.05f, 0.05f));

            cube.Color(27352, new Color4(46, 65, 82, 255));
            cube1.Color(27352, new Color4(46, 65, 82, 255));
            cube2.Color(27352, new Color4(46, 65, 82, 255));
            cube3.Color(27352, new Color4(46, 65, 82, 255));

            cube.MoveX(OsbEasing.OutCirc, 27969, 27969 + 200, 320, 0);
            cube1.MoveX(OsbEasing.OutCirc, 28072, 28072 + 200, 320, 650);
            cube2.MoveX(OsbEasing.OutCirc, 27969, 27969 + 200, 320, 0);
            cube3.MoveX(OsbEasing.OutCirc, 28072, 28072 + 200, 320, 650);

            cube.MoveY(OsbEasing.OutCirc, 27969, 27969 + 200, 240, 100);
            cube1.MoveY(OsbEasing.OutCirc, 28072, 28072 + 200, 240, 100);
            cube2.MoveY(OsbEasing.OutCirc, 27969, 27969 + 200, 240, 350);
            cube3.MoveY(OsbEasing.OutCirc, 28072, 28072 + 200, 240, 350);

            FlipDot(cube, 28586);
            FlipDot(cube1, 28688);
            FlipDot(cube2, 28791);
            FlipDot(cube3, 28894);

            cube.MoveY(OsbEasing.InOutSine, 29408, 29613, 100, 430);
            cube1.MoveY(OsbEasing.InOutSine, 29408, 29613, 100, 430);
            cube2.MoveY(OsbEasing.InOutSine, 29408, 29613, 350, 50);
            cube3.MoveY(OsbEasing.InOutSine, 29408, 29613, 350, 50);

            cube.MoveY(OsbEasing.InOutSine, 29613, 29819, 430, -20);
            cube1.MoveY(OsbEasing.InOutSine, 29613, 29819, 430, -20);
            cube2.MoveY(OsbEasing.InOutSine, 29613, 29819, 50, 500);
            cube3.MoveY(OsbEasing.InOutSine, 29613, 29819, 50, 500);

            var newCube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);

            double radians = Math.PI / 4;
            newCube.ScaleVec(29921, 0.1, 0.1);
            newCube.Rotate(29921, 0);
            newCube.Rotate(OsbEasing.OutCirc, 29921, 30024, 0, radians);
            newCube.Rotate(OsbEasing.OutCirc, 30024, 30127, radians, radians * 2);
            newCube.Rotate(OsbEasing.OutCirc, 30127, 30230, radians * 2, radians * 3);

            newCube.Rotate(OsbEasing.OutCirc, 30230, 31052, radians * 3, -radians * 5);
            newCube.MoveY(OsbEasing.OutSine, 30230, 30435, 240, 150);
            newCube.MoveY(OsbEasing.InSine, 30435, 30641, 150, 300);

            newCube.Fade(29819, 1);
            newCube.Fade(30641 - 100, 30641, 1, 0);

            cube.Fade(27353, 1);
            cube.Fade(29819, 0);
            cube1.Fade(27353, 1);
            cube1.Fade(29819, 0);
            cube2.Fade(27353, 1);
            cube2.Fade(29819, 0);
            cube3.Fade(27353, 1);
            cube3.Fade(29819, 0);

            var square = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(0, 500));
            square.Color(30641, new Color4(255, 225, 255, 255));
            square.ScaleVec(30641, new Vector2(0.1f, 0.1f));
            square.MoveY(OsbEasing.OutCirc, 30641, 31052, 520, 100);
            square.MoveY(OsbEasing.InCirc, 31052, 31462, 100, 520);

            double x = square.PositionAt(31154).X;
            double currentTime = 31154;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;

            square.MoveX(31462, 650);
            square.MoveY(OsbEasing.OutCirc, 31462, 31873, -50, 300);
            square.Color(31873, new Color4(255, 225, 52, 255));
            square.Rotate(OsbEasing.InSine, 31873, 32284, 0, -Math.PI / 2);
            square.MoveY(OsbEasing.InCirc, 31873, 32284, 300, -50);


            square.Fade(30641, 1);
            square.Fade(32284, 0);

            var circle = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 50));
            var circle2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 430));
            var circle3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 50));
            var circle4 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 430));

            circle.ScaleVec(32695, 0.03, 0.03);
            circle2.ScaleVec(32695, 0.03, 0.03);
            circle3.ScaleVec(32695, 0.03, 0.03);
            circle4.ScaleVec(32695, 0.03, 0.03);

            circle.Color(32695, new Color4(57, 80, 101, 255));
            circle2.Color(32695, new Color4(57, 80, 101, 255));
            circle3.Color(32695, new Color4(57, 80, 101, 255));
            circle4.Color(32695, new Color4(57, 80, 101, 255));

            circle.MoveY(OsbEasing.InOutSine, 32695, 33106, -10, 430);
            circle3.MoveY(OsbEasing.InOutSine, 32695, 33106, -10, 430);
            circle2.MoveY(OsbEasing.InOutSine, 32695, 33106, 480, 50);
            circle4.MoveY(OsbEasing.InOutSine, 32695, 33106, 480, 50);

            circle.MoveY(OsbEasing.InOutSine, 33106, 33517, 430, 50);
            circle3.MoveY(OsbEasing.InOutSine, 33106, 33517, 430, 50);
            circle2.MoveY(OsbEasing.InOutSine, 33106, 33517, 50, 430);
            circle4.MoveY(OsbEasing.InOutSine, 33106, 33517, 50, 430);

            circle.MoveY(OsbEasing.InOutSine, 33517, 33928, 50, 240);
            circle3.MoveY(OsbEasing.InOutSine, 33517, 33928, 50, 240);
            circle2.MoveY(OsbEasing.InOutSine, 33517, 33928, 430, 240);
            circle4.MoveY(OsbEasing.InOutSine, 33517, 33928, 430, 240);

            circle.MoveX(OsbEasing.InOutSine, 33517, 33928, 25, 320);
            circle3.MoveX(OsbEasing.InOutSine, 33517, 33928, 650, 320);
            circle2.MoveX(OsbEasing.InOutSine, 33517, 33928, 25, 320);
            circle4.MoveX(OsbEasing.InOutSine, 33517, 33928, 650, 320);

            circle.ScaleVec(OsbEasing.InOutSine, 33517, 33928, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle3.ScaleVec(OsbEasing.InOutSine, 33517, 33928, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle2.ScaleVec(OsbEasing.InOutSine, 33517, 33928, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle4.ScaleVec(OsbEasing.InOutSine, 33517, 33928, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));

            circle.ScaleVec(OsbEasing.None, 33928, 33928 + 200, new Vector2(0.075f, 0.075f), new Vector2(1, 1));

            cube.Fade(36394, 1);
            cube.Fade(36908, 0);

            BuildUpSecond(33928);

        }

        public void BuildUpSecond(double start)
        {

            double offset = start - 27352;

            var cube3 = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            var cube2 = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            var cube1 = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);
            var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);

            cube.ScaleVec(27352 + offset, 0.1, 0.1);
            cube1.ScaleVec(27352 + offset, 0.1, 0.1);
            cube2.ScaleVec(27352 + offset, 0.1, 0.1);
            cube3.ScaleVec(27352 + offset, 0.1, 0.1);

            cube.Color(27352 + offset, new Color4(0, 185, 219, 255));
            cube1.Color(27352 + offset, new Color4(0, 185, 219, 255));
            cube2.Color(27352 + offset, new Color4(0, 185, 219, 255));
            cube3.Color(27352 + offset, new Color4(0, 185, 219, 255));

            cube.Rotate(27352 + offset, 34339, 0, Math.PI / 4);
            cube1.Rotate(27352 + offset, 34339, 0, Math.PI / 4);
            cube2.Rotate(27352 + offset, 34339, 0, Math.PI / 4);
            cube3.Rotate(27352 + offset, 34339, 0, Math.PI / 4);

            cube.MoveX(OsbEasing.OutCirc, 27969 + offset, 27969 + offset + 200, 320, 0);
            cube1.MoveX(OsbEasing.OutCirc, 28072 + offset, 28072 + offset + 200, 320, 650);
            cube2.MoveX(OsbEasing.OutCirc, 27969 + offset, 27969 + offset + 200, 320, 0);
            cube3.MoveX(OsbEasing.OutCirc, 28072 + offset, 28072 + offset + 200, 320, 650);

            cube.MoveY(OsbEasing.OutCirc, 27969 + offset, 27969 + offset + 200, 240, 100);
            cube1.MoveY(OsbEasing.OutCirc, 28072 + offset, 28072 + offset + 200, 240, 100);
            cube2.MoveY(OsbEasing.OutCirc, 27969 + offset, 27969 + offset + 200, 240, 350);
            cube3.MoveY(OsbEasing.OutCirc, 28072 + offset, 28072 + offset + 200, 240, 350);

            FlipSquare(cube, 28586 + offset);
            FlipSquare(cube1, 28688 + offset);
            FlipSquare(cube2, 28791 + offset);
            FlipSquare(cube3, 28894 + offset);

            cube.MoveY(OsbEasing.InOutSine, 29408 + offset, 29613 + offset, 100, 430);
            cube1.MoveY(OsbEasing.InOutSine, 29408 + offset, 29613 + offset, 100, 430);
            cube2.MoveY(OsbEasing.InOutSine, 29408 + offset, 29613 + offset, 350, 50);
            cube3.MoveY(OsbEasing.InOutSine, 29408 + offset, 29613 + offset, 350, 50);

            cube.MoveY(OsbEasing.InOutSine, 29613 + offset, 29819 + offset, 430, -35);
            cube1.MoveY(OsbEasing.InOutSine, 29613 + offset, 29819 + offset, 430, -35);
            cube2.MoveY(OsbEasing.InOutSine, 29613 + offset, 29819 + offset, 50, 515);
            cube3.MoveY(OsbEasing.InOutSine, 29613 + offset, 29819 + offset, 50, 515);

            var newCube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);

            double radians = Math.PI / 4;
            newCube.ScaleVec(29921 + offset, 0.1, 0.1);
            newCube.Rotate(29921 + offset, 0);
            newCube.Color(29921 + offset, new Color4(57, 80, 101, 255));
            newCube.Rotate(OsbEasing.OutCirc, 29921 + offset, 30024 + offset, 0, radians);
            newCube.Rotate(OsbEasing.OutCirc, 30024 + offset, 30127 + offset, radians, radians * 2);
            newCube.Rotate(OsbEasing.OutCirc, 30127 + offset, 30230 + offset, radians * 2, radians * 3);

            newCube.Rotate(OsbEasing.OutCirc, 30230 + offset, 31052 + offset, radians * 3, -radians * 5);
            newCube.MoveY(OsbEasing.OutSine, 30230 + offset, 30435 + offset, 240, 150);
            newCube.MoveY(OsbEasing.InSine, 30435 + offset, 30641 + offset, 150, 300);

            newCube.Fade(29819 + offset, 1);
            newCube.Fade(30641 + offset - 100, 30641 + offset, 1, 0);

            cube.Fade(27353 + offset, 1);
            cube.Fade(29819 + offset, 0);
            cube1.Fade(27353 + offset, 1);
            cube1.Fade(29819 + offset, 0);
            cube2.Fade(27353 + offset, 1);
            cube2.Fade(29819 + offset, 0);
            cube3.Fade(27353 + offset, 1);
            cube3.Fade(29819 + offset, 0);

            var square = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(0, 500));
            square.Color(30641 + offset, new Color4(255, 225, 255, 255));
            square.ScaleVec(30641 + offset, new Vector2(0.1f, 0.1f));
            square.MoveY(OsbEasing.OutCirc, 30641 + offset, 31052 + offset, 520, 100);
            square.MoveY(OsbEasing.InCirc, 31052 + offset, 31462 + offset, 100, 520);

            double x = square.PositionAt(31154 + offset).X;
            double currentTime = 31154 + offset;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-50, 50));
            currentTime += 25;

            square.MoveX(31462 + offset, 650);
            square.MoveY(OsbEasing.OutCirc, 31462 + offset, 31873 + offset, -50, 300);
            square.Color(31873 + offset, new Color4(255, 225, 52, 255));
            square.Rotate(OsbEasing.InSine, 31873 + offset, 32284 + offset, 0, -Math.PI / 2);
            square.MoveY(OsbEasing.InCirc, 31873 + offset, 32284 + offset, 300, -50);


            square.Fade(30641 + offset, 1);
            square.Fade(32284 + offset, 0);

            var circle = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 50));
            var circle2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 430));
            var circle3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 50));
            var circle4 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 430));

            circle.ScaleVec(32695 + offset, 0.03, 0.03);
            circle2.ScaleVec(32695 + offset, 0.03, 0.03);
            circle3.ScaleVec(32695 + offset, 0.03, 0.03);
            circle4.ScaleVec(32695 + offset, 0.03, 0.03);

            circle.Color(32695 + offset, new Color4(1, 184, 218, 255));
            circle2.Color(32695 + offset, new Color4(1, 184, 218, 255));
            circle3.Color(32695 + offset, new Color4(1, 184, 218, 255));
            circle4.Color(32695 + offset, new Color4(1, 184, 218, 255));

            circle.MoveY(OsbEasing.InOutSine, 32695 + offset, 33106 + offset, -10, 430);
            circle3.MoveY(OsbEasing.InOutSine, 32695 + offset, 33106 + offset, -10, 430);
            circle2.MoveY(OsbEasing.InOutSine, 32695 + offset, 33106 + offset, 480, 50);
            circle4.MoveY(OsbEasing.InOutSine, 32695 + offset, 33106 + offset, 480, 50);

            circle.MoveY(OsbEasing.InOutSine, 33106 + offset, 33517 + offset, 430, 50);
            circle3.MoveY(OsbEasing.InOutSine, 33106 + offset, 33517 + offset, 430, 50);
            circle2.MoveY(OsbEasing.InOutSine, 33106 + offset, 33517 + offset, 50, 430);
            circle4.MoveY(OsbEasing.InOutSine, 33106 + offset, 33517 + offset, 50, 430);

            circle.MoveY(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 50, 240);
            circle3.MoveY(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 50, 240);
            circle2.MoveY(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 430, 240);
            circle4.MoveY(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 430, 240);

            circle.MoveX(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 25, 320);
            circle3.MoveX(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 650, 320);
            circle2.MoveX(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 25, 320);
            circle4.MoveX(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, 650, 320);

            circle.ScaleVec(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle3.ScaleVec(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle2.ScaleVec(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle4.ScaleVec(OsbEasing.InOutSine, 33517 + offset, 33928 + offset, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));

            circle.ScaleVec(OsbEasing.None, 33928 + offset, 33928 + offset + 200, new Vector2(0.075f, 0.075f), new Vector2(1, 1));

            cube.Fade(36394 + offset, 1);
            cube.Fade(36908 + offset, 0);

        }

        public void Drop()
        {

            var cube = GetLayer("").CreateSprite("sb/cube.png");
            cube.ScaleVec(40915, 0.1, 0.1);
            cube.Fade(40915, 1);
            cube.Fade(51188, 0);

            cube.StartLoopGroup(40915, 7);
            cube.ScaleVec(OsbEasing.OutCirc, 0, 200, new Vector2(0.1f, 0.1f), new Vector2(0.15f, 0.1f));
            cube.ScaleVec(OsbEasing.InCirc, 200, 400, new Vector2(0.15f, 0.1f), new Vector2(0.1f, 0.1f));
            cube.EndGroup();

            List<OsbSprite> left = CreateAndMoveCubes(40915, 7, 41325 - 40915, -140);
            List<OsbSprite> right = CreateAndMoveCubes(40915, 7, 41325 - 40915, 140);

            cube.MoveY(OsbEasing.InSine, 43791, 43997, 240, -50);
            cube.MoveY(OsbEasing.OutSine, 43997, 44408, 500, 325);

            left.ForEach((sprite) =>
            {
                sprite.Rotate(43791, 44202, 0, -Math.PI / 2);
                sprite.MoveY(OsbEasing.InSine, 43791, 43997, 240, -50);
                sprite.MoveY(OsbEasing.OutSine, 43997, 44408, 500, 325);
            });

            right.ForEach((sprite) =>
            {
                sprite.Rotate(43791, 44202, 0, Math.PI / 2);
                sprite.MoveY(OsbEasing.InSine, 43791, 43997, 240, -50);
                sprite.MoveY(OsbEasing.OutSine, 43997, 44408, 500, 325);
            });

            cube.MoveY(OsbEasing.InSine, 47079, 47284, 325, 500);
            cube.MoveY(OsbEasing.OutSine, 47284, 47490, -50, 150);

            left.ForEach((sprite) =>
            {
                sprite.Rotate(47079, 47490, 0, Math.PI / 2);
                sprite.MoveY(OsbEasing.InSine, 47079, 47284, 325, 500);
                sprite.MoveY(OsbEasing.OutSine, 47284, 47490, -50, 150);
            });

            right.ForEach((sprite) =>
            {
                sprite.Rotate(47079, 47490, 0, -Math.PI / 2);
                sprite.MoveY(OsbEasing.InSine, 47079, 47284, 325, 500);
                sprite.MoveY(OsbEasing.OutSine, 47284, 47490, -50, 150);
            });

            double currentTime = 44202;
            for (int i = 0; i < 8; i++)
            {
                double snapDuration = 44613 - 44202;

                MoveCubeHorizontal(cube, currentTime, 200 / 4);

                left.ForEach((sprite) =>
                {
                    MoveCubeHorizontal(sprite, currentTime, 200 / 4);
                });

                right.ForEach((sprite) =>
                {
                    MoveCubeHorizontal(sprite, currentTime, 200 / 4);
                });

                currentTime += snapDuration;

            }

            currentTime = 47490;
            for (int i = 0; i < 7; i++)
            {
                double snapDuration = 44613 - 44202;

                MoveCubeHorizontal(cube, currentTime, -200 / 4);

                left.ForEach((sprite) =>
                {
                    MoveCubeHorizontal(sprite, currentTime, -200 / 4);
                });

                right.ForEach((sprite) =>
                {
                    MoveCubeHorizontal(sprite, currentTime, -200 / 4);
                });

                currentTime += snapDuration;

            }

            cube.MoveY(OsbEasing.OutSine, 50367, 50983, 150, 240);

            left.ForEach((sprite) =>
            {
                sprite.MoveY(OsbEasing.OutSine, 50367, 50983, 150, 240);
            });

            right.ForEach((sprite) =>
            {
                sprite.MoveY(OsbEasing.OutSine, 50367, 50983, 150, 240);
            });


            double interval = 50572 - 50367;

            for (int i = 0; i < 4; i++)
            {

                double movement = 110;

                if (i == 0)
                {
                    movement += -200 / 4;
                }

                int count = left.Count;
                left.ForEach((sprite) =>
                {
                    double currentX = sprite.PositionAt(currentTime).X;
                    sprite.MoveX(OsbEasing.OutCirc, currentTime, currentTime + interval, currentX, currentX + movement);
                });

                movement = -110;

                if (i == 0)
                {
                    movement += -200 / 4;
                }

                count = right.Count;
                right.ForEach((sprite) =>
                {
                    double currentX = sprite.PositionAt(currentTime).X;
                    sprite.MoveX(OsbEasing.OutCirc, currentTime, currentTime + interval, currentX, currentX + movement);
                });

                currentTime += interval;
            }
        }

        List<OsbSprite> CreateAndMoveCubes(int startTime, int numCubes, int interval, double movement)
        {
            List<OsbSprite> cubes = new List<OsbSprite>();

            // Create, scale, and fade cubes
            for (int i = 0; i < numCubes; i++)
            {
                OsbSprite cube = GetLayer("").CreateSprite("sb/cube.png");
                cube.ScaleVec(startTime, 0.1f, 0.1f);
                cube.Fade(startTime, 1);
                cube.Fade(51188, 0);
                cubes.Add(cube);
            }

            // Move cubes based on fixed interval
            for (int i = 0; i < numCubes; i++)
            {
                int time = startTime + (i * interval);

                for (int j = 0; j <= i && j < numCubes; j++)
                {
                    MoveCube(cubes[j], time, movement);
                }
            }

            return cubes;
        }

        List<OsbSprite> CreateAndMoveCircle(int startTime, int numCubes, int interval, double movement)
        {
            List<OsbSprite> cubes = new List<OsbSprite>();

            // Create, scale, and fade cubes
            for (int i = 0; i < numCubes; i++)
            {
                OsbSprite cube = GetLayer("").CreateSprite("sb/circle.png");
                cube.ScaleVec(startTime, 0.04f, 0.04f);
                cube.Fade(startTime, 1);
                cube.Fade(113243, 0);
                cubes.Add(cube);
            }

            // Move cubes based on fixed interval
            for (int i = 0; i < numCubes; i++)
            {
                int time = startTime + (i * interval);

                for (int j = 0; j <= i && j < numCubes; j++)
                {
                    MoveCube(cubes[j], time, movement);
                }
            }

            return cubes;
        }


        public void MoveCube(OsbSprite sprite, double starttime, double movement)
        {

            double startX = sprite.PositionAt(starttime).X;
            double fallBack = -30;

            if (movement < 0)
            {
                fallBack *= -1;
            }

            sprite.MoveX(OsbEasing.OutCirc, starttime, starttime + 200, startX, startX + movement);
            sprite.MoveX(OsbEasing.InCirc, starttime + 200, starttime + 400, startX + movement, startX + movement + fallBack);

        }

        public void MoveCubeHorizontal(OsbSprite sprite, double starttime, double movement)
        {

            double snapDuration = 44613 - 44202;
            sprite.MoveX(OsbEasing.OutCirc, starttime, starttime + snapDuration, sprite.PositionAt(starttime).X, sprite.PositionAt(starttime).X + movement);

        }

        public void DropAnimation()
        {
            var color = GetLayer("").CreateAnimation("sb/ani/color/frame-.jpeg", 24, (52010 - 51188) / 24, OsbLoopType.LoopOnce);
            var suprise = GetLayer("").CreateAnimation("sb/ani/suprise/frame-.jpeg", 50, (53654 - 52010) / 50, OsbLoopType.LoopOnce);

            var bitmap = GetMapsetBitmap("sb/ani/color/frame-0.jpeg");
            color.Scale(51188, 480f / bitmap.Height);
            color.Fade(51188, 1);
            color.Fade(52010, 0);

            suprise.Scale(52010, 480f / bitmap.Height);
            suprise.Fade(52010, 1);
            suprise.Fade(53654, 0);
        }

        public void Countdown()
        {
            var hand = GetLayer("").CreateAnimation("sb/ani/hand/frame-.jpeg", 53, (66805 - 65161) / 53, OsbLoopType.LoopOnce);

            hand.Scale(65161, 0.5);
            hand.Fade(65161, 1);
            hand.Fade(66805, 0);
        }

        public void InterMission()
        {

            var cube = GetLayer("").CreateSprite("sb/cube.png");
            cube.Color(53654, new Color4(49, 69, 88, 255));
            cube.ScaleVec(53654, 0.1, 0.1);
            cube.Fade(53654, 1);
            cube.Fade(60230, 0);


            var cube2 = GetLayer("").CreateSprite("sb/cube.png");
            cube2.Color(55298, new Color4(49, 69, 88, 255));
            cube2.ScaleVec(55298, 0.1, 0.1);
            cube2.Fade(55298, 1);
            cube2.Fade(60230, 0);

            var cube3 = GetLayer("").CreateSprite("sb/cube.png");
            cube3.Color(56942, new Color4(49, 69, 88, 255));
            cube3.ScaleVec(56942, 0.1, 0.1);
            cube3.Fade(56942, 1);
            cube3.Fade(60230, 0);

            cube.Move(OsbEasing.OutSine, 53654, 53654 + 500, new Vector2(-150, 240), new Vector2(50, 240));

            cube.Move(OsbEasing.OutSine, 55298, 55298 + 500, new Vector2(-150, 240), new Vector2(50, 240));
            cube2.Move(OsbEasing.OutSine, 55298, 55298 + 500, new Vector2(800, 240), new Vector2(600, 240));

            cube.Move(OsbEasing.OutSine, 55298, 55298 + 500, new Vector2(-150, 240), new Vector2(50, 240));
            cube2.Move(OsbEasing.OutSine, 55298, 55298 + 500, new Vector2(800, 240), new Vector2(600, 240));

            cube.Move(OsbEasing.OutSine, 56942, 56942 + 500, new Vector2(-150, 240), new Vector2(50, 240));
            cube2.Move(OsbEasing.OutSine, 56942, 56942 + 500, new Vector2(800, 240), new Vector2(600, 240));

            double radians = Math.PI / 6;
            double curerntRadia = 0;
            double currentTime = 53962;
            double interval = 100;

            while (currentTime < 55195)
            {
                cube.Rotate(currentTime, curerntRadia);
                currentTime += interval;
                curerntRadia += radians;

            }

            cube.Rotate(currentTime, 0);

            curerntRadia = 0;
            currentTime = 55606;
            while (currentTime < 56839)
            {
                cube.Rotate(currentTime, curerntRadia);
                cube2.Rotate(currentTime, curerntRadia);
                currentTime += interval;
                curerntRadia += radians;

            }

            cube.Rotate(currentTime, 0);
            cube2.Rotate(currentTime, 0);

            curerntRadia = 0;
            currentTime = 57558;
            while (currentTime < 58483)
            {
                cube.Rotate(currentTime, curerntRadia);
                cube2.Rotate(currentTime, curerntRadia);
                cube3.Rotate(currentTime, curerntRadia);
                currentTime += interval;
                curerntRadia += radians;

            }

            cube.ScaleVec(OsbEasing.OutCirc, 58586, 58997, new Vector2(0.1f, 0.1f), new Vector2(0.2f, 0.1f));
            cube3.ScaleVec(OsbEasing.OutCirc, 58997, 59408, new Vector2(0.1f, 0.1f), new Vector2(0.4f, 0.1f));
            cube2.ScaleVec(OsbEasing.OutCirc, 59408, 59819, new Vector2(0.1f, 0.1f), new Vector2(0.6f, 0.1f));

            cube.Rotate(59819, 60230, curerntRadia, Math.PI * 2);
            cube2.Rotate(59819, 60230, curerntRadia, Math.PI * 2);
            cube3.Rotate(59819, 60230, curerntRadia, Math.PI * 2);

            cube.ScaleVec(OsbEasing.OutCirc, 59819, 60230, new Vector2(0.2f, 0.1f), new Vector2(0.0f, 0.0f));
            cube3.ScaleVec(OsbEasing.OutCirc, 59819, 60230, new Vector2(0.4f, 0.1f), new Vector2(0.0f, 0.0f));
            cube2.ScaleVec(OsbEasing.OutCirc, 59819, 60230, new Vector2(0.6f, 0.1f), new Vector2(0.0f, 0.0f));

            var c = GetLayer("").CreateSprite("sb/c.png");
            c.Rotate(OsbEasing.OutElastic, 60024, 60435, -Math.PI * 2, 0);
            c.Scale(60024, 60230, 0, 0.4);
            c.Fade(60024, 1);
            c.Fade(60846, 0);

        }

        public void MultiCubeCs()
        {

            var cube0 = GetLayer("").CreateSprite("sb/cube.png");
            var cube1 = GetLayer("").CreateSprite("sb/cube.png");
            var cube2 = GetLayer("").CreateSprite("sb/cube.png");
            var cube3 = GetLayer("").CreateSprite("sb/cube.png");

            var scale = 0.08;

            cube0.Scale(60846, scale);
            cube1.Scale(60846, scale);
            cube2.Scale(60846, scale);
            cube3.Scale(60846, scale);

            cube0.Color(60846, new Color4(49, 69, 88, 255));
            cube1.Color(60846, new Color4(49, 69, 88, 255));
            cube2.Color(60846, new Color4(49, 69, 88, 255));
            cube3.Color(60846, new Color4(49, 69, 88, 255));

            cube0.Move(60846, new Vector2(180, 100));
            cube1.Move(60846, new Vector2(180, 380));
            cube2.Move(60846, new Vector2(490, 380));
            cube3.Move(60846, new Vector2(490, 100));

            cube0.Fade(60846, 1);
            cube1.Fade(60846, 1);
            cube2.Fade(60846, 1);
            cube3.Fade(60846, 1);

            double curerntRadia = 0;
            double radians = Math.PI / 6;
            double interval = 100;
            double currentTime = 60846;
            while (currentTime < 61771)
            {
                cube0.Rotate(currentTime, curerntRadia);
                cube1.Rotate(currentTime, curerntRadia);
                cube2.Rotate(currentTime, curerntRadia);
                cube3.Rotate(currentTime, curerntRadia);
                currentTime += interval;
                curerntRadia += radians;
            }

            cube0.Fade(61873, 0);
            cube1.Fade(61873, 0);
            cube2.Fade(61873, 0);
            cube3.Fade(61873, 0);

            float xOff = 854 / 4;

            for (int n = 1; n <= 2; n++)
            {
                for (int i = 0; i < 4; i++)
                {

                    var c0 = GetLayer("").CreateSprite("sb/c.png", OsbOrigin.Centre, new Vector2(xOff * i, n == 1 ? 125 : 350));
                    var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(xOff * i, n == 1 ? 125 : 350));

                    if (n == 1 && i == 0)
                    {
                        RotateC(c0, -Math.PI, -Math.PI / 2);
                    }

                    if (n == 1 && i == 1)
                    {
                        RotateC(c0, Math.PI / 2, 0);
                    }
                    if (n == 1 && i == 2)
                    {
                        RotateC(c0, -Math.PI / 2, -Math.PI);
                    }

                    if (n == 1 && i == 3)
                    {
                        RotateC(c0, -Math.PI, Math.PI / 2);
                    }

                    if (n == 2 && i == 0)
                    {
                        RotateC(c0, -Math.PI / 2, -Math.PI);
                    }

                    if (n == 2 && i == 1)
                    {
                        RotateC(c0, -Math.PI, -Math.PI / 2);
                    }
                    if (n == 2 && i == 2)
                    {
                        RotateC(c0, -Math.PI, Math.PI / 2);
                    }

                    if (n == 2 && i == 3)
                    {
                        RotateC(c0, -Math.PI / 2, 0);
                    }

                    cube.Scale(62490, 0.06);
                    cube.Color(62490, new Color4(49, 69, 88, 255));

                    curerntRadia = 0;
                    radians = Math.PI / 6;
                    interval = 100;
                    currentTime = 62490;
                    while (currentTime < 63517)
                    {
                        cube.Rotate(currentTime, curerntRadia);
                        currentTime += interval;
                        curerntRadia += radians;
                    }

                    c0.Scale(61873, 0.3);
                    c0.Fade(61873, 1);
                    c0.Fade(62490, 0);

                }
            }

            float initialX = 0;
            xOff = 300;

            for (int n = 1; n <= 3; n++)
            {
                for (int i = 0; i < 3; i++)
                {

                    float y = 100;

                    if (n == 2)
                    {
                        y = 240;
                        initialX = 150;
                    }
                    if (n == 3)
                    {
                        y = 380;
                        initialX = 0;
                    }

                    if (n == 2 && i == 2)
                    {
                        continue;
                    }

                    var c0 = GetLayer("").CreateSprite("sb/c.png", OsbOrigin.Centre, new Vector2(initialX + xOff * i, y));
                    var cube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(initialX + xOff * i, y));

                    if (n == 1 && i == 0)
                    {
                        RotateCSecond(c0, -Math.PI, Math.PI / 2);
                    }
                    if (n == 1 && i == 1)
                    {
                        RotateCSecond(c0, -Math.PI, Math.PI / 2);
                    }
                    if (n == 1 && i == 2)
                    {
                        RotateCSecond(c0, -Math.PI / 2, 0);
                    }

                    if (n == 2 && i == 0)
                    {
                        RotateCSecond(c0, -Math.PI / 2, 0);
                    }

                    if (n == 2 && i == 1)
                    {
                        RotateCSecond(c0, -Math.PI / 2, -Math.PI);
                    }

                    if (n == 3 && i == 0)
                    {
                        RotateCSecond(c0, -Math.PI / 2, -Math.PI);
                    }
                    if (n == 3 && i == 1)
                    {
                        RotateCSecond(c0, 0, Math.PI / 2);
                    }
                    if (n == 3 && i == 2)
                    {
                        RotateCSecond(c0, 0, -Math.PI / 2);
                    }

                    cube.Scale(64134, 0.04);
                    cube.Color(64134, new Color4(49, 69, 88, 255));

                    curerntRadia = 0;
                    radians = Math.PI / 6;
                    interval = 100;
                    currentTime = 64134;
                    while (currentTime < 65161)
                    {
                        cube.Rotate(currentTime, curerntRadia);
                        currentTime += interval;
                        curerntRadia += radians;
                    }

                    c0.Scale(63517, 0.2);
                    c0.Fade(63517, 1);
                    c0.Fade(64134, 0);

                }
            }


        }

        public void BuildUp()
        {
            var cube = GetLayer("").CreateSprite("sb/cube.png");
            cube.ScaleVec(79545, 0.08, 0.08);
            cube.MoveX(OsbEasing.OutCirc, 79956 - 250, 79956 + 100, 800, 550);

            var cube2 = GetLayer("").CreateSprite("sb/cube.png");
            cube2.ScaleVec(79545, 0.08, 0.08);
            cube2.MoveX(OsbEasing.OutCirc, 80367 - 150, 80367, -150, 100);

            var cube3 = GetLayer("").CreateSprite("sb/cube.png");
            cube3.ScaleVec(81599, 0.1f, 0.1f);

            cube.Rotate(79545, 0);
            cube2.Rotate(79545, 0);

            double currentTime = 80778;
            double radians = Math.PI / 6;
            double rotation = 0;

            while (currentTime < 81188)
            {
                cube.Rotate(currentTime, rotation + radians);
                cube2.Rotate(currentTime, rotation + radians);
                currentTime += 100;
                rotation += radians;
            }

            cube.Rotate(currentTime, 81599, rotation, Math.PI * 2);
            cube2.Rotate(currentTime, 81599, rotation, Math.PI * 2);
            cube.ScaleVec(OsbEasing.OutCirc, currentTime, 81599, new Vector2(0.08f, 0.08f), new Vector2(0.08f, 0));
            cube2.ScaleVec(OsbEasing.OutCirc, currentTime, 81599, new Vector2(0.08f, 0.08f), new Vector2(0.08f, 0));
            cube3.MoveY(81599, 150);
            cube3.MoveX(81599, 82113, 790, 650);
            cube3.MoveX(OsbEasing.OutCirc, 82113, 82421, 500, 300);
            cube3.MoveY(82524, 200);
            cube3.MoveX(OsbEasing.OutCirc, 82524, 82832, -100, 125);
            cube3.MoveX(OsbEasing.OutCirc, 82832, 83449, 125, -180);
            cube.Fade(79545, 1);
            cube.Fade(81599, 0);
            cube2.Fade(79545, 1);
            cube2.Fade(81599, 0);
            cube3.Fade(81599, 1);
            cube3.Fade(83243, 0);

            var sphere = GetLayer("").CreateSprite("sb/circle.png");
            sphere.Scale(83038, 0.05);
            sphere.Color(83038, new Color4(255, 255, 255, 255));
            sphere.Color(83654, new Color4(54, 76, 97, 255));
            sphere.Fade(83038, 83243, 0, 1);
            sphere.Fade(84271, 84476, 1, 0);
            sphere.MoveY(83038, 150);
            sphere.MoveX(83038, 84476, 500, 200);
            ApplySineToSprite(sphere, 83038, 84476);

            var cube4 = GetLayer("").CreateSprite("sb/cube.png");
            cube4.Scale(84476, 0.08);
            cube4.MoveY(84476, 150);
            cube4.MoveY(84682, 300);
            cube4.MoveX(84476, 84682, 800, -150);
            cube4.MoveX(84682, 84887, -150, 800);

            var sphere2 = GetLayer("").CreateSprite("sb/circle.png");
            sphere2.ScaleVec(OsbEasing.OutBounce, 84887, 85298, new Vector2(0, 0), new Vector2(0.05f, 0.05f));
            sphere2.Color(84887, new Color4(54, 76, 97, 255));
            sphere2.ScaleVec(OsbEasing.OutCirc, 85298, 85504, new Vector2(0.05f, 0.05f), new Vector2(.5f, .5f));
            sphere2.Fade(84887, 1);
            sphere2.Fade(85504, 0);

            var cube5 = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.CentreRight, new Vector2(272.5f, 68));
            cube5.ScaleVec(85709, new Vector2(0.07f, 0.07f));
            cube5.MoveX(OsbEasing.OutCirc, 85709, 85709 + 50, cube5.PositionAt(85709).X, cube5.PositionAt(85709).X - 50);
            cube5.MoveX(OsbEasing.OutCirc, 85812, 85812 + 50, cube5.PositionAt(85812).X, cube5.PositionAt(85812).X - 50);
            cube5.MoveX(OsbEasing.OutCirc, 85915, 85915 + 50, cube5.PositionAt(85915).X, cube5.PositionAt(85915).X - 50);
            cube5.MoveX(OsbEasing.OutCirc, 86017, 86017 + 50, cube5.PositionAt(86017).X, cube5.PositionAt(86017).X - 50);
            cube5.MoveX(OsbEasing.InSine, 86120, 86531, cube5.PositionAt(86120).X, cube5.PositionAt(86120).X + 200);
            cube5.ScaleVec(OsbEasing.OutCirc, 86428, 86634 - 50, new Vector2(0.07f, 0.07f), new Vector2(0f, 0.07f));
            cube5.MoveY(85709, 86736, 68, 105);
            cube5.Fade(85709, 1);
            cube5.Fade(86736, 0);

            var cube6 = GetLayer("").CreateSprite("sb/cube.png");
            cube6.ScaleVec(86531, new Vector2(0.075f, 0.075f));
            cube6.MoveY(86531, 240);
            cube6.MoveX(OsbEasing.OutCirc, 86531, 86942, -150, 0);
            cube6.MoveY(86942, 280);
            cube6.MoveX(86942, 87147, 550, 500);
            cube6.MoveY(87250, 320);
            cube6.MoveX(87250, 87454, 0, 50);
            cube6.MoveY(87558, 360);
            cube6.MoveX(87558, 87764, 600, 550);
            cube6.MoveY(87867, 400);
            cube6.MoveX(87867, 88175, -50, 0);
            cube6.MoveY(88175, 440);
            cube6.MoveX(88175, 88586, 650, 500);

            cube6.Fade(86531, 1);
            cube6.Fade(88586, 0);

            var cube7 = GetLayer("").CreateSprite("sb/cube.png");
            cube7.Scale(88586, 0.1);
            cube7.Rotate(88586, 89099, 0, Math.PI * 2);
            cube7.Scale(OsbEasing.OutBounce, 89099, 89613, 0.1, 0);
            cube7.Fade(88586, 1);
            cube7.Fade(89613, 0);

            double offset = 50;
            double count = 30;
            double initialY = -400;
            double scale = 0.25;

            double fromCenter = 300;

            double movement = 300;

            double leftX = -fromCenter;
            double rightX = fromCenter;

            List<OsbSprite> vectors = new List<OsbSprite>();

            for (int i = (int)count; i > 0; i--)
            {
                var vec1 = GetLayer("").CreateSprite("sb/vec.png");
                var vec2 = GetLayer("").CreateSprite("sb/vec.png");

                if (i % 2 == 0)
                {
                    vec1.Color(89613, new Color4(211, 84, 104, 255));
                    vec2.Color(89613, new Color4(211, 84, 104, 255));
                }
                else
                {
                    vec1.Color(89613, new Color4(0, 143, 168, 255));
                    vec2.Color(89613, new Color4(0, 143, 168, 255));
                }

                vec1.Scale(89613, scale);
                vec2.Scale(89613, scale);

                vec1.MoveX(OsbEasing.OutCirc, 89202, 89819, -150, 320 + leftX);
                vec2.MoveX(OsbEasing.OutCirc, 89202, 89819, 800, 320 + rightX);

                vec1.MoveY(89819, initialY + offset * i);
                vec2.MoveY(89819, initialY + offset * i);

                vec1.Fade(89613, 1);
                vec2.Fade(89613, 1);

                if (i % 2 == 0)
                {
                    vec1.Scale(91257, 91462, scale, 0);
                    vec2.Scale(91257, 91462, scale, 0);
                }
                else
                {
                    vec1.Scale(91462, 91668, scale, 0);
                    vec2.Scale(91462, 91668, scale, 0);
                }

                vec1.Fade(91668, 0);
                vec2.Fade(91668, 0);

                vectors.Add(vec1);
                vectors.Add(vec2);
            }

            vectors.ForEach((vec) =>
            {
                double initial = vec.PositionAt(89716).Y;
                vec.MoveY(OsbEasing.InOutSine, 89716, 90024, initial, initial - movement);
                vec.MoveY(OsbEasing.InOutSine, 90024, 90435, initial - movement, initial);
                vec.MoveY(OsbEasing.InOutSine, 90435, 90846, initial, initial - movement);
                vec.MoveY(OsbEasing.InOutSine, 90846, 91257, initial - movement, initial);
            });

            var cube0p1 = GetLayer("").CreateSprite("sb/white.png");
            var cube0p2 = GetLayer("").CreateSprite("sb/white.png");
            var cube0p3 = GetLayer("").CreateSprite("sb/white.png");
            var cube0p4 = GetLayer("").CreateSprite("sb/white.png");

            var lastCube = GetLayer("").CreateSprite("sb/cube.png");

            cube0p1.ScaleVec(91462, 100, 25);
            cube0p2.ScaleVec(91462, 100, 25);
            cube0p3.ScaleVec(91462, 100, 25);
            cube0p4.ScaleVec(91462, 100, 25);

            cube0p1.MoveY(91462, 240 - 75 / 2);
            cube0p2.MoveY(91462, 240 - 25 / 2);
            cube0p3.MoveY(91462, 240 + 25 / 2);
            cube0p4.MoveY(91462, 240 + 75 / 2);


            cube0p1.MoveX(91462, 92284, 320 - 600, 320 - 400);
            cube0p2.MoveX(91462, 92284, 320 - 600, 320 - 400);
            cube0p3.MoveX(91462, 92284, 320 + 600, 320 + 400);
            cube0p4.MoveX(91462, 92284, 320 + 600, 320 + 400);

            cube0p1.MoveX(OsbEasing.OutCirc, 92284, 92284 + 100, 320 - 400, 320);
            cube0p2.MoveX(OsbEasing.OutCirc, 92387, 92387 + 100, 320 - 400, 320);
            cube0p3.MoveX(OsbEasing.OutCirc, 92490, 92490 + 100, 320 + 400, 320);
            cube0p4.MoveX(OsbEasing.OutCirc, 92593, 92593 + 100, 320 + 400, 320);

            lastCube.Scale(92695, 0.1);
            lastCube.MoveY(OsbEasing.OutSine, 92695, 92901, 240, 210);
            lastCube.MoveY(OsbEasing.InSine, 92901, 93106, 210, 350);
            lastCube.Rotate(OsbEasing.OutSine, 92695, 92901, 0, 0.35);
            lastCube.Rotate(OsbEasing.InSine, 92901, 93106, 0.35, 1.5);

            lastCube.Fade(92695, 1);
            lastCube.Fade(93106 - 150, 93106, 1, 0);

            cube0p1.Fade(91462, 1);
            cube0p2.Fade(91462, 1);
            cube0p3.Fade(91462, 1);
            cube0p4.Fade(91462, 1);

            cube0p1.Fade(92695, 0);
            cube0p2.Fade(92695, 0);
            cube0p3.Fade(92695, 0);
            cube0p4.Fade(92695, 0);


        }

        public void BuildUpLast()
        {

            var cube3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube1 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);
            var cube = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre);

            cube.ScaleVec(OsbEasing.OutBounce, 93106, 93517, new Vector2(0, 0), new Vector2(.05f, .05f));
            cube1.ScaleVec(OsbEasing.OutBounce, 93106, 93517, new Vector2(0, 0), new Vector2(.05f, .05f));
            cube2.ScaleVec(OsbEasing.OutBounce, 93106, 93517, new Vector2(0, 0), new Vector2(.05f, .05f));
            cube3.ScaleVec(OsbEasing.OutBounce, 93106, 93517, new Vector2(0, 0), new Vector2(.05f, .05f));

            cube.Color(93106, new Color4(46, 65, 82, 255));
            cube1.Color(93106, new Color4(46, 65, 82, 255));
            cube2.Color(93106, new Color4(46, 65, 82, 255));
            cube3.Color(93106, new Color4(46, 65, 82, 255));

            cube.MoveX(OsbEasing.OutCirc, 93723, 93723 + 200, 320, 0);
            cube1.MoveX(OsbEasing.OutCirc, 93620, 93620 + 200, 320, 650);
            cube2.MoveX(OsbEasing.OutCirc, 93723, 93723 + 200, 320, 0);
            cube3.MoveX(OsbEasing.OutCirc, 93620, 93620 + 200, 320, 650);

            cube.MoveY(OsbEasing.OutCirc, 93723, 93723 + 200, 240, 100);
            cube1.MoveY(OsbEasing.OutCirc, 93620, 93620 + 200, 240, 100);
            cube2.MoveY(OsbEasing.OutCirc, 93723, 93723 + 200, 240, 350);
            cube3.MoveY(OsbEasing.OutCirc, 93620, 93620 + 200, 240, 350);

            FlipDot(cube, 94339);
            FlipDot(cube1, 94442);
            FlipDot(cube2, 94545);
            FlipDot(cube3, 94647);

            cube.MoveY(OsbEasing.InOutSine, 95161, 95367, 100, 430);
            cube1.MoveY(OsbEasing.InOutSine, 95161, 95367, 100, 430);
            cube2.MoveY(OsbEasing.InOutSine, 95161, 95367, 350, 50);
            cube3.MoveY(OsbEasing.InOutSine, 95161, 95367, 350, 50);

            cube.MoveY(OsbEasing.InOutSine, 95367, 95572, 430, -20);
            cube1.MoveY(OsbEasing.InOutSine, 95367, 95572, 430, -20);
            cube2.MoveY(OsbEasing.InOutSine, 95367, 95572, 50, 500);
            cube3.MoveY(OsbEasing.InOutSine, 95367, 95572, 50, 500);

            var newCube = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre);

            double radians = Math.PI / 4;
            newCube.ScaleVec(95675, 0.1, 0.1);
            newCube.Rotate(95675, 0);
            newCube.Rotate(OsbEasing.OutCirc, 95675, 95778, 0, radians);
            newCube.Rotate(OsbEasing.OutCirc, 95778, 95880, radians, radians * 2);
            newCube.Rotate(OsbEasing.OutCirc, 95880, 95983, radians * 2, radians * 3);

            newCube.Rotate(OsbEasing.OutCirc, 95983, 96599, radians * 3, -radians * 5);
            newCube.MoveY(OsbEasing.OutSine, 95983, 96188, 240, 150);
            newCube.MoveY(OsbEasing.InSine, 96188, 96394, 150, 300);

            newCube.Fade(95778, 1);
            newCube.Fade(96394 - 100, 96394, 1, 0);

            cube.Fade(93106, 1);
            cube.Fade(95572, 0);
            cube1.Fade(93106, 1);
            cube1.Fade(95572, 0);
            cube2.Fade(93106, 1);
            cube2.Fade(95572, 0);
            cube3.Fade(93106, 1);
            cube3.Fade(95572, 0);

            var square = GetLayer("").CreateSprite("sb/cube.png", OsbOrigin.Centre, new Vector2(0, 500));
            square.Color(96405, new Color4(255, 225, 255, 255));
            square.ScaleVec(96405, new Vector2(0.1f, 0.1f));
            square.MoveY(OsbEasing.OutCirc, 96405, 96805, 520, 100);
            square.MoveY(OsbEasing.InCirc, 96805, 97216, 100, 520);

            double x = square.PositionAt(96805).X;
            double currentTime = 96805;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;
            square.MoveX(currentTime, currentTime + 25, x, x + Random(-25, 25));
            currentTime += 25;

            square.MoveX(97216, 650);
            square.MoveY(OsbEasing.OutCirc, 97216, 97627, -50, 300);
            square.Color(97627, new Color4(255, 225, 52, 255));
            square.Rotate(OsbEasing.InSine, 97627, 98038, 0, -Math.PI / 2);
            square.MoveY(OsbEasing.InCirc, 97627, 98038, 300, -50);


            square.Fade(96405, 1);
            square.Fade(98038, 0);

            var circle = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 50));
            var circle2 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(25, 430));
            var circle3 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 50));
            var circle4 = GetLayer("").CreateSprite("sb/circle.png", OsbOrigin.Centre, new Vector2(650, 430));

            circle.ScaleVec(98449, 0.03, 0.03);
            circle2.ScaleVec(98449, 0.03, 0.03);
            circle3.ScaleVec(98449, 0.03, 0.03);
            circle4.ScaleVec(98449, 0.03, 0.03);

            circle.Color(98449, new Color4(57, 80, 101, 255));
            circle2.Color(98449, new Color4(57, 80, 101, 255));
            circle3.Color(98449, new Color4(57, 80, 101, 255));
            circle4.Color(98449, new Color4(57, 80, 101, 255));

            circle.MoveY(OsbEasing.InOutSine, 98449, 98860, -10, 430);
            circle3.MoveY(OsbEasing.InOutSine, 98449, 98860, -10, 430);
            circle2.MoveY(OsbEasing.InOutSine, 98449, 98860, 480, 50);
            circle4.MoveY(OsbEasing.InOutSine, 98449, 98860, 480, 50);

            circle.MoveY(OsbEasing.InOutSine, 98860, 99271, 430, 50);
            circle3.MoveY(OsbEasing.InOutSine, 98860, 99271, 430, 50);
            circle2.MoveY(OsbEasing.InOutSine, 98860, 99271, 50, 430);
            circle4.MoveY(OsbEasing.InOutSine, 98860, 99271, 50, 430);

            circle.MoveY(OsbEasing.InOutSine, 99271, 99682, 50, 240);
            circle3.MoveY(OsbEasing.InOutSine, 99271, 99682, 50, 240);
            circle2.MoveY(OsbEasing.InOutSine, 99271, 99682, 430, 240);
            circle4.MoveY(OsbEasing.InOutSine, 99271, 99682, 430, 240);

            circle.MoveX(OsbEasing.InOutSine, 99065, 99682, 25, 320);
            circle3.MoveX(OsbEasing.InOutSine, 99065, 99682, 650, 320);
            circle2.MoveX(OsbEasing.InOutSine, 99065, 99682, 25, 320);
            circle4.MoveX(OsbEasing.InOutSine, 99065, 99682, 650, 320);

            circle.ScaleVec(OsbEasing.InOutSine, 99271, 99682, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle3.ScaleVec(OsbEasing.InOutSine, 99271, 99682, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle2.ScaleVec(OsbEasing.InOutSine, 99271, 99682, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));
            circle4.ScaleVec(OsbEasing.InOutSine, 99271, 99682, new Vector2(0.03f, 0.03f), new Vector2(0.075f, 0.075f));

            circle.ScaleVec(OsbEasing.None, 99682, 99682 + 200, new Vector2(0.075f, 0.075f), new Vector2(1, 1));

            BuildUpSecond(99682);

        }

        public void LastDrop()
        {

            var cube = GetLayer("").CreateSprite("sb/circle.png");
            cube.ScaleVec(106668, 0.04, 0.04);
            cube.Fade(106668, 1);
            cube.Fade(113243, 0);

            cube.StartLoopGroup(106668, 7);
            cube.ScaleVec(OsbEasing.OutCirc, 0, 200, new Vector2(0.04f, 0.04f), new Vector2(0.06f, 0.04f));
            cube.ScaleVec(OsbEasing.InCirc, 200, 400, new Vector2(0.06f, 0.04f), new Vector2(0.04f, 0.04f));
            cube.EndGroup();

            List<OsbSprite> left = CreateAndMoveCircle(106668, 7, 41325 - 40915, -140);
            List<OsbSprite> right = CreateAndMoveCircle(106668, 7, 41325 - 40915, 140);

            cube.MoveY(OsbEasing.InSine, 109545, 109750, 240, 500);
            cube.MoveY(OsbEasing.OutSine, 109750, 109956, -50, 200);

            left.ForEach((sprite) =>
            {
                sprite.MoveY(OsbEasing.InSine, 109545, 109750, 240, 500);
                sprite.MoveY(OsbEasing.OutSine, 109750, 109956, -50, 200);
            });

            right.ForEach((sprite) =>
            {
                sprite.MoveY(OsbEasing.InSine, 109545, 109750, 240, 500);
                sprite.MoveY(OsbEasing.OutSine, 109750, 109956, -50, 200);
            });

            double movement = -50;

            double currentTime = 109956;
            for (int i = 0; i < 7; i++)
            {
                double snapDuration = 44613 - 44202;

                MoveCubeHorizontal(cube, currentTime, 200 / 4);

                double cubeY = cube.PositionAt(currentTime).Y;
                cube.MoveY(OsbEasing.OutCirc, currentTime, currentTime + 50, cubeY, cubeY - movement);
                cube.MoveY(OsbEasing.OutSine, currentTime + 50, currentTime + snapDuration - 50, cubeY - movement, cubeY);


                int n = 0;
                left.ForEach((sprite) =>
                {

                    double currentY = sprite.PositionAt(currentTime).Y;

                    if (currentTime < 112832)
                    {
                        if (n % 2 == 0)
                        {
                            sprite.MoveY(OsbEasing.OutCirc, currentTime, currentTime + 50, currentY, currentY + movement);
                            sprite.MoveY(OsbEasing.OutSine, currentTime + 50, currentTime + snapDuration - 50, currentY + movement, currentY);
                        }
                        else
                        {
                            sprite.MoveY(OsbEasing.OutCirc, currentTime, currentTime + 50, currentY, currentY - movement);
                            sprite.MoveY(OsbEasing.OutSine, currentTime + 50, currentTime + snapDuration - 50, currentY - movement, currentY);
                        }
                    }

                    MoveCubeHorizontal(sprite, currentTime, 200 / 4);
                    n++;
                });

                n = 0;
                right.ForEach((sprite) =>
                {
                    double currentY = sprite.PositionAt(currentTime).Y;

                    if (currentTime < 112832)
                    {
                        if (n % 2 == 0)
                        {
                            sprite.MoveY(OsbEasing.OutCirc, currentTime, currentTime + 50, currentY, currentY + movement);
                            sprite.MoveY(OsbEasing.OutSine, currentTime + 50, currentTime + snapDuration - 50, currentY + movement, currentY);
                        }
                        else
                        {
                            sprite.MoveY(OsbEasing.OutCirc, currentTime, currentTime + 50, currentY, currentY - movement);
                            sprite.MoveY(OsbEasing.OutSine, currentTime + 50, currentTime + snapDuration - 50, currentY - movement, currentY);
                        }
                    }

                    MoveCubeHorizontal(sprite, currentTime, 200 / 4);
                    n++;
                });

                movement *= -1;
                currentTime += snapDuration;
            }

            cube.MoveX(OsbEasing.OutSine, 112832, 113243, cube.PositionAt(109956).X, 320);
            cube.MoveY(OsbEasing.OutSine, 112832, 113243, cube.PositionAt(109956).Y, 240);

            double interval = (113243 - 112832) / 4;
            currentTime = 112832;

            cube.ScaleVec(OsbEasing.OutSine, currentTime, currentTime + interval, cube.ScaleAt(109956), new Vector2(0.00f, 0.03f));
            cube.ScaleVec(OsbEasing.OutSine, currentTime + interval, currentTime + interval + interval, new Vector2(0.00f, 0.03f), new Vector2(0.03f, 0.03f));
            cube.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval, currentTime + interval + interval + interval, new Vector2(0.03f, 0.03f), new Vector2(0.00f, 0.02f));
            cube.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval + interval, currentTime + interval + interval + interval + interval, new Vector2(0.00f, 0.02f), new Vector2(0.01f, 0.02f));

            right.ForEach((sprite) =>
             {
                 sprite.MoveX(OsbEasing.OutSine, 112832, 113243, sprite.PositionAt(109956).X, 320);
                 sprite.MoveY(OsbEasing.OutSine, 112832, 113243, sprite.PositionAt(109956).Y, 240);
                 sprite.ScaleVec(OsbEasing.OutSine, currentTime, currentTime + interval, sprite.ScaleAt(109956), new Vector2(0.00f, 0.03f));
                 sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval, currentTime + interval + interval, new Vector2(0.00f, 0.03f), new Vector2(0.03f, 0.03f));
                 sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval, currentTime + interval + interval + interval, new Vector2(0.03f, 0.03f), new Vector2(0.00f, 0.02f));
                 sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval + interval, currentTime + interval + interval + interval + interval, new Vector2(0.00f, 0.02f), new Vector2(0.01f, 0.02f));
             });

            left.ForEach((sprite) =>
            {
                sprite.MoveX(OsbEasing.OutSine, 112832, 113243, sprite.PositionAt(109956).X, 320);
                sprite.MoveY(OsbEasing.OutSine, 112832, 113243, sprite.PositionAt(109956).Y, 240);
                sprite.ScaleVec(OsbEasing.OutSine, currentTime, currentTime + interval, sprite.ScaleAt(109956), new Vector2(0.00f, 0.03f));
                sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval, currentTime + interval + interval, new Vector2(0.00f, 0.03f), new Vector2(0.03f, 0.03f));
                sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval, currentTime + interval + interval + interval, new Vector2(0.03f, 0.03f), new Vector2(0.00f, 0.02f));
                sprite.ScaleVec(OsbEasing.OutSine, currentTime + interval + interval + interval, currentTime + interval + interval + interval + interval, new Vector2(0.00f, 0.02f), new Vector2(0.01f, 0.02f));
            });

            OsbAnimation animation = GetLayer("").CreateAnimation("sb/ani/button/frame.jpg", 180, 33, OsbLoopType.LoopOnce, OsbOrigin.Centre);
            animation.Fade(113243, 1);
            animation.Fade(119202, 0);
            animation.Scale(113240, 854f / 1200f);
        }

        public void RotateC(OsbSprite sprite, double start, double end)
        {

            double rotStart = 61873;
            double rotEnd = 62695;

            sprite.Rotate(OsbEasing.OutElasticHalf, rotStart, rotEnd, start, end);
        }

        public void RotateCSecond(OsbSprite sprite, double start, double end)
        {

            double rotStart = 63517;
            double rotEnd = 64134;

            sprite.Rotate(OsbEasing.OutElasticHalf, rotStart, rotEnd, start, end);
        }


        public void FlipDot(OsbSprite sprite, double start)
        {

            sprite.ScaleVec(OsbEasing.InCirc, start, start + 150, sprite.ScaleAt(start), new Vector2(0.0f, 0.035f));
            sprite.Color(start + 150, new Color4(255, 255, 255, 255));
            sprite.ScaleVec(OsbEasing.OutCirc, start + 150, start + 300, new Vector2(0.0f, 0.035f), new Vector2(-0.025f, 0.025f));

        }

        public void FlipSquare(OsbSprite sprite, double start)
        {

            sprite.ScaleVec(OsbEasing.InCirc, start, start + 150, sprite.ScaleAt(start), new Vector2(0.0f, 0.2f));
            sprite.Color(start + 150, new Color4(228, 190, 48, 255));
            sprite.ScaleVec(OsbEasing.OutCirc, start + 150, start + 300, new Vector2(0.0f, 0.2f), new Vector2(-0.075f, 0.075f));

        }

        public void ApplySineToSprite(OsbSprite sprite, double starttime, double endtime)
        {

            int count = 1;
            double stepDuration = 20;
            double frequencyX = 0.1;
            double frequencyY = 0.2;
            double phase = 0;

            while (starttime < endtime - stepDuration)
            {
                OsbEasing easing = OsbEasing.None;

                // Using sine for y-axis with a phase difference to start at the top point
                float y = (float)Utility.CosWaveValue(2, frequencyY, phase);

                double currentY = sprite.PositionAt(starttime).Y;

                sprite.MoveY(starttime, starttime + stepDuration, currentY, currentY + y);

                phase += frequencyX;
                starttime += stepDuration;
                count++;
            }
        }
    }
}
