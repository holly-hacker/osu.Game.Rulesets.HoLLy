using osu.Framework.Graphics.Textures;

namespace osu.Game.Rulesets.HoLLy.Cytus.Objects.Drawables
{
    internal class CytusDrawableSliderEnd : CytusDrawableSliderTick
    {
        public CytusDrawableSliderEnd(CytusSliderTick hitObject, float x, float y, TextureStore textures) : base(hitObject, x, y, textures)
        {
            // Don't show the arrow, since we're the last one
            SliderArrow.Hide();
        }
    }
}
