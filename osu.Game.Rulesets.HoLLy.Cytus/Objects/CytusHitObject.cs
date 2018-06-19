using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects
{
    internal class CytusHitObject : HitObject, IHasXPosition
    {
        public float X { get; }

        public CytusHitObject(double time, float x)
        {
            StartTime = time;
            X = x;
        }
    }
}
