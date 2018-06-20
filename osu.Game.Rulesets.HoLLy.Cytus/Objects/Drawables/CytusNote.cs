using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusNote : DrawableHitObject<CytusHitObject>
    {
        public CytusNote(CytusHitObject hitObject) : base(hitObject)
        {
            Alpha = 0;  // Start transparent

            Size = new Vector2(48f);
            
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            // Temporary, for now
            AddInternal(new Circle {
                Width = 1f,
                Height = 1f,
                RelativeSizeAxes = Axes.Both
            });
        }
        
        protected override void UpdateState(ArmedState state)
        {
            double transformTime = HitObject.StartTime - HitObject.TimePreempt;

            base.ApplyTransformsAt(transformTime, true);
            base.ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true))
            {
                UpdatePreemptState();

                using (BeginDelayedSequence(HitObject.TimePreempt + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        private void UpdatePreemptState()
        {
            this.FadeIn(HitObject.TimePreempt * (2f/3f));
        }

        private void UpdateCurrentState(ArmedState state)
        {
            const double timeFadeHit = 100, timeFadeMiss = 200;

            switch (state) {
                case ArmedState.Idle:
                    this.ScaleTo(0.5f, timeFadeMiss)
                        .FadeOut(timeFadeMiss)
                        .Expire();
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
