using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Test.Objects;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;

namespace osu.Game.Rulesets.HoLLy.Test.Beatmaps
{
    internal class TestBeatmapConverter : BeatmapConverter<TestHitObject>
    {
        //TODO: does this mean both have to be satisfied, or just one?
        protected override IEnumerable<Type> ValidConversionTypes => new[] {typeof(IHasPosition)};

        protected override IEnumerable<TestHitObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            yield return new TestHitObject(((IHasPosition)original).Position, original);
        }
    }
}
