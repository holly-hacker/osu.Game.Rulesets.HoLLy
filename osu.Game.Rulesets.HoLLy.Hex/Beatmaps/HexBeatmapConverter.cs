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
        public int? CustomLaneCount = null;

        protected override IEnumerable<Type> ValidConversionTypes => new[] {typeof(IHasXPosition)};

        protected override Beatmap<HexHitObject> CreateBeatmap() => new HexBeatmap {LaneCount = CustomLaneCount};

        protected override IEnumerable<HexHitObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            float x = ((IHasXPosition)original).X;

            int laneCount = CustomLaneCount ?? beatmap.GetLaneCount();
            int lane = (int)(x / (512f + 1) * laneCount);

            Debug.Assert(lane >= 0);
            Debug.Assert(lane < laneCount);

            yield return new HexHitObject(lane, laneCount, original) {
                Samples = original.Samples,
                SampleControlPoint = original.SampleControlPoint
            };
        }
    }
}
