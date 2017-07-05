using System;
namespace Toilet_time_main
{
    public class Spike_Dropper : Stable_Object
    {
        List<Spike> droppingobjects = new List<Spike>();
        float cooldown = 0f;
        float interval;

        public Spike_Dropper(int x_pos, int y_pos, float interval)
            : base(new Position(x_pos, y_pos), new Size(50, 50), false)
        {
            this.Visible = false;
            this.interval = interval;
        }

        public override void Draw(iDrawVisitor visitor)
        {

            droppingobjects.Reset();
            while (droppingobjects.GetNext().Visit<bool>(() => false, _ => true))
            {
                Spike droppingobject = droppingobjects.GetCurrent().Visit<Spike>(() => throw new Exception("spike error"), item => item);
                droppingobject.Draw(visitor);
            }
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            if (cooldown > 0) { cooldown = cooldown - (1 * dt); }
            else { cooldown = 0; }

            if (cooldown <= 0)
            {
                Spike spike_to_add = new Spike(position.x, position.y);
                spike_to_add.velocity = -3;
                droppingobjects.Add(spike_to_add);
                cooldown = interval;
            }

            droppingobjects.Reset();
            while (droppingobjects.GetNext().Visit<bool>(() => false, _ => true))
            {
                Spike droppingobject = droppingobjects.GetCurrent().Visit<Spike>(() => throw new Exception("spike error"), item => item);
                droppingobject.position.x = this.position.x;

                droppingobject.Update(dt, guimanager);

                Fallable_Object main = guimanager.GetMain_Character();
                if (main != null)
                {
                    if (main.position.x < droppingobject.position.x + droppingobject.size.x && main.position.x + main.size.x > droppingobject.position.x)
                    {
                        if (main.position.y + main.size.y > droppingobject.position.y && main.position.y < droppingobject.position.y + droppingobject.size.y)
                        {

                            guimanager.Main_Dead();

                        }
                    }
                }

                if (droppingobject.position.y > 2000)
                {

                    List<Spike> COPYdroppingobjects = droppingobjects;

                    List<Spike> Newdroppingobjects = new List<Spike>();
                    {

                        COPYdroppingobjects.Reset();
                        while (COPYdroppingobjects.GetNext().Visit<bool>(() => false, _ => true))
                        {
                            Spike dropob = COPYdroppingobjects.GetCurrent().Visit<Spike>(() => throw new Exception("copyfail"), item => item);

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

    public class Spike : Fallable_Object
    {
        public Spike(int x_pos, int y_pos)
            : base(new Position(x_pos, y_pos), new Size(20, 40), false)
        {
            this.Collides = false;
            this.IsDeadly = true;
            this.MoveOnWalk = true;
        }

        public override void Draw(iDrawVisitor visitor)
        {
            visitor.DrawSpikes(this);
        }

        public override void Update(float dt, Gui_Manager guimanager)
        {
            base.Update(dt, guimanager);
        }
    }
}