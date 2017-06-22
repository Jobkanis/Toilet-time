using System;

namespace Toilet_time
{
    public class Platform : Stable_Object
    {
        public Platform(int x_pos, int y_pos, int x_size, int y_size)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), true)
        {
        }

        public override void Update()
        {
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawPlatform(this);
        }
    }
}