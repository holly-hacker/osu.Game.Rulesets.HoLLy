using System;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables
{
    internal class HexNote : DrawableHitObject<HexHitObject>
    {
        public HexNote(HexHitObject hitObject) : base(hitObject) { }

        protected override void UpdateState(ArmedState state)
        {
            throw new NotImplementedException();    //not yet sure what to do here
        }
    }
}
