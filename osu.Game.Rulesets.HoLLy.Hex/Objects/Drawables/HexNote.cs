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
            Origin = Anchor.Centre;
            Anchor = Anchor.Centre;
            Size = new Vector2(64);
            Position = new Vector2((float)hitObject.Lane / (hitObject.LaneCount - 1), (float)hitObject.StartTime / 100f);

            RelativePositionAxes = Axes.X;

            Add(new Sprite {
                Texture = tx
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
                AddJudgement(new Judgement { Result = HitResult.Good });
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
