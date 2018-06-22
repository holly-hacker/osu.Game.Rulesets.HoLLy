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
        private static readonly Vector2 BASE_SIZE = new Vector2(512, 384);
        private IBeatmap _beatmap;
        private const int BeatsPerScan = 4;

        public CytusPlayfield(IBeatmap bm) : base(BASE_SIZE.X)
        {
            _beatmap = bm;

            Anchor = Anchor.Centre;         // Center... I think?
            Origin = Anchor.BottomCentre;   // Black magic fuckery

            Content.AddRange(new[] {
                new CytusScanLine(BeatsPerScan)
            });
        }

        public override void Add(DrawableHitObject h)
        {
            if (!(h is CytusDrawableNote note))
                throw new Exception("Unexpected hitobject type " + h.GetType().Name);

            note.X = note.HitObject.X - BASE_SIZE.X / 2;    // Because of the black magic in Origin/Anchor
            note.Y = _beatmap.GetScanPosition(note.HitObject.StartTime, BeatsPerScan);
            
            note.RelativePositionAxes = Axes.Y;
            note.RelativeSizeAxes = Axes.None;
            
            base.Add(note);
        }
    }
}
