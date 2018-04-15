using System.Diagnostics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.Mods;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexMultiModLaneCount : MultiMod
    {
        /*
        //does not work because each mod needs its own type
        public HexMultiModLaneCount(int min, int max)
        {
            Debug.Assert(min >= Constants.LanesMin && min <= Constants.LanesMax);
            Debug.Assert(max >= Constants.LanesMin && max <= Constants.LanesMax);
            Debug.Assert(max >= min);

            Mods = Enumerable.Range(min, max - min + 1).Select(x => new HexModLaneCount(x)).Cast<Mod>().ToArray();
        }
        */

        public HexMultiModLaneCount()
        {

            Mods = new HexModLaneCount[] {
                new HexModLaneCount3(), 
                new HexModLaneCount4(), 
                new HexModLaneCount5(), 
                new HexModLaneCount6(), 
                new HexModLaneCount7(), 
                new HexModLaneCount8(), 
                new HexModLaneCount9(), 
                new HexModLaneCount10(), 
            };
        }

        private class HexModLaneCount3 : HexModLaneCount { public HexModLaneCount3() : base(3) { } }
        private class HexModLaneCount4 : HexModLaneCount { public HexModLaneCount4() : base(4) { } }
        private class HexModLaneCount5 : HexModLaneCount { public HexModLaneCount5() : base(5) { } }
        private class HexModLaneCount6 : HexModLaneCount { public HexModLaneCount6() : base(6) { } }
        private class HexModLaneCount7 : HexModLaneCount { public HexModLaneCount7() : base(7) { } }
        private class HexModLaneCount8 : HexModLaneCount { public HexModLaneCount8() : base(8) { } }
        private class HexModLaneCount9 : HexModLaneCount { public HexModLaneCount9() : base(9) { } }
        private class HexModLaneCount10: HexModLaneCount { public HexModLaneCount10(): base(10){ } }
    }

    internal abstract class HexModLaneCount : Mod, IApplicableToBeatmapConverter<HexHitObject>
    {
        private readonly int _lanes;
        public override string Name => $"{_lanes} Lanes";
        public override string ShortenedName => $"L{_lanes}";
        public override double ScoreMultiplier => 0;
        public override ModType Type => ModType.Special;
        public override string Description => $"Play with {_lanes} lanes!";
        public override bool Ranked => false;

        protected HexModLaneCount(int lanes)
        {
            Debug.Assert(lanes <= Constants.LanesMax);
            Debug.Assert(lanes >= Constants.LanesMin);

            _lanes = lanes;
        }

        public void ApplyToBeatmapConverter(BeatmapConverter<HexHitObject> beatmapConverter) => ((HexBeatmapConverter)beatmapConverter).CustomLaneCount = _lanes;
    }
}
