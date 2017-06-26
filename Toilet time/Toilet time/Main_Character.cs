using System;

namespace Toilet_time
{
    public class Main_Character: Fallable_Object
    {
        public Main_Character(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(20, 40), true)
        {
            this.jumpvelocity = 7;
            this.IsMainCharacter = true;
            this.MoveOnWalk = false;
        }

        public void Walk_Left()
        {

        }

        public void Walk_Right()
        {

        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawCharacter(this);
        }
    }
}