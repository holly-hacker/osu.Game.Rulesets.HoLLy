using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModFadeIn : Mod
    {
        public override string Name => "Fade In";
        public override string ShortenedName => "FI";
        public override string Description => "Keys fade in over time";
        public override double ScoreMultiplier => 1;
        public override ModType Type => ModType.DifficultyIncrease;
        public override bool Ranked => true;
        public override bool HasImplementation => false;
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_hidden;
    }
}
