using System.Collections.Generic;
using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexDifficultyCalculator : DifficultyCalculator
    {
        public override double Calculate(Dictionary<string, double> categoryDifficulty = null) => 5.0;
    }
}
