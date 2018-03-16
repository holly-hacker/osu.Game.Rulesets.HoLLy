using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI.Scrolling;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    //TODO colorize. through IHasAccentColour?
    internal class HexLane : ScrollingPlayfield
    {
        private const float ColumnWidthBase = 150f;
        private const float PaddingBase = 80f;

        protected override Container<Drawable> Content { get; }

        private int _index;

        public HexLane(int index, int laneCount) : base(ScrollingDirection.Up)
        {
            _index = index;
            VisibleTimeRange.Value = 10000.0;   //TODO: this is a hack, figure out the proper way

            float scaledWidth = Width = ColumnWidthBase / laneCount;
            Rotation = 360f * index / laneCount;
            Anchor = Anchor.BottomCentre;
            Padding = new MarginPadding {Top = PaddingBase};

            InternalChildren = new Drawable[]
            {
                //line
                new Box
                {
                    Width = 3,
                    Height = 300,
                    Y = scaledWidth,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.TopCentre
                },
                new Polygon(laneCount)
                {
                    Width = scaledWidth,
                    Height = scaledWidth,
                    //Rotation = 180,
                    Origin = Anchor.Centre,
                },
                Content = new Container {
                    RelativeSizeAxes = Axes.Both,
                    Origin = Anchor.BottomCentre
                }
            };
        }

        public override void Add(DrawableHitObject h)
        {
            h.Depth = (float)h.HitObject.StartTime;
            base.Add(h);
        }
    }
}
