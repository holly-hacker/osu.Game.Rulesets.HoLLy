using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModRelax : Mod
    {
        /*
         * Changes:
         * - Hovering on any place on the screen will trigger a lane.
         */

        public override string Name => "Relax";
        public override string ShortenedName => "RX";
        public override string Description => "You no longer have aim as much!";
        public override double ScoreMultiplier => 0.0;
        public override ModType Type => ModType.Special;
        public override bool Ranked => false;
        public override bool HasImplementation => false;
    }
}
