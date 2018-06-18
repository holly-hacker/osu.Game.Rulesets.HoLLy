using System;
using System.Runtime.CompilerServices;
using OpenTK;
using osu.Framework.Graphics.Primitives;

namespace osu.Game.Rulesets.HoLLy.Hex.Graphics.Primitives
{
    public struct Polygon
    {
        public readonly Triangle[] Triangles;

        public Polygon(Vector2 center, float radius, int sides, double startAngle = 0.0) : this(center, radius, radius, sides, startAngle) { }
        public Polygon(Vector2 center, Vector2 radius, int sides, double startAngle = 0.0) : this(center, radius.X, radius.Y, sides, startAngle) { }

        public Polygon(Vector2 center, float radiusX, float radiusY, int sides, double startAngle = 0.0)
        {
            if (sides < 3)
                throw new ArgumentOutOfRangeException(nameof(sides), $"A {nameof(Polygon)} needs at least 3 sides. (has {sides})");

            Triangles = new Triangle[sides];
            
            float angleInterval = MathHelper.TwoPi / sides;    //in radians

            //get the first (shared) point
            var shared = CreateVector2(center, radiusX, radiusY, startAngle);
            Vector2 prev = CreateVector2(center, radiusX, radiusY, startAngle + angleInterval);

            for (int i = 2; i < sides; i++) {   //0 is shared, 1 is precalculated
                float angle = (float)startAngle + angleInterval * i;

                var curr = CreateVector2(center, radiusX, radiusY, angle);
                Triangles[i-2] = new Triangle(shared, prev, curr);
                prev = curr;
            }
        }

        //TODO: still doesn't stretch
        public Polygon(Quad a, int sides) : this(a.Centre, 
            new Vector2((a.TopRight - a.TopLeft).Length/2, (a.BottomRight - a.TopRight).Length / 2), 
            sides, (a.TopRight - a.TopLeft).AngleRadians()) { }

        /// <summary>
        /// Checks whether a point lies within the polygon.
        /// </summary>
        /// <param name="pos">The point to check.</param>
        /// <returns>Outcome of the check.</returns>
        public bool Contains(Vector2 pos)
        {
            foreach (Triangle t in Triangles)
                if (t.Contains(pos))
                    return true;
            return false;
        }

        public RectangleF AABBFloat
        {
            get {
                float xMin = float.PositiveInfinity, yMin = float.PositiveInfinity;
                float xMax = float.NegativeInfinity, yMax = float.NegativeInfinity;

                foreach (Triangle t in Triangles) {
                    RectangleF aabb = t.AABBFloat;
                    xMin = Math.Min(xMin, aabb.Left);
                    yMin = Math.Min(yMin, aabb.Top);
                    xMax = Math.Max(xMax, aabb.Right);
                    yMax = Math.Max(yMax, aabb.Bottom);
                }

                return new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
            }
        }

        public float Area
        {
            get {
                float area = 0;
                foreach (Triangle t in Triangles)
                    area += t.Area;
                return area;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Vector2 CreateVector2(Vector2 center, float sizeX, float sizeY, double angle) 
            => center + new Vector2((float)Math.Sin(angle) * sizeX, (float)Math.Cos(angle) * sizeY);
    }
}
