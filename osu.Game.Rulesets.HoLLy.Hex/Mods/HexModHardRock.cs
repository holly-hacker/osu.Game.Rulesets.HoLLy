using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModHardRock : ModHardRock
    {
        /*
         * Changes:
         * - general hard making stuff (AR, OD, HP)
         */

        public override double ScoreMultiplier => 1.09;
        public override bool HasImplementation => false;
    }
}
