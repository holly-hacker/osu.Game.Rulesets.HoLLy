using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexDifficultyCalculator : DifficultyCalculator
    {
        public HexDifficultyCalculator(IBeatmap beatmap, Mod[] mods = null) : base(beatmap, mods) { }
        public override double Calculate(Dictionary<string, double> categoryDifficulty = null) => 5.0;
    }
}
