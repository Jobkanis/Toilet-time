using System;

namespace Toilet_time
{
    public class Platform : Stable_Object
    {
        public Platform(int x, int y, int x_size, int y_size)
            : base(x, y, y_size, x_size, true)
        {
            this.x = x;
            this.y = y;
            this.x_size = x_size;
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