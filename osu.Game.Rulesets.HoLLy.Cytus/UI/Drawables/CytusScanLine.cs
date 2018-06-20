using System;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics.Containers;

namespace osu.Game.Rulesets.HoLLy.Cytus.UI.Drawables
{
    internal class CytusScanLine : BeatSyncedContainer
    {
        private readonly int _beatsPerScan;
        private int _beatIndex = -1;

        public CytusScanLine(int beatsPerScan)
        {
            _beatsPerScan = beatsPerScan;
            RelativeSizeAxes = Axes.X;      // Be 100% wide
            RelativePositionAxes = Axes.Y;  // Allow setting Y pos by %
            Anchor = Anchor.CentreLeft;     // Attached to parent at left center
            Origin = Anchor.CentreLeft;     // Left center is 0,0
            
            Height = 5;
            Width = 1f;

            Child = new Box {
                Width = 1f,
                Height = 1f,
                RelativeSizeAxes = Axes.Both,
            };
        }

        protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, TrackAmplitudes amplitudes)
        {
            _beatIndex = beatIndex;
        }

        protected override void Update()
        {
            base.Update();

            int scanNumber = _beatIndex / _beatsPerScan;    // Which scan this is, taking _beatCount into account
            int beatsPassed = _beatIndex % _beatsPerScan;   // How many beats have passed this scan
            bool reverse = Math.Abs(scanNumber) % 2 == 1;   // Does this scan go up instead of down?

            float beatPercent = (float)(TimeSinceLastBeat / (TimeSinceLastBeat + TimeUntilNextBeat));   // How far are we into this beat


            float percent = (beatsPassed + beatPercent) / _beatsPerScan;

            Y = reverse ? 1f - percent : percent;
        }
    }
}
