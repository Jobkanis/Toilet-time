using System;

namespace Toilet_time
{
    public class Main_Character: Fallable_Object
    {
        public Main_Character(int x_pos, int y_pos, int x_size, int y_size, bool resizeable)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), resizeable)
        {
        }

        public void Walk_Left()
        {

        }

        public void Walk_Right()
        {

        }

        public void Jump()
        {

        }

        public override void Update()
        {

        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawCharacter(this);
        }
    }
}