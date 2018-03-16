using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class Utils
    {
        private const int LanesMin = 3;
        private const int LanesMax = 10;

        public static int GetLaneCount(float od) => MathHelper.Clamp((int)od, LanesMin, LanesMax);
    }
}
