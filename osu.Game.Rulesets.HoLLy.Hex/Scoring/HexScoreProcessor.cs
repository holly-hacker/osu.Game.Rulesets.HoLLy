using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.HoLLy.Hex.Scoring
{
    internal class HexScoreProcessor : ScoreProcessor<HexHitObject>
    {
        public HexScoreProcessor() : base() { }
        public HexScoreProcessor(HexRulesetContainer rulesetContainer) : base(rulesetContainer) { }
    }
}
