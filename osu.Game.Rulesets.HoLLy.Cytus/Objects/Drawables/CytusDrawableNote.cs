using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Game.Rulesets.Objects.Drawables;
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
