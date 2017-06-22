using System;

namespace Toilet_time
{ 
    public class Baby: Stable_Object
    {

        Boolean pickedup;

        public Baby()
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