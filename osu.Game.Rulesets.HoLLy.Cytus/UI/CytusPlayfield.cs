using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables;
using osu.Game.Rulesets.HoLLy.Cytus.UI.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI
{
    internal class CytusPlayfield : Playfield
    {
        public CytusPlayfield()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.BottomCentre;   // I don't know :(

            Size = new Vector2(0.75f);

            InternalChild = new Container {
                RelativeSizeAxes = Axes.Both,
                Children = new Drawable[] {
                    new CytusScanLine(Constants.BeatsPerScan) {
                        Depth = -50
                    },
                    HitObjectContainer
                }
            };
        }


        public override void Add(DrawableHitObject h)
        {
            if (!(h is CytusDrawableHitObject note))
                throw new Exception("Unexpected hitobject type " + h.GetType().Name);

            base.Add(note);
        }
    }
}
