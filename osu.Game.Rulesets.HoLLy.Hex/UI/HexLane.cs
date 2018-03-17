using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI.Scrolling;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    //TODO colorize. through IHasAccentColour?
    internal class HexLane : ScrollingPlayfield
    {
        protected override Container<Drawable> Content { get; }

        private int _index;
        private readonly float _scaledWidth;

        public HexLane(int index, int laneCount) : base(ScrollingDirection.Up)
        {
            _index = index;
            VisibleTimeRange.Value = 2_000;

            _scaledWidth = Width = Utils.GetHitobjectSize(laneCount);
            Rotation = 360f * index / laneCount;
            Anchor = Anchor.TopCentre;
            Origin = Anchor.TopCentre;
            Padding = new MarginPadding {Top = Constants.PaddingBase};

            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Name = "LanePath",
                    Width = 3,                      //thickness of the bar
                    Height = Constants.LaneLength,  //length, should be long enough so that the end cannot be seen
                    Y = _scaledWidth/2,             //starts at the center of the polygon
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                },
                new Polygon(laneCount)
                {
                    Name = "LaneBase",
                    Size = new Vector2(_scaledWidth),   //should be same size as notes
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                },
                Content = new Container
                {
                    Name = "HitobjectContainer",
                    RelativeSizeAxes = Axes.X,
                    Height = Constants.LaneLength,
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.Centre,
                }
            };
        }

        public override void Add(DrawableHitObject h)
        {
            h.Depth = (float)h.HitObject.StartTime;
            h.Size = new Vector2(_scaledWidth);
            base.Add(h);
        }
    }
}
