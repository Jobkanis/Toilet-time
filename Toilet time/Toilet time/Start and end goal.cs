using System;

namespace Toilet_time
{
    public class End_Goal : Stable_Object
    {
        public End_Goal(int x_pos, int y_pos, int x_size, int y_size)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), false)
        {}

        public override void Update(float dt, Gui_Manager guimanager)
        {
            
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawEnd(this);
        }
    }

    public class Spawn: Stable_Object
    {
        public Spawn(int x_pos, int y_pos, int x_size, int y_size)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), false)
        {

        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
           
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawSpawn(this);
        }
    }

}
