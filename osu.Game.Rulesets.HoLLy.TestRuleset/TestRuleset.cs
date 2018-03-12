using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.HoLLy.Test.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Test
{
    public class TestRuleset : Ruleset
    {
        public ResourceStore<byte[]> ResourceStore;
        public TextureStore TextureStore;

        public override string ShortName => "hollytest";
        public override string Description => "TestRuleset";

        public TestRuleset(RulesetInfo r) : base(r)
        {
            ResourceStore = new NamespacedResourceStore<byte[]>(new DllResourceStore("osu.Game.Rulesets.HoLLy.Test.dll"), "Resources");
            TextureStore = new TextureStore(new RawTextureLoaderStore(new NamespacedResourceStore<byte[]>(ResourceStore, "Textures")));
        }

        public override IEnumerable<Mod> GetModsFor(ModType type) { yield break; }

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new TestRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap, Mod[] mods = null) => new TestDifficultyCalculator();
        
        public override Drawable CreateIcon() => new SpriteIcon {Icon = FontAwesome.fa_taxi};
    }
}
