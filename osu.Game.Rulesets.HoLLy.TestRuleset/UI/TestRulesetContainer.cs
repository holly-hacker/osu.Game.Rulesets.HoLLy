using System;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Test.Beatmaps;
using osu.Game.Rulesets.HoLLy.Test.Objects;
using osu.Game.Rulesets.HoLLy.Test.Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Test.UI
{
    internal class TestRulesetContainer : RulesetContainer<TestPlayfield, TestHitObject>
    {
        public TestRulesetContainer(Ruleset ruleset, WorkingBeatmap beatmap, bool isForCurrentRuleset) : base(ruleset, beatmap, isForCurrentRuleset) { }

        public override PassThroughInputManager CreateInputManager() => new TestInputManager(base.Ruleset.RulesetInfo);

        protected override Playfield CreatePlayfield() => new TestPlayfield();

        protected override BeatmapConverter<TestHitObject> CreateBeatmapConverter() => new TestBeatmapConverter();

        protected override DrawableHitObject<TestHitObject> GetVisualRepresentation(TestHitObject h) => new TestDrawable(h);
    }
}
