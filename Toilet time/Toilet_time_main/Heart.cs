using System;

namespace Toilet_time_main
{
    public class Heart : iObject
    {
        public string text;
        public Heart(int x_pos, int y_pos)
            :base(new Position(x_pos, y_pos), new Size(30, 30), true)
        {

        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawHeart(this);
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
        }
    }
}