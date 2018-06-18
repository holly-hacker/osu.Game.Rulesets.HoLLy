using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.HoLLy.Hex
{
    internal static class Utils
    {
        public static int GetLaneCount(float od) => MathHelper.Clamp((int)od, Constants.LanesMin, Constants.LanesMax);
        public static float GetHitobjectSize(int laneCount) => Constants.ColumnWidthBase / laneCount;

        public static Color4 GetAccentColor(int lane, int laneCount) => GetColorArray(laneCount)[lane % laneCount];

        public static Color4[] GetColorArray(int laneCount)
        {
            switch (laneCount)
            {
                case 3:
                    return new[] {
                        Color4.Red,  Color4.Green, Color4.Blue,
                    };
                case 4:
                    return new[] {
                        Color4.Red,  Color4.Yellow, Color4.Green, Color4.Blue, 
                    };
                case 5:
                    return new[] {
                        Color4.Red, Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Blue,
                    };
                case 6:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Blue, Color4.Indigo,
                    };
                case 7:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Blue, Color4.Indigo, Color4.Violet,
                    };
                case 8:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Olive,Color4.Blue,   Color4.Indigo, Color4.Violet,
                    };
                case 9:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Olive,Color4.Blue,   Color4.Indigo, Color4.Violet,
                        Color4.Tomato
                    };
                case 10:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Olive,Color4.Blue,   Color4.Indigo, Color4.Violet,
                        Color4.Tomato, Color4.OrangeRed
                    };
                default:
                    return new[] {
                        Color4.Red,  Color4.Orange, Color4.Yellow, Color4.Green,
                        Color4.Blue, Color4.Indigo, Color4.Violet,
                    };
            }
        }
    }
}
