using osu.Framework.Graphics;
using osu.Framework.Logging;
using osu.Game.Rulesets.HoLLy.Cytus.UI.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI
{
    internal class CytusPlayfield : Playfield
    {
        public CytusPlayfield(float? customWidth = null, float? customHeight = null) : base(customWidth, customHeight)
        {
            Anchor = Anchor.Centre;         // Center... I think?
            Origin = Anchor.BottomCentre;   // Black magic fuckery
            
            Content.AddRange(new[] {
                new CytusScanLine(4)
            });
        }

        protected override void Update()
        {
            base.Update();
        }

        public override void Add(DrawableHitObject h)
        {
            base.Add(h);
        }
    }
}
