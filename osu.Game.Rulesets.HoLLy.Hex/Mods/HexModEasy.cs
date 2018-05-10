using System;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.HoLLy.Hex.Objects;
using osu.Game.Rulesets.HoLLy.Hex.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.HoLLy.Hex.Mods
{
    internal class HexModEasy : Mod, IApplicableToDifficulty, IApplicableToRulesetContainer<HexHitObject>
    {
        public override string Name => "Easy";
        public override string ShortenedName => "EZ";
        public override FontAwesome Icon => FontAwesome.fa_osu_mod_easy;
        public override ModType Type => ModType.DifficultyReduction;
        public override double ScoreMultiplier => 0.5;
        public override bool Ranked => true;
        public override Type[] IncompatibleMods => new[] { typeof(HexModHardRock) };
        /*
         * Changes:
         * - general easy making (AR, OD)
         * - have one big polygon instead of multiple small ones
         */

        public override bool HasImplementation => false;

        public void ApplyToDifficulty(BeatmapDifficulty difficulty)
        {
            const float ratio = 0.5f;
            difficulty.CircleSize *= ratio;
            difficulty.ApproachRate *= ratio;
            difficulty.DrainRate *= ratio;

            // OD defines the lane-count, so don't change it as much
            difficulty.OverallDifficulty *= 0.75f;
        }

        public void ApplyToRulesetContainer(RulesetContainer<HexHitObject> rulesetContainer)
        {
            if (rulesetContainer is HexRulesetContainer rc) {
                rc.BiggerBase = true;
            }
        }
    }
}
