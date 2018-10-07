using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.HoLLy.Hex.UI;
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

            AddInternal(new CircularContainer
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

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            // At the moment the note is programmed, check if we're holding in the correct lane
            if (Time.Current >= HitObject.StartTime) {
                ApplyResult(r => r.Type = _lane.IsHovered 
                    ? HitResult.Perfect
                    : HitResult.Miss);
            }
        }

        protected override void UpdateState(ArmedState state)
        {
            const double timeFadeHit = 250, timeFadeMiss = 400;

            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(2, timeFadeHit / 3, Easing.OutCubic)
                        .FadeColour(Color4.Yellow, timeFadeHit / 3, Easing.OutQuint)
                        .FadeOut(timeFadeHit)
                        .Expire();
                    break;
                case ArmedState.Miss:
                    this.ScaleTo(0.5f, timeFadeMiss, Easing.InCubic)
                        .FadeColour(Color4.Red, timeFadeMiss, Easing.OutQuint)
                        .FadeOut(timeFadeMiss)
                        .Expire();
                    break;
            }
        }
    }
}
