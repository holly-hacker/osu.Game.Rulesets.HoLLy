using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.HoLLy.Hex.Beatmaps;
using osu.Game.Rulesets.HoLLy.Hex.Mods;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    public class HexRuleset : Ruleset
    {
        public ResourceStore<byte[]> ResourceStore;
        public TextureStore TextureStore;

        public override string Description => "Polygon";
        public override string ShortName => "holly.hex";

        public HexRuleset(RulesetInfo f = null) : base(f)
        {
            ResourceStore = new NamespacedResourceStore<byte[]>(new DllResourceStore("osu.Game.Rulesets.HoLLy.Polygon.dll"), "Resources");
            TextureStore = new TextureStore(new RawTextureLoaderStore(new NamespacedResourceStore<byte[]>(ResourceStore, "Textures")));
        }

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type) {
                case ModType.DifficultyReduction:
                    return new Mod[] {
                        new HexModEasy(),
                        new HexModNoFail(),
                        new MultiMod(new HexModHalfTime(), new HexModDaycore())
                    };
                case ModType.DifficultyIncrease:
                    return new Mod[] {
                        new HexModHardRock(),
                        new HexModPerfect(),
                        new MultiMod(new HexModDoubleTime(), new HexModNightcore()),
                        new MultiMod(new HexModHidden(), new HexModFadeIn()),
                    };
                case ModType.Special:
                    return new Mod[] {
                        new HexMultiModLaneCount(),
                        new HexModRelax(),
                        new HexModMaiMai(),
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) => new HexDifficultyCalculator(this, beatmap);

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap) => new HexRulesetContainer(this, beatmap);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new HexBeatmapConverter(beatmap);

        public override Drawable CreateIcon() => new SpriteIcon {Icon = FontAwesome.fa_futbol_o};
    }
}
