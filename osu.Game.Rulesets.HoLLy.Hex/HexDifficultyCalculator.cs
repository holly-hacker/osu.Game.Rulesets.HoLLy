using osu.Game.Beatmaps;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexDifficultyCalculator : DifficultyCalculator
    {
        public HexDifficultyCalculator(Ruleset ruleset, WorkingBeatmap beatmap) : base(ruleset, beatmap) { }
        protected override DifficultyAttributes Calculate(IBeatmap beatmap, Mod[] mods, double timeRate) => new DifficultyAttributes(mods, 5.0);
    }
}
