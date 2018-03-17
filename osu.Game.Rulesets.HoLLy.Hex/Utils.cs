using OpenTK;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal static class Utils
    {
        public static int GetLaneCount(float od) => MathHelper.Clamp((int)od, Constants.LanesMin, Constants.LanesMax);
        public static float GetHitobjectSize(int laneCount) => Constants.ColumnWidthBase / laneCount;
    }
}
