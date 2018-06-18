using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.HoLLy.Hex.Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    internal class HexPlayfield : ScrollingPlayfield
    {
        public readonly HexLane[] Lanes;

        public HexPlayfield(int laneCount, bool biggerBase = false) : base(ScrollingDirection.Left)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.TopLeft;

            //create lanes
            Lanes = new HexLane[laneCount];
            for (int i = 0; i < laneCount; i++) {
                AddNested(Lanes[i] = new HexLane(i, laneCount, biggerBase) {
                    Rotation = 90f + 360f * i / laneCount,
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Padding = new MarginPadding { Left = Constants.PaddingBase * laneCount / 10f },
                    OnUpdate = drawable => drawable.Rotation += (float)Time.Elapsed / 16f * 0.0625f
                });
            }

            Children = new Drawable[]
            {
                new Container
                {
                    Children = Lanes
                }
            };
        }

        public override void Add(DrawableHitObject h)
        {
            //pass through to the correct lane
            Lanes[((HexNote)h).HitObject.Lane].Add(h);
        }
    }
}
