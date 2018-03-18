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

        public Polygon(int sides)
        {
            _sides = sides;
            Texture = Texture.WhitePixel;
        }

        public override RectangleF BoundingBox => ToPolygon(LayoutRectangle, _sides).AABBFloat;
        //public override RectangleF BoundingBox => ToPolygon(ToParentSpace(LayoutRectangle), _sides).AABBFloat;

        //TODO: this is horribly wrong, but polygon primitives can't be skewed yet
        private static Primitives.Polygon ToPolygon(Quad q, int sides) => new Primitives.Polygon(q.Centre, q.Width/2, q.Height/2, sides);

        public override bool Contains(Vector2 screenSpacePos) => ToPolygon(ScreenSpaceDrawQuad, _sides).Contains(screenSpacePos);

        protected override DrawNode CreateDrawNode() => new PolygonDrawNode(_sides);

        private class PolygonDrawNode : SpriteDrawNode
        {
            private readonly int _sides;

            public PolygonDrawNode(int sides) => _sides = sides;

            protected override void Blit(Action<TexturedVertex2D> vertexAction)
            {
                foreach(var t in ToPolygon(ScreenSpaceDrawQuad, _sides).Triangles)
                    Texture.DrawTriangle(t, DrawInfo.Colour);
            }
        }
    }
}
