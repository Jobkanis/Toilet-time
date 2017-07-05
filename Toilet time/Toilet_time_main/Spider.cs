using System;
namespace Toilet_time_main
{
    public class Spider : Fallable_Object
    {
        int xstart;
        int steps_out;
        bool left;
        float new_x_add = 0;

        int speed;
        int x_addition;

        Position startposition;

        public Spider(int x_pos, int y_pos, bool left, int speed)
            : base(new Position(x_pos, y_pos), new Size(20, 35), true)
        {
            this.left = left;
            this.speed = speed;
            xstart = x_pos;
            left = false;
            this.startposition = new Position(x_pos, y_pos);
        }



        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);

            if (left)
            {
                new_x_add -= speed * dt;
            }
            else
            {
                new_x_add += speed * dt;
            }

            x_addition = (int)(new_x_add);
            this.steps_out += x_addition;

            new_x_add = new_x_add - x_addition;

            if (left == false && !guimanager.Check_Collision(this, this.position.x + x_addition + 2, this.position.y, this.size.x, this.size.y))
            {
                this.left = true;
            }
            else if (left == true && (!guimanager.Check_Collision(this, this.position.x - x_addition - 2, this.position.y, this.size.x, this.size.y)))
            {
                this.left = false;
            }
            else
            {

                Fallable_Object main = guimanager.GetMain_Character();

                if (!((this.position.x + x_addition + 2 < main.position.x + main.size.x && this.position.x + x_addition - 2 + this.size.x > main.position.x && this.position.y + this.size.y > main.position.y && this.position.y < main.position.y + main.size.y)))
                {
                    this.position.x += x_addition;
                }
                else
                {
                    guimanager.Main_Dead();
                }
            }

            if (this.position.y > 600)
            {
                Console.WriteLine("respawning");
                this.position.y = startposition.y;
                this.position.x = this.startposition.x - guimanager.movementchange;
            }

        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawSpider(this);
        }
    }
}