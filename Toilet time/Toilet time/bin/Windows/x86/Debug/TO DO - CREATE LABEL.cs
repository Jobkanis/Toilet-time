using System;

namespace Toilet_time
{
    public class Label : iObject
    {
        public string text;
        public Label(int x_pos, int y_pos, int x_size, int y_size, string text)
            :base(new Position(x_pos, y_pos), new Size(x_size,y_size), true)
        {
            this.text = text;

        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawLabel(this);
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            //throw new NotImplementedException();
        }
    }
}