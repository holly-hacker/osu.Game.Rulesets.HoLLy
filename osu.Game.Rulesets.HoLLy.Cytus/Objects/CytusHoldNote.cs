using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects
{
    internal class CytusHoldNote : CytusHitObject, IHasEndTime
    {
        public double EndTime { get; }
        public double Duration => EndTime - StartTime;

        public CytusHoldNote(double time, double endTime, float x, float y) : base(time, x, y)
        {
            EndTime = endTime;
        }
    }
}
