using System;

namespace Toilet_time_main
{
    public class Deadly_Brick : Fallable_Object
    {
        public Deadly_Brick(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(70, 10), false)
        {
            this.IsDeadly = true;
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawDeadlyBrick(this);
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }
    }
}