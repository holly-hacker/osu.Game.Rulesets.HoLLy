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

        public HexLane(int index, int laneCount) : base(ScrollingDirection.Left)
        {
            _index = index;
            VisibleTimeRange.Value = Constants.NoteSpeedBase;

            float scaledHeight = Height = Utils.GetHitobjectSize(laneCount);

            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Name = "LanePath",
                    Height = 3,         //thickness of the bar
                    X = scaledHeight/2, //starts at the center of the polygon
                    Width = Constants.LaneLength - scaledHeight/2,  //length, should be long enough so that the end cannot be seen
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                },
                new Polygon(laneCount)
                {
                    Name = "LaneBase",
                    Size = new Vector2(scaledHeight),   //should be same size as notes
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                },
                Content = new Container
                {
                    Name = "HitobjectContainer",
                    RelativeSizeAxes = Axes.Y,
                    Width = Constants.LaneLength,
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.Centre,
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
