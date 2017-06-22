using System;

namespace Toilet_time
{ 
    public class Baby: Stable_Object
    {
        Boolean pickedup;

        public Baby(int x_pos, int y_pos, int x_size, int y_size, bool resizeable)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), resizeable)
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