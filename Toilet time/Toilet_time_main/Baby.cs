using System;

namespace Toilet_time_main
{ 
    public class Baby: Fallable_Object
     {   
        public Baby(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(20, 20), false)
        {
            this.IsBaby = true;
            this.MoveOnWalk = true;
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawBaby(this);
        }


        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }

    }

}