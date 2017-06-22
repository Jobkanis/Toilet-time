using System;

namespace Toilet_time
{
    public class Platform : Stable_Object
    {
        public Platform()
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