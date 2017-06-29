using System;

namespace Toilet_time_main
{
    public class End_Goal : Fallable_Object
    {
        public End_Goal(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(50, 50), false)
        {
            this.IsEnd = true;
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawEnd(this);
        }
    }

    public class Spawn: Fallable_Object
    {
        public Spawn(int x_pos, int y_pos, int x_size, int y_size)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), false)
        {

        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
           
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawSpawn(this);
        }
    }

}
