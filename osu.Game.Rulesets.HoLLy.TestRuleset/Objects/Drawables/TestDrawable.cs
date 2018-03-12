using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Scoring;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Test.Objects.Drawables
{
    internal class TestDrawable : DrawableHitObject<TestHitObject>
    {
        public TestDrawable(TestHitObject hitObject, TextureStore textureStore) : base(hitObject)
        {
            Size = new Vector2(64);
            Position = hitObject.Position;
            Origin = Anchor.Centre;
            Add(new Sprite {
                Texture = textureStore.Get("Circle"),
            });
        }

        protected override void Update()
        {
            base.Update();

            if (Time.Current >= HitObject.StartTime)
                UpdateJudgement(true);
        }

        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            if (userTriggered)
                AddJudgement(new Judgement {Result = HitResult.Great});
        }

        protected override void UpdateState(ArmedState state)
        {
            switch (state) {
                case ArmedState.Idle:
                    break;
                case ArmedState.Hit:
                case ArmedState.Miss:
                    this.FadeColour(Color4.Yellow, 100).Then().FadeOut(100).Expire();   //expire cleans up the drawable
                    break;
            }
        }
    }
}
