using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects
{
    internal class CytusHitObject : HitObject, IHasXPosition
    {
        public float X { get; }
        public double TimePreempt { get; }

        public CytusHitObject(double time, float x)
        {
            StartTime = time;
            X = x;

            // TODO: this should be dependent on BPM
            TimePreempt = 750;
        }
    }
}
