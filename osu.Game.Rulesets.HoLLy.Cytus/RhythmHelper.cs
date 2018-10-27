using System;
using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.HoLLy.Cytus
{
    internal static class RhythmHelper
    {
        public static float GetScanPosition(this IBeatmap bm, double time, int beatsPerScan)
        {
            var tp = bm.ControlPointInfo.TimingPointAt(time);

            var timeSinceTp = time - tp.Time;
            var beatPercent = timeSinceTp % tp.BeatLength / tp.BeatLength;
            double beatIndex = Math.Round((timeSinceTp - timeSinceTp % tp.BeatLength) / tp.BeatLength);    // Could be x.99999... due to floats, so round

            return GetScanPosition((int)beatIndex, beatsPerScan, (float)beatPercent);
        }

        public static float GetScanPosition(int beatIndex, int beatsPerScan, float beatPercent)
        {
            if (beatIndex < 0) {
                beatIndex = Math.Abs(beatIndex) - 1;
                beatPercent = 1f - beatPercent;
            }

            // TODO: float beatIndex, making reverse = Math.Float(...) % ...
            int scanNumber = beatIndex / beatsPerScan;      // Which scan this is
            int beatsPassed = beatIndex % beatsPerScan;     // How many beats have passed this scan
            bool reverse = scanNumber % 2 == 1;   // Does this scan go up instead of down?

            float percent = (beatsPassed + beatPercent) / beatsPerScan;

            return !reverse ? percent : 1f - percent;
        }
    }
}
