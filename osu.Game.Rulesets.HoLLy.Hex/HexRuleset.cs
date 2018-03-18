using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.HoLLy.Hex.Mods;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexRuleset : Ruleset
    {
        public ResourceStore<byte[]> ResourceStore;
        public TextureStore TextureStore;

        public override string Description => "osu!Hex";
        public override string ShortName => "holly.hex";

        public HexRuleset(RulesetInfo f = null) : base(f)
        {
            ResourceStore = new NamespacedResourceStore<byte[]>(new DllResourceStore("osu.Game.Rulesets.HoLLy.Hex.dll"), "Resources");
            TextureStore = new TextureStore(new RawTextureLoaderStore(new NamespacedResourceStore<byte[]>(ResourceStore, "Textures")));
        }

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type) {
                case ModType.DifficultyReduction:
                    return new Mod[] {
                        new HexModNoFail()
                    };
                case ModType.DifficultyIncrease:
                    return new Mod[0];
                case ModType.Special:
                    return new Mod[0];
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap, Mod[] mods = null) => new HexDifficultyCalculator();

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new HexRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override Drawable CreateIcon() => new SpriteIcon {Icon = FontAwesome.fa_futbol_o};
    }
}
