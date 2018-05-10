using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables;
using osu.Game.Rulesets.HoLLy.Hex.Scoring;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    internal class HexRulesetContainer : ScrollingRulesetContainer<HexPlayfield, HexHitObject>
    {
        public HexRulesetContainer(Ruleset ruleset, WorkingBeatmap workingBeatmap) 
            : base(ruleset, workingBeatmap) { }

        public override PassThroughInputManager CreateInputManager() => new HexInputManager(Ruleset.RulesetInfo, 0, SimultaneousBindingMode.None);

        protected override Playfield CreatePlayfield() => new HexPlayfield(Beatmap.GetLaneCount());

        protected override DrawableHitObject<HexHitObject> GetVisualRepresentation(HexHitObject h) => new HexNote(Playfield.Lanes[h.Lane], h, Beatmap.GetLaneCount());

        public override ScoreProcessor CreateScoreProcessor() => new HexScoreProcessor(this);
    }
}
