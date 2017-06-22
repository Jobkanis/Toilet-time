using System;

namespace Toilet_time
{
    public class End_Goal:Stable_Object
    {
        public End_Goal(int x, int y, int x_size, int y_size, bool resizeable)
            : base(x, y, x_size, y_size, resizeable)
        {

        }

        public override void Update()
        {
            
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawEnd(this);
        }
    }

    public class Spawn: Stable_Object
    {
        public Spawn(int x, int y, int x_size, int y_size)
            : base(x, y, x_size, y_size, false)
        {

        }

        public override void Update()
        {
           
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawSpawn(this);
        }
    }

}
