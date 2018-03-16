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
        public override bool IsPresent => base.IsPresent && Time.Current >= HitObject.StartTime - 2000;

        public HexNote(HexHitObject hitObject, Texture tx) : base(hitObject)
        {
            Origin = Anchor.TopLeft;
            Anchor = Anchor.TopLeft;
            Size = new Vector2(64);
            Position = new Vector2((float)hitObject.Lane / (hitObject.LaneCount - 1), (float)hitObject.StartTime / 100f);

            RelativePositionAxes = Axes.X;

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
                case ArmedState.Miss:
                    this.ScaleTo(2, 200).Then().FadeOut(200, Easing.OutQuint).Expire();
                    break;
            }
        }
    }
}
