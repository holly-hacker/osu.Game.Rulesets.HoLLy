using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusNote : DrawableHitObject<CytusHitObject>
    {
        private Sprite NoteBase, NoteCenter;

        public CytusNote(CytusHitObject hitObject, TextureStore textures) : base(hitObject)
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
        
        protected override void UpdateState(ArmedState state)
        {
            double transformTime = HitObject.StartTime - HitObject.TimePreempt;

            ApplyTransformsAt(transformTime, true);
            ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true))
            {
                UpdatePreemptState();

                using (BeginDelayedSequence(HitObject.TimePreempt + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        private void UpdatePreemptState()
        {
            const int rotateTime = 2000;
            this.FadeIn(HitObject.TimePreempt * (2f/3f));
            NoteBase.Spin(rotateTime, RotationDirection.Clockwise);
            NoteCenter.ScaleTo(1, HitObject.TimePreempt, Easing.In);
        }

        private void UpdateCurrentState(ArmedState state)
        {
            const double timeFadeHit = 100, timeFadeMiss = 200;

            switch (state) {
                case ArmedState.Idle:
                    this.ScaleTo(0.5f, timeFadeMiss)
                        .FadeOut(timeFadeMiss)
                        .Expire();
                    break;
                case ArmedState.Hit:
                    this.ScaleTo(2, timeFadeHit / 3, Easing.OutCubic)
                        .FadeOut(timeFadeHit)
                        .Expire();
                    break;
                case ArmedState.Miss:
                    this.ScaleTo(0.5f, timeFadeMiss, Easing.InCubic)
                        .FadeOut(timeFadeMiss)
                        .Expire();
                    break;
            }
        }
    }
}
