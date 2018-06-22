using System;
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

        protected override DrawableHitObject<CytusHitObject> GetVisualRepresentation(CytusHitObject obj)
        {
            float x = obj.X - CytusPlayfield.BASE_SIZE.X / 2;
            float y = Beatmap.GetScanPosition(obj.StartTime, Constants.BeatsPerScan);

            switch (obj) {
                    case CytusNote n:       return new CytusDrawableNote(n, x, y, _textures);
                    case CytusSliderEnd e:  return new CytusDrawableSliderEnd(e, x, y, _textures);    // Order matters for slider pieces
                    case CytusSliderTick t: return new CytusDrawableSliderTick(t, x, y, _textures);
                    case CytusSliderHead h: return new CytusDrawableSliderHead(h, x, y, _textures);
                    default:
                        throw new Exception("Unexpected hitobject type");
            }
        }
    }
}
