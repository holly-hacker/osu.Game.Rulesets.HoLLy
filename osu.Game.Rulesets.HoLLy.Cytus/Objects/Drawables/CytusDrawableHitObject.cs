using System;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal abstract class CytusDrawableHitObject : DrawableHitObject<CytusHitObject>
    {
        protected const int TimeRotate = 2000;
        protected const double TimeFadeHit = 100, TimeFadeMiss = 500;

        protected CytusDrawableHitObject(CytusHitObject hitObject, float x, float y) : base(hitObject)
        {
            Alpha = 0;  // Start transparent

            Size = new Vector2(96f);    // TODO: make this not dependent on resolution (in playfield)

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            RelativePositionAxes = Axes.Y;
            RelativeSizeAxes = Axes.None;

            X = x;
            Y = y;
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            // TODO: use own judgment class, probably

            if (!userTriggered) {
                if (!HitObject.HitWindows.CanBeHit(timeOffset))
                    ApplyResult(r => r.Type = HitResult.Miss);
                return;
            }

            var result = HitObject.HitWindows.ResultFor(timeOffset);
            if (result == HitResult.None)
                return;

            ApplyResult(r => r.Type = result);
        }

        protected override void UpdateState(ArmedState state)
        {
            double transformTime = HitObject.StartTime - HitObject.TimePreempt;

            ApplyTransformsAt(transformTime, true);
            ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true))
            {
                UpdatePreemptState();

                var judgementOffset = Math.Min(HitObject.HitWindows.HalfWindowFor(HitResult.Miss), Result?.TimeOffset ?? 0);

                using (BeginDelayedSequence(HitObject.TimePreempt + judgementOffset, true))
                    UpdateCurrentState(state);
            }
        }
        protected virtual void UpdatePreemptState()
        {
            this.FadeIn(HitObject.TimePreempt * (2f / 3f));
        }

        protected virtual void UpdateCurrentState(ArmedState state)
        {
            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(1.25f, TimeFadeHit, Easing.OutCubic)
                        .FadeOut(TimeFadeHit)
                        .Expire();
                    break;
                case ArmedState.Miss:
                    this.FadeOut(TimeFadeMiss, Easing.OutCubic)
                        .ScaleTo(0.5f, TimeFadeMiss)
                        .Expire();
                    break;
            }
        }
    }
}
