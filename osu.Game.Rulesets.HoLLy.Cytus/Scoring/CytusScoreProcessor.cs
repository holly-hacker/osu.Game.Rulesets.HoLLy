using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Cytus.Scoring
{
    internal class CytusScoreProcessor : ScoreProcessor<CytusHitObject>
    {
        protected CytusScoreProcessor() { }

        public CytusScoreProcessor(RulesetContainer<CytusHitObject> rulesetContainer) : base(rulesetContainer) { }

        protected override void SimulateAutoplay(Beatmap<CytusHitObject> beatmap)
        {
            foreach (CytusHitObject _ in beatmap.HitObjects)
                AddJudgement(new Judgement {Result = HitResult.Perfect});
        }
    }
}
