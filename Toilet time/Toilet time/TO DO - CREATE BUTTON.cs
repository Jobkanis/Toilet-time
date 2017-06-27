using System;

namespace Toilet_time
{
    public class Button : iObject
    {
        public Label label;

        Action action;
        public Button(int x_pos, int y_pos, int x_size, int y_size, string text, Action action)
            :base(new Position(x_pos, y_pos), new Size(x_size,y_size), true)
        {
            this.action = action;
            this.label = new Label(x_pos, y_pos, x_size, y_size, text);
        }
        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawRectale(this);
            visitor.DrawLabel(label);
        }

        private bool isIntersecting(Point point)
        {
            return point.x > this.position.x && point.y > this.position.y&&
           point.x < this.position.x + this.size.x && point.y < this.position.y + this.size.y;

        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            if (guimanager.LatestInput != null)
            {
                if (isIntersecting(guimanager.Cursor))
                {
                    if (guimanager.LatestInput.MouseButton.Visit<bool>(() => false, _ => true))
                    {
                        if (guimanager.LatestInput.MouseButton.Visit<MousePressed>(() => { throw new Exception("mousepressed failed"); }, item => { return item; }) == MousePressed.Left_Button)
                        {
                            action();
                        }
                    }
                }
            }
        }
    }
}