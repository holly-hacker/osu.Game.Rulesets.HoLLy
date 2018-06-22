using System;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables;
using osu.Game.Rulesets.HoLLy.Cytus.UI.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI
{
    internal class CytusPlayfield : Playfield
    {
        public static readonly Vector2 BASE_SIZE = new Vector2(512, 384);
        private IBeatmap _beatmap;

        public CytusPlayfield(IBeatmap bm) : base(BASE_SIZE.X)
        {
            _beatmap = bm;

            Anchor = Anchor.Centre;         // Center... I think?
            Origin = Anchor.BottomCentre;   // Black magic fuckery

            Content.AddRange(new[] {
                new CytusScanLine(Constants.BeatsPerScan)
            });
        }

        public override void Add(DrawableHitObject h)
        {
            if (!(h is CytusDrawableHitObject note))
                throw new Exception("Unexpected hitobject type " + h.GetType().Name);
            
            // everything is set in CytusDrawableHitObject..ctor

            base.Add(note);
        }
    }
}
