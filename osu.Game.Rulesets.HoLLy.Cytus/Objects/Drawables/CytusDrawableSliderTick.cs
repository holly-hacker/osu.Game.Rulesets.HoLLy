using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Game.Rulesets.Scoring;
using OpenTK.Input;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableSliderTick : CytusDrawableSliderHead
    {
        public CytusDrawableSliderTick(CytusSliderTick hitObject, float x, float y, TextureStore textures) : base(hitObject, x, y, textures)
        {
            Size /= 1.5f;
        }

        protected override bool OnMouseDown(MouseDownEvent e) => false;

        protected override void Update()
        {
            base.Update();

            // Check if this is judging time
            if (HitObject.StartTime <= Time.Current && !AllJudged) {
                // Check if user is holding
                if (IsHovered && Mouse.GetState().IsAnyButtonDown)    // HACK: should check for IsHeldDown/IsPressed or something
                    // Great
                    ApplyResult(r => r.Type = HitResult.Perfect);
                else
                    ApplyResult(r => r.Type = HitResult.Miss);
            }
        }
    }
}
