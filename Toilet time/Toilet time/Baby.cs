using System;

namespace Toilet_time
{ 
    public class Baby: Stable_Object
    {
        Boolean pickedup;

        public Baby(int x, int y, int x_size, int y_size, bool resizeable)
            : base(x, y, x_size, y_size, resizeable)
        {

        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawBaby(this);
        }

        public override void Update()
        {

        }
    }

}