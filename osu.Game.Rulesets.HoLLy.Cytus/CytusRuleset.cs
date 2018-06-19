using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Difficulty;
using osu.Game.Rulesets.HoLLy.Cytus.Beatmaps;
using osu.Game.Rulesets.HoLLy.Cytus.Difficulty;
using osu.Game.Rulesets.HoLLy.Cytus.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Cytus
{
    public class CytusRuleset : Ruleset
    {
        public override string Description => "Not Cytus";
        public override string ShortName => "holly.cytus";

        public CytusRuleset(RulesetInfo rulesetInfo = null) : base(rulesetInfo) { }

        public override IEnumerable<Mod> GetModsFor(ModType type) => new Mod[0];

        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap) => new CytusRulesetContainer(this, beatmap);

        public override IBeatmapConverter CreateBeatmapConverter(IBeatmap beatmap) => new CytusBeatmapConverter(beatmap);

        public override DifficultyCalculator CreateDifficultyCalculator(WorkingBeatmap beatmap) => new CytusDifficultyCalculator(this, beatmap);

        public override Drawable CreateIcon() => new SpriteIcon() { Icon = FontAwesome.fa_dot_circle_o };
    }
}
