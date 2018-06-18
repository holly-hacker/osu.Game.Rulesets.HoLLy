using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexInputManager : RulesetInputManager<HexAction>
    {
        //We're not going to need this for now, I don't have any use for buttons planned.
        public HexInputManager(RulesetInfo ruleset, int variant, SimultaneousBindingMode unique) : base(ruleset, variant, unique) { }
    }

    internal enum HexAction { }
}
