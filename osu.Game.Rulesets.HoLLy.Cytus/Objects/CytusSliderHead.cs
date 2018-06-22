namespace osu.Game.Rulesets.HoLLy.Cytus.Objects
{
    internal class CytusSliderHead : CytusHitObject
    {
        public CytusSliderTick Next { get; }

        public CytusSliderHead(double time, float x, float y, CytusSliderTick next) : base(time, x, y)
        {
            Next = next;
        }
    }
}
