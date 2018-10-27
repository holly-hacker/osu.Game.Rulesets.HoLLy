using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects
{
    internal class HexHitObject : HitObject
    {
        public int Lane { get; }

        public HexHitObject(int lane)
        {
            Lane = lane;
        }

        public override Judgement CreateJudgement() => new Judgement();
    }
}
