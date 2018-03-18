using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes;
using osu.Game.Tests.Visual;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Hex.Tests
{
    [System.ComponentModel.Description("Draws polygons in various scanarios")]
    public class TestCasePolygon : OsuTestCase
    {
        public TestCasePolygon()
        {
            FillFlowContainer flow;

            Add(new ScrollContainer {
                RelativeSizeAxes = Axes.Both,
                Child = flow = new FillFlowContainer {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Direction = FillDirection.Full
                }
            });

            const int size = 2 * 64;
            const int minCount = Constants.LanesMin;
            const int maxCount = Constants.LanesMax;

            //against a box and circle background
            for (int i = minCount; i <= maxCount; i++) {
                flow.Add(new Container {
                    Children = new Drawable[] {
                        new Box {
                            Size = new Vector2(size),
                            Colour = Color4.Orange
                        },
                        new Circle {
                            Size = new Vector2(size),
                            Colour = Color4.BlueViolet
                        },
                        new Polygon(i) {
                            Size = new Vector2(size)
                        }
                    },
                    AutoSizeAxes = Axes.Both
                });
            }

            //in a circular container with glow
            for (int i = minCount; i <= maxCount; i++) {
                flow.Add(new CircularContainer {
                    Child = new Polygon(i) {
                        Size = new Vector2(size),
                        Colour = Color4.Black
                    },
                    AutoSizeAxes = Axes.Both,

                    Masking = true,
                    EdgeEffect = new EdgeEffectParameters {
                        Colour = Color4.HotPink,
                        Type = EdgeEffectType.Glow,
                        Radius = size/5f
                    }
                });
            }

            //without container
            for (int i = minCount; i <= maxCount; i++) {
                flow.Add(new Polygon(i) {
                    Size = new Vector2(size),
                    Colour = Color4.Tomato
                });
            }

            //in a circular container, stretched in Y
            for (int i = minCount; i <= maxCount; i++) {
                flow.Add(new CircularContainer {
                    Children = new Drawable[] {
                        new Circle {
                            Size = new Vector2(size, size * 2),
                            Colour = Color4.DarkSlateGray
                        },
                        new Polygon(i) {
                            Size = new Vector2(size, size * 2),
                            Colour = Color4.SkyBlue
                        }
                    },
                    AutoSizeAxes = Axes.Both
                });
            }

            //in a circular container, scaled in Y
            for (int i = minCount; i <= maxCount; i++) {
                flow.Add(new CircularContainer {
                    Children = new Drawable[] {
                        new Circle {
                            Size = new Vector2(size),
                            Colour = Color4.DarkCyan
                        },
                        new Polygon(i) {
                            Size = new Vector2(size),
                            Colour = Color4.LemonChiffon
                        }
                    },
                    AutoSizeAxes = Axes.Both,
                    Scale = new Vector2(1, 2)
                });
            }
        }
    }
}
