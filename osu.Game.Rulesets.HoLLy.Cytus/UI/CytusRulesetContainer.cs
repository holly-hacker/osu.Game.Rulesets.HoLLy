using osu.Framework.Graphics.Textures;
using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects;
using osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables;
using osu.Game.Rulesets.HoLLy.Cytus.Scoring;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI
{
    internal class CytusRulesetContainer : RulesetContainer<CytusHitObject>
    {
        private readonly TextureStore _textures;

        public CytusRulesetContainer(Ruleset ruleset, WorkingBeatmap workingBeatmap, TextureStore textures) : base(ruleset, workingBeatmap)
        {
            _textures = textures;
        }

        public override PassThroughInputManager CreateInputManager() => new PassThroughInputManager();

        public override ScoreProcessor CreateScoreProcessor() => new CytusScoreProcessor(this);

        protected override Playfield CreatePlayfield() => new CytusPlayfield(Beatmap);

        protected override DrawableHitObject<CytusHitObject> GetVisualRepresentation(CytusHitObject h) => new CytusNote(h, _textures);
    }
}
