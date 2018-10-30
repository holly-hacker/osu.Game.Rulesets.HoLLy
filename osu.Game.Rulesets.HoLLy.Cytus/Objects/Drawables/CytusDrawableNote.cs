using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableNote : CytusDrawableHitObject
    {
        private readonly Sprite _noteBase, _noteCenter;

        public override bool HandlePositionalInput => true;

        public CytusDrawableNote(CytusNote hitObject, float x, float y, TextureStore textures) : base(hitObject, x, y)
        {
            AddInternal(new CircularContainer {
                Size = Vector2.One,
                RelativeSizeAxes = Axes.Both,
                Children = new [] {
                    _noteBase = new Sprite {
                        Texture = textures.Get("CytusNoteBase"),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    _noteCenter = new Sprite {
                        Texture = textures.Get("CytusNoteCenter"),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Depth = -1,
                        Scale = Vector2.Zero,
                    }
                }
            });
        }

        protected override bool OnMouseDown(MouseDownEvent e) => UpdateResult(true);

        protected override void UpdatePreemptState()
        {
            base.UpdatePreemptState();

            _noteBase.Spin(TimeRotate, RotationDirection.Clockwise);
            _noteCenter.ScaleTo(1, HitObject.TimePreempt, Easing.In);
        }
    }
}
