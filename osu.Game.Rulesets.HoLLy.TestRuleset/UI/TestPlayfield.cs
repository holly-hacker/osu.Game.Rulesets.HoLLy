using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Test.UI
{
    internal class TestPlayfield : Playfield
    {
        public TestPlayfield() : base(null, null) { }
        protected TestPlayfield(float? customWidth = null, float? customHeight = null) : base(customWidth, customHeight) { }
    }
}
