using System;

namespace Toilet_time
{
    public class Main_Character: Fallable_Object
    {
        public Main_Character(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(20, 40), true)
        {
        }

        public void Walk_Left()
        {

        }

        public void Walk_Right()
        {

        }

        public void Jump(Gui_Manager guimanager)
        {
            if (this.velocity == 0 && (guimanager.Check_Collision(this, position.x, position.y - 1 , size.x, size.y)) == true)
            {
                this.velocity = 3;
            }
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
            Jump(guimanager);

        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawCharacter(this);
        }
    }
}