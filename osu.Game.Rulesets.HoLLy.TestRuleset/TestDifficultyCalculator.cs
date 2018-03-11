using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.HoLLy.Test
{
    internal class TestDifficultyCalculator : DifficultyCalculator
    {
        public override double Calculate(Dictionary<string, double> categoryDifficulty = null) => Math.PI;
    }
}
