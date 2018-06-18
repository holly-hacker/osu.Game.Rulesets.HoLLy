using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModMaiMai : Mod
    {
        /*
         * If I ever implement mapping, this should be a togglable for maps
         *
         * Changes:
         * - invert direction of note lanes
         * - change notes to circles
         * - optionally have notes that require multiple keys to be clicked
         * - oh yeah actually click instead of hover (optional? only for natives?)
         */

        public override string Name => "MaiMai";
        public override string ShortenedName => "MM";
        public override string Description => "Play a superior rhythm game";
        public override double ScoreMultiplier => 0;
        public override ModType Type => ModType.Special;
        public override bool Ranked => true;
        public override bool HasImplementation => false;
        public override FontAwesome Icon => FontAwesome.fa_connectdevelop;
    }
}
