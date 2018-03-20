using System.Collections.Generic;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.HoLLy.Hex.Tests
{
    [System.ComponentModel.Description("Playfield with various lanecounts")]
    public class TestCasePlayfield : OsuTestCase
    {
        private HexPlayfield playfield;
        private Container c;
        public TestCasePlayfield()
        {
            Bindable<int> bindable = new Bindable<int>(6) {Default = 6};
            bindable.ValueChanged += i => {
                c.Remove(playfield);
                c.Add(playfield = new HexPlayfield(i));
            };

            Add(c = new Container
            {
                RelativeSizeAxes = Axes.Both,

                Children = new Drawable[] {
                    new SettingsDropdown<int> {
                        Items = new[] {
                            new KeyValuePair<string, int>("3. Triangle", 3),
                            new KeyValuePair<string, int>("4. Square", 4),
                            new KeyValuePair<string, int>("5. Pentagon", 5),
                            new KeyValuePair<string, int>("6. Hexagon", 6),
                            new KeyValuePair<string, int>("7. Heptagon", 7),
                            new KeyValuePair<string, int>("8. Octagon", 8),
                            new KeyValuePair<string, int>("9. Nonagon", 9),
                            new KeyValuePair<string, int>("10. Decagon", 10),
                        },
                        Bindable = bindable,
                        AutoSizeAxes = Axes.Y
                    },
                    playfield = new HexPlayfield(bindable.Value)
                }
            });
        }
    }
}
