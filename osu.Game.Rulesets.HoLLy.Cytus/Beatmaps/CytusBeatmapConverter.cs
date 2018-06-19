using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects;
using osu.Game.Rulesets.Objects;

namespace osu.Game.Rulesets.HoLLy.Cytus.Beatmaps
{
    internal class CytusBeatmapConverter : BeatmapConverter<CytusHitObject>
    {
        protected override IEnumerable<Type> ValidConversionTypes => new Type[0];

        public CytusBeatmapConverter(IBeatmap beatmap) : base(beatmap) { }

        protected override IEnumerable<CytusHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap)
        {
            yield break;
        }
    }
}
