using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects;
using osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI
{
    internal class CytusRulesetContainer : RulesetContainer<CytusHitObject>
    {
        public CytusRulesetContainer(Ruleset ruleset, WorkingBeatmap workingBeatmap) : base(ruleset, workingBeatmap) { }

        public override PassThroughInputManager CreateInputManager() => new PassThroughInputManager();

        protected override Playfield CreatePlayfield() => new CytusPlayfield();

        protected override DrawableHitObject<CytusHitObject> GetVisualRepresentation(CytusHitObject h) => new CytusNote(h);
    }
}
