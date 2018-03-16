using System;
using System.Collections.Generic;
using System.Diagnostics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Hex.Beatmaps
{
    internal class HexBeatmapConverter : BeatmapConverter<HexHitObject>
    {
        private const int LanesMin = 3;
        private const int LanesMax = 10;

        protected override IEnumerable<Type> ValidConversionTypes => new[] {typeof(IHasXPosition)};

        protected override IEnumerable<HexHitObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            float od = beatmap.BeatmapInfo.BaseDifficulty.OverallDifficulty;
            float x = ((IHasXPosition)original).X;

            int laneCount = Math.Max(LanesMin, Math.Min((int)od, LanesMax));
            int lane = (int)(x / (512f + 1) * laneCount);

            Debug.Assert(lane >= 0);
            Debug.Assert(lane < laneCount);

            yield return new HexHitObject(lane, laneCount, original);
        }
    }
}
