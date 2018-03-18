using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    internal class HexPlayfield : ScrollingPlayfield
    {
        private readonly HexLane[] lanes;
        public HexPlayfield(int laneCount) : base(ScrollingDirection.Left)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.TopLeft;

            //create lanes
            lanes = new HexLane[laneCount];
            for (int i = 0; i < laneCount; i++) {
                AddNested(lanes[i] = new HexLane(i, laneCount) {
                    Rotation = 90f + 360f * i / laneCount,
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Padding = new MarginPadding { Left = Constants.PaddingBase },
                });
            }

            Children = new Drawable[]
            {
                new Container
                {
                    Children = lanes
                }
            };
        }

        public override void Add(DrawableHitObject h)
        {
            //pass through to the correct lane
            lanes[((HexNote)h).HitObject.Lane].Add(h);
        }
    }
}
