using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    internal class HexPlayfield : Playfield
    {
        private readonly HexLane[] lanes;
        public HexPlayfield(int laneCount)
        {
            Anchor = Anchor.Centre;

            //create lanes
            lanes = new HexLane[laneCount];
            for (int i = 0; i < laneCount; i++)
                lanes[i] = new HexLane(i, laneCount);

            InternalChildren = new Drawable[]
            {
                new Container
                {
                    Children = lanes
                }
            };
        }
    }
}
