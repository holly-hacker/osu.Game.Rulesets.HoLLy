using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.OpenGL.Vertices;
using osu.Framework.Graphics.Primitives;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Hex.Graphics.Shapes
{
    public class Polygon : Sprite
    {
        private readonly int _sides;
        
        public Polygon(int sides, Texture t = null)
        {
            if (sides < 3)
                throw new ArgumentOutOfRangeException(nameof(sides), $"A {nameof(Polygon)} needs at least 3 sides. (has {sides})");

            _sides = sides;
            
            Texture = t ?? Texture.WhitePixel;
        }

        //public override RectangleF BoundingBox => ToTriangle(ToParentSpace(LayoutRectangle)).AABBFloat;
        //public override bool Contains(Vector2 screenSpacePos) => ToTriangle(ScreenSpaceDrawQuad).Contains(screenSpacePos);

        private static Triangle ToTriangle(Quad q) => new Triangle(
            (q.TopLeft + q.TopRight) / 2,
            q.BottomLeft,
            q.BottomRight);
        
        protected override DrawNode CreateDrawNode() => new PolygonDrawNode(_sides);

        private class PolygonDrawNode : SpriteDrawNode
        {
            private readonly int _sides;
            private readonly Vector2[] _cornersRel;
            private readonly Vector2[] _cornersScaled;

            public PolygonDrawNode(int sides)
            {
                _sides = sides;
                _cornersRel = new Vector2[_sides];
                _cornersScaled = new Vector2[_sides];
                
                float angleInterval = MathHelper.TwoPi / _sides;
                for (int i = 0; i < _sides; i++) {
                    float thisAngle = angleInterval * i;
                    _cornersRel[i] = new Vector2((float)Math.Sin(thisAngle), (float)Math.Cos(thisAngle));
                }
            }

            protected override void Blit(Action<TexturedVertex2D> vertexAction)
            {
                //we have to recalculate the scaled positions, because ScreenSpaceDrawQuad changes
                Vector2 center = (ScreenSpaceDrawQuad.TopLeft + ScreenSpaceDrawQuad.BottomRight) / 2f;
                float radius = ScreenSpaceDrawQuad.Size.Length; //could be LengthFast, perhaps, but speed isn't super important here
                for (int i = 0; i < _sides; i++)
                    _cornersScaled[i] = center + _cornersRel[i] * radius;

                for (int i = 0; i < _sides; i++) {
                    var tr = new Triangle(center, _cornersScaled[i], _cornersScaled[(i + 1) % _sides]);
                    Texture.DrawTriangle(tr, DrawInfo.Colour);    //inflationPercentage: new Vector2(InflationAmount.X / DrawRectangle.Width, InflationAmount.Y / DrawRectangle.Height)
                }
            }
        }
    }
}
