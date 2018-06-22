using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects
{
    internal abstract class CytusHitObject : HitObject, IHasXPosition, IHasYPosition
    {
        public float X { get; }
        public float Y { get; }
        public double TimePreempt { get; }

        protected CytusHitObject(double time, float x, float y)
        {
            StartTime = time;
            X = x;
            Y = y;

            // TODO: this should be dependent on BPM/timingpoint
            TimePreempt = 750;
        }

    }
}
