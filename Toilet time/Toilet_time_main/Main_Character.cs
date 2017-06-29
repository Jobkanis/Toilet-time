using System;

namespace Toilet_time_main
{
    public class Main_Character: Fallable_Object
    {
        public Main_Character(int x_pos, int y_pos, int nextscreen)
            : base(new Position(x_pos, y_pos), new Size(20, 40), true)
        {
            this.jumpvelocity = 9;
            this.IsMainCharacter = true;
            this.MoveOnWalk = false;
            this.nextscreen = nextscreen;
        }

        public void Walk_Left()
        {

        }

        public void Walk_Right()
        {

        }

        public void PickUp()
        {
            
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawCharacter(this);
        }
    }
}