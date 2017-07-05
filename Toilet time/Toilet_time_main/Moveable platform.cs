using System;

namespace Toilet_time_main
{
    public class Moveable_Platform : Stable_Object
    {
        int xstart;
        int region;
        int steps_out;
        bool returning;
        float new_x_add = 0;

        int speed;
        int x_addition;

        public Moveable_Platform(int x_pos, int y_pos, int x_size, int y_size, int region, int speed)
            : base(new Position(x_pos, y_pos), new Size(x_size, y_size), true)
        {
            this.region = region;
            this.speed = speed;
            xstart = x_pos;
            returning = false;
        }

        

        public override void Update(float dt, Gui_Manager guimanager)
        {

            if (returning)
            {
                if (steps_out > 0)
                {
                    new_x_add -= speed * dt;
                }
                else
                {
                    returning = false;
                }
            }
            else
            {
                if (steps_out < region)
                {
                    new_x_add += speed * dt;
                }
                else
                {
                    returning = true;
                }
            }

            x_addition = (int)(new_x_add);
            this.steps_out += x_addition;

            new_x_add = new_x_add - x_addition;
            Fallable_Object main = guimanager.GetMain_Character();

            if (!((this.position.x + x_addition + 2 < main.position.x + main.size.x && this.position.x + x_addition - 2 + this.size.x > main.position.x && this.position.y + this.size.y > main.position.y && this.position.y < main.position.y + main.size.y)))
            {

                this.position.x += x_addition;
            }
            else
            {
                this.returning = !this.returning;
            }

            if (!guimanager.Check_Collision(this, this.position.x + 1, this.position.y, this.size.x, this.size.y))
            {
                this.returning = true;
            }
            else if ((!guimanager.Check_Collision(this, this.position.x - 1, this.position.y, this.size.x, this.size.y)))
            {
                this.returning = false;
            }

        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawMoveablePlatform(this);
        }
    }
}