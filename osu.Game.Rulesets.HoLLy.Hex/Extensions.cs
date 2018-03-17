using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal static class Extensions
    {
        public static int GetLaneCount(this Beatmap b) => Utils.GetLaneCount(b.BeatmapInfo.BaseDifficulty.OverallDifficulty);
    }
}
