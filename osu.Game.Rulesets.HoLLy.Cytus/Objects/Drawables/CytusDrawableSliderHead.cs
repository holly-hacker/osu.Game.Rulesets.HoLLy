using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableSliderHead : CytusDrawableHitObject
    {
        private readonly Sprite _noteBase;
        protected readonly Sprite SliderArrow;

        public CytusDrawableSliderHead(CytusSliderHead hitObject, float x, float y, TextureStore textures) : base(hitObject, x, y)
        {
            AddInternal(new CircularContainer {
                Size = Vector2.One,
                RelativeSizeAxes = Axes.Both,
                Children = new[] {
                    _noteBase = new Sprite {
                        Texture = textures.Get("CytusSliderBase"),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    SliderArrow = new Sprite {
                        Texture = textures.Get("CytusSliderArrow"),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Depth = -1,
                        Scale = Vector2.Zero,

                        Rotation = hitObject.Next != null
                            ? (float)(-45f + 90f + Math.Atan2((hitObject.Next.Y - HitObject.Y) * Constants.PlayfieldSizeY, hitObject.Next.X - HitObject.X) * 180f/Math.PI)
                            : -45f  // Shouldn't happen unless we're SliderEnd
                    }
                }
            });
        }

        protected override bool OnMouseDown(MouseDownEvent e) => UpdateResult(true);

        protected override void UpdatePreemptState()
        {
            base.UpdatePreemptState();

            _noteBase.Spin(TimeRotate, RotationDirection.Clockwise);
            SliderArrow.ScaleTo(1, HitObject.TimePreempt, Easing.In);
        }
    }
}
