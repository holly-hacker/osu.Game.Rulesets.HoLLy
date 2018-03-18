using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables
{
    internal class HexNote : DrawableHitObject<HexHitObject>
    {
        private readonly HexLane _lane;

        public HexNote(HexLane lane, HexHitObject hitObject, int laneCount) : base(hitObject)
        {
            _lane = lane;
            
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
        }

        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            //at the moment the note is programmed, check if we're holding in the correct lane
            if (Time.Current >= HitObject.StartTime) {
                AddJudgement(_lane.IsHovered 
                    ? new Judgement {Result = HitResult.Great} 
                    : new Judgement {Result = HitResult.Miss});
            }
        }

        protected override void UpdateState(ArmedState state)
        {
            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(2, 100, Easing.OutCubic)
                        .FadeColour(Color4.Yellow, 100, Easing.OutQuint)
                        .Then()
                        .FadeOut(100, Easing.OutQuint)
                        .Expire();
                    break;
                case ArmedState.Miss:
                    this.ScaleTo(0.5f, 200)
                        .FadeColour(Color4.Red, 200, Easing.OutQuint)
                        .Then()
                        .FadeOut(600, Easing.OutCubic)
                        .Expire();
                    break;
            }
        }
    }
}
