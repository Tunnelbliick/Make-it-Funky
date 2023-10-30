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
    public class BackgroundCover : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            var black = GetLayer("").CreateSprite("sb/black.png", OsbOrigin.Centre);
            black.ScaleVec(-2500, new Vector2(854, 480));
            black.Fade(-2500, 1);
            black.Fade(66800, 0);
            black.Fade(81188, 1);
            black.Fade(121873, 0);

        }
    }
}
