using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Test
{
    internal class TestInputManager : RulesetInputManager<TestAction>
    {
        public TestInputManager(RulesetInfo ruleset) : base(ruleset, 0, SimultaneousBindingMode.Unique) { }
        public TestInputManager(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique) : base(ruleset, variant, unique) { }
    }

    public enum TestAction
    {
        [Description("Test Input 1")]
        Input1,
    }
}
