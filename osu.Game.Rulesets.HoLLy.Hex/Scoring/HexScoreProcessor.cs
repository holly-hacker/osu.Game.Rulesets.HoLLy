using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Scoring;

namespace osu.Game.Rulesets.HoLLy.Hex.Scoring
{
    internal class HexScoreProcessor : ScoreProcessor<HexHitObject>
    {
        private float hpDrainRate;

        public HexScoreProcessor() : base() { }
        public HexScoreProcessor(HexRulesetContainer rulesetContainer) : base(rulesetContainer) { }

        protected override void SimulateAutoplay(Beatmap<HexHitObject> beatmap)
        {
            hpDrainRate = beatmap.BeatmapInfo.BaseDifficulty.DrainRate;

            foreach (HexHitObject _ in beatmap.HitObjects)
                AddJudgement(new Judgement {Result = HitResult.Perfect});
        }

        protected override void OnNewJudgement(Judgement judgement)
        {
            base.OnNewJudgement(judgement);
            
            switch (judgement.Result)
            {
                case HitResult.Perfect:
                    Health.Value += 1.0 / ((hpDrainRate + 2) * 2);
                    break;

                case HitResult.Miss:
                    Health.Value -= 1.0 / (15f - hpDrainRate);
                    break;
            }
        }
    }
}
