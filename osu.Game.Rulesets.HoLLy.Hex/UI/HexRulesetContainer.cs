using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    internal class HexRulesetContainer : ScrollingRulesetContainer<HexPlayfield, HexHitObject>
    {
        public HexRulesetContainer(Ruleset ruleset, WorkingBeatmap workingBeatmap, bool isForCurrentRuleset) 
            : base(ruleset, workingBeatmap, isForCurrentRuleset) { }

        public override PassThroughInputManager CreateInputManager() => new HexInputManager(Ruleset.RulesetInfo, 0, SimultaneousBindingMode.None);

        protected override Playfield CreatePlayfield() => new HexPlayfield(WorkingBeatmap.Beatmap.GetLaneCount());

        protected override BeatmapConverter<HexHitObject> CreateBeatmapConverter() => new HexBeatmapConverter();

        protected override DrawableHitObject<HexHitObject> GetVisualRepresentation(HexHitObject h) => new HexNote(Playfield.Lanes[h.Lane], h, WorkingBeatmap.Beatmap.GetLaneCount());
    }
}
