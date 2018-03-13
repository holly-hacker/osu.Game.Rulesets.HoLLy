using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects
{
    internal class HexHitObject : HitObject, IHasXPosition
    {
        public float X => 512f * Lane / LaneCount;
        public int Lane { get; }
        public int LaneCount { get; }

        public HexHitObject(int lane, int totalLanes)
        {
            Lane = lane;
            LaneCount = totalLanes;
        }
    }
}
