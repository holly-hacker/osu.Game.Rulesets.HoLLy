using System;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal abstract class CytusDrawableHitObject : DrawableHitObject<CytusHitObject>
    {
        protected CytusDrawableHitObject(CytusHitObject hitObject, float x, float y) : base(hitObject)
        {
            Alpha = 0;  // Start transparent

            Size = new Vector2(48f);    // TODO: calculate this
            
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

        protected abstract void UpdatePreemptState();
        protected abstract void UpdateCurrentState(ArmedState state);
    }
}
