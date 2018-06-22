using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Objects;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Cytus.Beatmaps
{
    internal class CytusBeatmapConverter : BeatmapConverter<CytusHitObject>
    {
        protected override IEnumerable<Type> ValidConversionTypes => new[] {typeof(IHasXPosition)};

        public CytusBeatmapConverter(IBeatmap beatmap) : base(beatmap) { }

        protected override IEnumerable<CytusHitObject> ConvertHitObject(HitObject original, IBeatmap beatmap)
        {
            if (!(original is IHasXPosition))
                throw new Exception($"This hitobject of type {original.GetType().Name} is not a {nameof(IHasXPosition)}!");

            // For now, only use X position
            yield return new CytusNote(original.StartTime, ((IHasXPosition)original).X) { 
                Samples = original.Samples, 
                SampleControlPoint = original.SampleControlPoint 
            };
        }
    }
}
