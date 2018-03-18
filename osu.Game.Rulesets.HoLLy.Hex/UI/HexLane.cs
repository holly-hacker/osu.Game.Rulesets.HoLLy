using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI.Scrolling;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Hex.UI
{
    //TODO colorize. through IHasAccentColour?
    internal class HexLane : ScrollingPlayfield
    {
        public new bool IsHovered => _laneBase.IsHovered;
        protected override Container<Drawable> Content { get; }

        private readonly int _index, _laneCount;
        private readonly HexLaneBase _laneBase;
        private readonly Container _lanePath;
        private readonly Color4 _laneColor;
        private readonly float _scaledHeight;

        public HexLane(int index, int laneCount) : base(ScrollingDirection.Left)
        {
            _index = index;
            _laneCount = laneCount;
            _laneColor = Utils.GetAccentColor(index, laneCount);
            VisibleTimeRange.Value = Constants.NoteSpeedBase;

            _scaledHeight = Height = Utils.GetHitobjectSize(laneCount);

            InternalChildren = new Drawable[]
            {
                _lanePath = new Container {
                    Child = new Box
                    {
                        Name = "LanePath",
                        RelativeSizeAxes = Axes.Both
                    },
                    Height = 3,         //thickness of the bar
                    X = _scaledHeight/2, //starts at the center of the polygon
                    Width = Constants.LaneLength - _scaledHeight/2,  //length, should be long enough so that the end cannot be seen
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,

                    Masking = true,
                    EdgeEffect = new EdgeEffectParameters {
                        Colour = _laneColor.Opacity(0f),    //invisible until hovered over
                        Type = EdgeEffectType.Glow,
                        Radius = _scaledHeight * 0.15f,
                    }
                },
                _laneBase = new HexLaneBase(this)
                {
                    Name = "LaneBase",
                    Size = new Vector2(_scaledHeight),   //should be same size as notes
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                },
                Content = new Container
                {
                    Name = "HitobjectContainer",
                    RelativeSizeAxes = Axes.Y,
                    X = _scaledHeight/2,             //starts at the center of the polygon, otherwise notes pop too late
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

        private class HexLaneBase : CircularContainer
        {
            private const double timeFadeIn = 200, timeFadeOut = 350;
            private static readonly Color4 ColorIdle = Color4.DarkGray;

            private readonly HexLane _parent;
            private readonly Color4 _laneColor;
            private readonly Polygon _poly;

            public HexLaneBase(HexLane parent)
            {
                _parent = parent;
                _laneColor = parent._laneColor;
                Add(_poly = new Polygon(parent._laneCount) {
                    RelativeSizeAxes = Axes.Both,
                    Colour = ColorIdle,
                });
            }

            protected override bool OnHover(InputState state)
            {
                _poly.FadeColour(_laneColor.Darken(0.325f), timeFadeIn, Easing.OutCubic);
                _parent._lanePath.FadeEdgeEffectTo(1f, timeFadeIn, Easing.OutCubic);

                return base.OnHover(state);
            }

            protected override void OnHoverLost(InputState state)
            {
                _poly.FadeColour(ColorIdle, timeFadeOut, Easing.OutCubic);
                _parent._lanePath.FadeEdgeEffectTo(0f, timeFadeOut, Easing.OutCubic);
            }
        }
    }
}
