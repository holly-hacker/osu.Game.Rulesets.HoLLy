using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input;
using osu.Framework.Logging;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableSliderHead : CytusDrawableHitObject
    {
        protected readonly Sprite _noteBase, _noteCenter;

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
                    _noteCenter = new Sprite {
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

            Logger.Log($"{GetType().Name} rotation: {_noteCenter.Rotation}");
        }
        
        protected override bool OnMouseDown(InputState state, MouseDownEventArgs args) => UpdateJudgement(true);

        protected override void UpdatePreemptState()
        {
            const int rotateTime = 2000;
            this.FadeIn(HitObject.TimePreempt * (2f/3f));
            _noteBase.Spin(rotateTime, RotationDirection.Clockwise);
            _noteCenter.ScaleTo(1, HitObject.TimePreempt, Easing.In);
        }

        protected override void UpdateCurrentState(ArmedState state)
        {
            const double timeFadeHit = 100, timeFadeMiss = 500;

            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(1.25f, timeFadeHit, Easing.OutCubic)
                        .FadeOut(timeFadeHit)
                        .Expire();
                    break;
                case ArmedState.Miss:
                    this.FadeOut(timeFadeMiss, Easing.OutCubic)
                        .ScaleTo(0.5f, timeFadeMiss)
                        .Expire();
                    break;
            }
        }
    }
}
