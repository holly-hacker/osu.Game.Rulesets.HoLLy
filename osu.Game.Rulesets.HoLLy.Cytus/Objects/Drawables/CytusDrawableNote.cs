using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;
using osu.Framework.Input;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableNote : CytusDrawableHitObject
    {
        private Sprite NoteBase, NoteCenter;

        public CytusDrawableNote(CytusNote hitObject, TextureStore textures) : base(hitObject)
        {
            Alpha = 0;  // Start transparent

            Size = new Vector2(48f);
            
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
            
            AddInternal(new CircularContainer {
                Size = Vector2.One,
                RelativeSizeAxes = Axes.Both,
                Children = new [] {
                    NoteBase = new Sprite {
                        Texture = textures.Get("CytusNoteBase"),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    NoteCenter = new Sprite {
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

        protected override bool OnMouseDown(InputState state, MouseDownEventArgs args) => UpdateJudgement(true);

        protected override void UpdatePreemptState()
        {
            const int rotateTime = 2000;
            this.FadeIn(HitObject.TimePreempt * (2f/3f));
            NoteBase.Spin(rotateTime, RotationDirection.Clockwise);
            NoteCenter.ScaleTo(1, HitObject.TimePreempt, Easing.In);
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
