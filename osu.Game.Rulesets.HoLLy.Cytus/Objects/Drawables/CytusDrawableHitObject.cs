using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
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
        
        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            // TODO: use own judgement class, probably

            if (!userTriggered) {
                if (!HitObject.HitWindows.CanBeHit(timeOffset))
                    AddJudgement(new Judgement { Result = HitResult.Miss });
                return;
            }

            var result = HitObject.HitWindows.ResultFor(timeOffset);
            if (result == HitResult.None)
                return;

            AddJudgement(new Judgement { Result = result });
        }
        
        protected override void UpdateState(ArmedState state)
        {
            double transformTime = HitObject.StartTime - HitObject.TimePreempt;

            ApplyTransformsAt(transformTime, true);
            ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true))
            {
                UpdatePreemptState();

                using (BeginDelayedSequence(HitObject.TimePreempt + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        protected abstract void UpdatePreemptState();
        protected abstract void UpdateCurrentState(ArmedState state);
    }
}
