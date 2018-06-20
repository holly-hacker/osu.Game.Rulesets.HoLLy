using System;
using osu.Framework.Graphics;
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

        public CytusPlayfield() : base(BASE_SIZE.X, BASE_SIZE.Y)
        {
            Anchor = Anchor.Centre;         // Center... I think?
            Origin = Anchor.BottomCentre;   // Black magic fuckery

            Content.AddRange(new[] {
                new CytusScanLine(4)
            });
        }

        public override void Add(DrawableHitObject h)
        {
            if (!(h is CytusNote note))
                throw new Exception("Unexpected hitobject type " + h.GetType().Name);

            note.X = note.HitObject.X - BASE_SIZE.X / 2;    // Because of the black magic in Origin/Anchor
            note.Y = 0.5f;  // TODO
            
            note.RelativePositionAxes = Axes.Y;
            note.RelativeSizeAxes = Axes.None;
            
            base.Add(note);
        }
    }
}
