using System.Diagnostics;
using System.Linq;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Game.Rulesets.Scoring;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableHoldNote : CytusDrawableHitObject
    {
        private CircularProgress progress;
        private bool pressed = false;

        public CytusDrawableHoldNote(CytusHitObject hitObject, float x, float y) : base(hitObject, x, y)
        {
            AddInternal(new CircularContainer {
                Size = Vector2.One,
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[] {
                    new Circle {
                        Colour = new Color4(0xB8, 0x6B, 0x9A, 255),
                        Size = Vector2.One,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    progress = new CircularProgress {
                        Alpha = 0f,
                        Size = Vector2.One * 1.5f,
                        InnerRadius = 0.1f,
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    }
                }
            });
        }

        protected override bool OnMouseDown(MouseDownEvent e)
        {
            // TODO: what if pressed from 2 positions? (ie. touch input)
            // TODO: check time

            if (pressed)
                return false;

            pressed = true;
            PlaySamples();
            return true;
        }

        protected override bool OnMouseUp(MouseUpEvent e)
        {
            if (!pressed)
                return false;

            pressed = false;

            UpdateResult(true);

            return true;
        }

        protected override void CheckForResult(bool userTriggered, double timeOffset)
        {
            if (userTriggered) {
                if (timeOffset >= 0) {
                    ApplyResult(jr => jr.Type = HitResult.Perfect);
                } else {
                    var res = HitObject.HitWindows.ResultFor(timeOffset);
                    ApplyResult(jr => jr.Type = res != HitResult.None ? res : HitResult.Miss);
                }
            } else {
                // too late
                if (timeOffset - ((CytusHoldNote)HitObject).Duration >= HitObject.HitWindows.HalfWindowFor(HitResult.Meh))
                    ApplyResult(jr => jr.Type = HitResult.Miss);
            }
        }

        protected override void Update()
        {
            base.Update();

            if (pressed) {
                if (!progress.IsPresent)
                    progress.FadeIn(100);

                var obj = (CytusHoldNote)HitObject;
                double prog = (Clock.CurrentTime - obj.StartTime) / (obj.EndTime - obj.StartTime);

                if (prog >= 1)
                    UpdateResult(true);

                Logger.Log("Progress: " + prog);
                progress.Current.Value = prog;
            }
        }
    }
}
