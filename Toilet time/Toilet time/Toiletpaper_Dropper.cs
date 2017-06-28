using System;
namespace Toilet_time
{
    public class Toilet_Paper_Drop : Stable_Object
    {
        List<Toilet_Paper> droppingobjects = new List<Toilet_Paper>();
        float cooldown = 0f;
        float interval;

        public Toilet_Paper_Drop(int x_pos, int y_pos, float interval)
            : base(new Position(x_pos, y_pos), new Size(50, 50), false)
        {
            this.Visible = false;
            this.interval = interval;
        }

        public override void Draw(DrawVisitor visitor)
        {

            droppingobjects.Reset();
            while (droppingobjects.GetNext().Visit<bool>(() => false, _ => true))
            {
                Toilet_Paper droppingobject = droppingobjects.GetCurrent().Visit<Toilet_Paper>(() => throw new Exception("toiletpaper error"), item => item);
                droppingobject.Draw(visitor);
            }
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            if (cooldown > 0) {cooldown = cooldown - (1 * dt);}
            else { cooldown = 0;  }

            if (cooldown <= 0)
            {
                droppingobjects.Add(new Toilet_Paper(position.x, position.y));
                cooldown = interval;
            }

            droppingobjects.Reset();
            while (droppingobjects.GetNext().Visit<bool>(() => false, _ => true))
            {
                Toilet_Paper droppingobject = droppingobjects.GetCurrent().Visit<Toilet_Paper>(() => throw new Exception("toiletpaper error"), item => item);
                droppingobject.position.x = this.position.x;

                droppingobject.Update(dt, guimanager);

                Fallable_Object main = guimanager.GetMain_Character();
                if (main.position.x < droppingobject.position.x + droppingobject.size.x && main.position.x + main.size.x > droppingobject.position.x)
                {
                    if (main.position.y + main.size.y > droppingobject.position.y && main.position.y < droppingobject.position.y + droppingobject.size.y)
                    {
                        //touches main
                        guimanager.Main_Dead();
                    }
                }

                if (droppingobject.position.y > 500)
                {

                    List<Toilet_Paper> COPYdroppingobjects = droppingobjects;

                    List<Toilet_Paper> Newdroppingobjects = new List<Toilet_Paper>();
                    {

                        COPYdroppingobjects.Reset();
                        while (COPYdroppingobjects.GetNext().Visit<bool>(() => false, _ => true))
                        {
                            Toilet_Paper dropob = COPYdroppingobjects.GetCurrent().Visit<Toilet_Paper>(() => throw new Exception("copyfail"), item => item );

                            if (dropob.position.y != droppingobject.position.y)
                            {
                                Newdroppingobjects.Add(dropob);
                            }
                        }
                    }

                    droppingobjects = Newdroppingobjects;
                }
            }
        }
    }

    public class Toilet_Paper : Fallable_Object
    {
        public Toilet_Paper(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(28, 24), false)
        {
            this.Collides = false;
            this.IsDeadly = true;
            this.MoveOnWalk = true;
        }

        public override void Draw(DrawVisitor visitor)
        {
            visitor.DrawToiletPaper(this);
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }
    }
}