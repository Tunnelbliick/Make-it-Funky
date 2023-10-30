using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenTK;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;

namespace StorybrewScripts
{

    public class NoteOriginBack
    {

        public string receptorSpritePath = "";
        public Vector2 position = new Vector2(0, 0);
        public StoryboardLayer layer;
        public OsbSprite originSprite;

        public double bpmOffset;
        public double bpm;

        public OsbSprite debug;

        // Rotation in radiants
        public double rotation = 0f;

        public NoteOriginBack(String receptorSpritePath, double rotation, StoryboardLayer layer, CommandScale scale, double starttime)
        {

            OsbSprite receptor = layer.CreateSprite("sb/transparent.png", OsbOrigin.Centre);
            receptor.Rotate(starttime, rotation);
            receptor.ScaleVec(starttime, scale);


            this.receptorSpritePath = receptorSpritePath;
            this.rotation = rotation;
            this.layer = layer;
            this.originSprite = receptor;

        }

        public void Render(double starttime, double endTime)
        {
            OsbSprite receptor = this.originSprite;

            receptor.Fade(starttime, 1);
            receptor.Fade(endTime, 0);

        }

        public void MoveOrigin(double starttime, Vector2 newPosition, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            Vector2 lastPosition = getCurrentPosition(starttime);

            if (duration == 0)
            {
                if (lastPosition.X != newPosition.X)
                    receptor.MoveX(starttime, newPosition.X);
                if (lastPosition.Y != newPosition.Y)
                    receptor.MoveY(starttime, newPosition.Y);
            }
            else
            {
                if (lastPosition.X != newPosition.X)
                    receptor.MoveX(ease, starttime, starttime + duration, lastPosition.X, newPosition.X);
                if (lastPosition.Y != newPosition.Y)
                    receptor.MoveY(ease, starttime, starttime + duration, lastPosition.Y, newPosition.Y);
            }

            this.position = newPosition;

        }

        public void MoveOriginRelative(double starttime, Vector2 offset, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            Vector2 lastPosition = getCurrentPosition(starttime);
            Vector2 newPosition = Vector2.Add(lastPosition, offset);

            if (duration == 0)
            {
                if (lastPosition.X != newPosition.X)
                    receptor.MoveX(starttime, newPosition.X);
                if (lastPosition.Y != newPosition.Y)
                    receptor.MoveY(starttime, newPosition.Y);
            }
            else
            {
                if (lastPosition.X != newPosition.X)
                    receptor.MoveX(ease, starttime, starttime + duration, lastPosition.X, newPosition.X);
                if (lastPosition.Y != newPosition.Y)
                    receptor.MoveY(ease, starttime, starttime + duration, lastPosition.Y, newPosition.Y);
            }

            this.position = newPosition;

        }

        public void MoveOriginRelativeX(double starttime, double value, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            Vector2 originalPosition = new Vector2(0, 0);//getCurrentPosition(starttime);

            if (duration == 0)
            {
                receptor.MoveX(starttime, originalPosition.X + value);
            }
            else
            {
                receptor.MoveX(ease, starttime, starttime + duration, originalPosition.X, originalPosition.X + value);
            }

        }

        public void MoveOriginRelativeY(double starttime, double value, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            Vector2 originalPosition = getCurrentPosition(starttime);

            if (duration == 0)
            {
                receptor.MoveY(starttime, originalPosition.Y + value);
            }
            else
            {
                receptor.MoveY(ease, starttime, starttime + duration, originalPosition.Y, originalPosition.Y + value);
            }

        }

        public void ScaleReceptor(double starttime, Vector2 newPosition, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            if (duration == 0)
            {
                receptor.ScaleVec(starttime, newPosition);
            }
            else
            {
                receptor.ScaleVec(ease, starttime, starttime + duration, getCurrentScale(starttime), newPosition);
            }

        }

        public void RotateReceptor(double starttime, double rotation, OsbEasing ease, double duration)
        {
            OsbSprite receptor = this.originSprite;

            var newRotation = this.rotation + rotation;

            if (duration == 0)
            {
                receptor.Rotate(starttime, newRotation);
            }
            else
            {
                receptor.Rotate(ease, starttime, starttime + duration, getCurrentRotaion(starttime), newRotation);
            }

            this.rotation = newRotation;

        }

        public string PivotReceptor(double starttime, double rotation, OsbEasing ease, double duration, int stepcount, Vector2 center)
        {

            String dbg = "";

            //RotateReceptor(starttime, rotation, ease, duration);

            stepcount = Math.Max(stepcount, 1);

            Vector2 point = originSprite.PositionAt(starttime);

            double stepTime = Math.Max(duration / stepcount, 0);

            double endRadians = rotation; // Set the desired end radians here, 2*PI radians is a full circle
            double rotationPerIteration = endRadians / Math.Max(stepcount, 1); // Rotation per iteration

            for (int i = 1; i <= stepcount; i++)
            {
                var currentTime = starttime + stepTime * i;

                Vector2 rotatedPoint = PivotPoint(point, center, rotationPerIteration * i);
                MoveOrigin(currentTime, rotatedPoint, ease, stepTime);
            }

            return dbg;
        }

        public void PivotAndRescaleReceptor(double starttime, double rotation, OsbEasing ease, double duration, int stepcount, Vector2 center, double targetDistance)
        {
            Vector2 initialPoint = originSprite.PositionAt(starttime);

            double stepTime = duration / stepcount;
            double rotationPerIteration = rotation / (stepcount - 1);

            // Calculate initial distance
            double initialDistance = (initialPoint - center).Length;

            for (int i = 0; i < stepcount; i++)
            {
                var currentTime = starttime + stepTime * i;

                // Rotate the point
                Vector2 rotatedPoint = Utility.PivotPoint(initialPoint, center, rotationPerIteration * i);

                // Get the direction in which we're moving (based on rotation around the center).
                Vector2 directionFromCenter = rotatedPoint - center;
                directionFromCenter.Normalize(); // Normalize to get a unit vector

                // Interpolate between initialDistance and targetDistance based on the progress
                double desiredDistance = initialDistance + (targetDistance - initialDistance) * ((double)i / stepcount);

                // Compute the new position based on the desired distance
                Vector2 newPoint = center + directionFromCenter * (float)desiredDistance;

                MoveOrigin(currentTime, newPoint, ease, stepTime);
            }
        }


        public static Vector2 PivotPoint(Vector2 point, Vector2 center, double radians)
        {
            // Translate point back to origin
            point -= center;

            // Rotate point
            Vector2 rotatedPoint = new Vector2(
                point.X * (float)Math.Cos(radians) - point.Y * (float)Math.Sin(radians),
                point.X * (float)Math.Sin(radians) + point.Y * (float)Math.Cos(radians)
            );

            // Translate point back
            return rotatedPoint + center;
        }

        public Vector2 getCurrentScale(double currentTime)
        {
            CommandScale scale = this.originSprite.ScaleAt(currentTime);
            return new Vector2(scale.X, scale.Y);
        }

        public Vector2 getCurrentPosition(double currentTime)
        {
            CommandPosition position = this.originSprite.PositionAt(currentTime);
            return new Vector2(position.X, position.Y);
        }

        public float getCurrentRotaion(double currentTIme)
        {
            return this.originSprite.RotationAt(currentTIme);
        }


    }
}