using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects
{
    internal class HexHitObject : HitObject
    {
        //public float X => 512f * Lane / LaneCount;
        public int Lane { get; }
        public int LaneCount { get; }

        public HexHitObject(int lane, int totalLanes, HitObject original)
        {
            Lane = lane;
            LaneCount = totalLanes;

            StartTime = original.StartTime;
        }

        public override Judgement CreateJudgement() => new Judgement();
    }
}
