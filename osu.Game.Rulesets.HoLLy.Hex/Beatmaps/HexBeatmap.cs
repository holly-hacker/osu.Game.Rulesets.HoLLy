using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;

namespace osu.Game.Rulesets.HoLLy.Hex.Beatmaps
{
    internal class HexBeatmap : Beatmap<HexHitObject>
    {
        public int? LaneCount { get; set; }
    }
}
