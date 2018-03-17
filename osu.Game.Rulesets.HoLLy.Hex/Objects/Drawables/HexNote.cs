using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables
{
    internal class HexNote : DrawableHitObject<HexHitObject>
    {
        public HexNote(HexHitObject hitObject, int laneCount) : base(hitObject)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Size = new Vector2(Utils.GetHitobjectSize(laneCount));
            
            Add(new Container
            {
                Children = new Drawable[] {
                    new Polygon(laneCount) {
                        Name = "Shape",
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                },
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Colour = Color4.DimGray,
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
