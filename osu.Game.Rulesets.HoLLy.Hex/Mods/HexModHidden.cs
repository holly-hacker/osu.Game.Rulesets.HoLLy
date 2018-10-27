using osu.Framework.Graphics;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModHidden : ModHidden
    {
        public override double ScoreMultiplier => 1.06;
        public override bool HasImplementation => false;

        protected override void ApplyHiddenState(DrawableHitObject o, ArmedState state)
        {
            const float hiddenTime = 2000f;

            var ho = o.HitObject;
            double start = ho.StartTime - hiddenTime;

            using (o.BeginAbsoluteSequence(start, true))
                o.FadeOut(hiddenTime);
        }
    }
}
