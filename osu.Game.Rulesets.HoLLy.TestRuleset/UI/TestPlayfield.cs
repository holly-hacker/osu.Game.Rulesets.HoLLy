using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Logging;
using osu.Game.Beatmaps.ControlPoints;
using osu.Game.Graphics;
using osu.Game.Graphics.Containers;
using osu.Game.Rulesets.UI;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Test.UI
{
    internal class TestPlayfield : Playfield
    {
        public override Vector2 Size
        {
            get {
                const float ratio = 3f / 4f;

                if (Parent == null)
                    return Vector2.Zero;

                var parentSize = Parent.DrawSize;
                var aspectSize = parentSize.X * ratio < parentSize.Y ? new Vector2(parentSize.X, parentSize.X * ratio) : new Vector2(parentSize.Y / ratio, parentSize.Y);

                return new Vector2(aspectSize.X / parentSize.X, aspectSize.Y / parentSize.Y) * base.Size;
            }
        }

        public TestPlayfield() : base(512)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            AddRange(new Drawable[] {
                new MainContainer {
                    RelativeSizeAxes = Axes.Both,
                }
            });
        }

        public class MainContainer : BeatSyncedContainer
        {
            private OsuColour osuColour;

            [BackgroundDependencyLoader]
            private void load(OsuColour colour)
            {
                osuColour = colour;
            }
            protected override void OnNewBeat(int beatIndex, TimingControlPoint timingPoint, EffectControlPoint effectPoint, TrackAmplitudes amplitudes)
            {
                //Logger.Log("Test log, woo");
                this.FadeColour(beatIndex % 4 == 0 ? osuColour.Red : osuColour.GrayF, timingPoint.BeatLength/2);
            }
        }
    }
}
