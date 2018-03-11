using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.HoLLy.Test.Objects.Drawables
{
    internal class TestDrawable : DrawableHitObject<TestHitObject>
    {
        public TestDrawable(TestHitObject hitObject) : base(hitObject) { }

        protected override void UpdateState(ArmedState state)
        {
            // ¯\_(ツ)_/¯
        }
    }
}
