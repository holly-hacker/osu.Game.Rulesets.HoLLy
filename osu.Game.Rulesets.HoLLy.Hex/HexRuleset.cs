using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal class HexRuleset : Ruleset
    {
        public override string Description => "osu!Hex";
        public override string ShortName => "holly.hex";

        public HexRuleset(RulesetInfo f = null) : base(f) { }

        public override IEnumerable<Mod> GetModsFor(ModType type) { yield break; }

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap, Mod[] mods = null) => new HexDifficultyCalculator();

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new HexRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override Drawable CreateIcon() => new SpriteIcon {Icon = FontAwesome.fa_futbol_o};
    }
}
