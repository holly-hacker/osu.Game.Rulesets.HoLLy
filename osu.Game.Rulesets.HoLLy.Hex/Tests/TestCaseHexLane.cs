using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Testing;
using osu.Game.Rulesets.HoLLy.Hex.UI;

namespace osu.Game.Rulesets.HoLLy.Hex.Tests
{
    [System.ComponentModel.Description("Draw various HexLanes")]
    public class TestCaseHexLane : TestCase
    {
        public TestCaseHexLane()
        {
            const int minCount = Constants.LanesMin;
            const int maxCount = Constants.LanesMax;

            Add(new ScrollContainer {
                RelativeSizeAxes = Axes.Both,

                Child = new FillFlowContainer {
                    RelativeSizeAxes = Axes.X,
                    Children = Enumerable.Range(minCount, maxCount - minCount).Select(i => new HexLane(i, i)).ToArray()
                }
            });
        }
    }
}
