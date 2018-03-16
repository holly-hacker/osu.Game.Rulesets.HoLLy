using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables
{
    internal class HexNote : DrawableHitObject<HexHitObject>
    {
        public HexNote(HexHitObject hitObject, Texture tx) : base(hitObject)
        {
            Origin = Anchor.TopLeft;
            Anchor = Anchor.TopLeft;
            Size = new Vector2(64);

            RelativePositionAxes = Axes.Both;

            Add(new Sprite {
                Texture = tx,
                Origin = Anchor.Centre
            });
        }

        protected override void Update()
        {
            base.Update();

            if (Time.Current >= HitObject.StartTime)
                UpdateJudgement(true);
        }

        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            if (userTriggered)
                AddJudgement(new Judgement { Result = HitResult.Great });
        }

        protected override void UpdateState(ArmedState state)
        {
            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(2, 100, Easing.OutQuint).Then().FadeOut(100, Easing.OutQuint).Expire();
                    break;
                case ArmedState.Miss:
                    this.ScaleTo(0.5f, 200).Then().FadeOut(600, Easing.OutQuint).Expire();
                    break;
            }
        }
    }
}
