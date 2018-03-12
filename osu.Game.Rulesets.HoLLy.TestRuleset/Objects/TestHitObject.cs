using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Test.Objects
{
    internal class TestHitObject : HitObject, IHasPosition
    {
        public Vector2 Position { get; }

        public float X => Position.X;
        public float Y => Position.Y;
        
        public TestHitObject(Vector2 p, HitObject original) : this(p, original.StartTime) { }

        public TestHitObject(Vector2 p, double startTime)
        {
            this.Position = p;
            base.StartTime = startTime;
        }
    }
}
