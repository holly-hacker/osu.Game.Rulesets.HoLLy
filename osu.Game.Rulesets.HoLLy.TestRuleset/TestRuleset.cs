using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.HoLLy.Test.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Test
{
    public class TestRuleset : Ruleset
    {
        public override string ShortName => "Test";
        public override string Description => "A dummy ruleset";

        public TestRuleset(RulesetInfo r) : base (r) { }

        public override IEnumerable<Mod> GetModsFor(ModType type) { yield break; }

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new TestRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap, Mod[] mods = null) => new TestDifficultyCalculator();
        
        //public override Drawable CreateIcon() => new SpriteIcon {Icon = FontAwesome.fa_question};
    }
}
