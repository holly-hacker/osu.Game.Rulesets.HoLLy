using System.Collections.Generic;
using System.Linq;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModHidden : ModHidden, IApplicableToDrawableHitObjects
    {
        public override double ScoreMultiplier => 1.06;
        public override bool HasImplementation => false;

        public void ApplyToDrawableHitObjects(IEnumerable<DrawableHitObject> drawables)
        {
            drawables.Where(x => x is HexNote).Cast<HexNote>().ForEach(x => x.ApplyCustomUpdateState += (o, state) => {
                const float hiddenTime = 2000f;

                var ho = o.HitObject;
                double start = ho.StartTime - hiddenTime;

                using (o.BeginAbsoluteSequence(start, true))
                    o.FadeOut(hiddenTime);
            });
        }
    }
}
