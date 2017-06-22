using System;

namespace Toilet_time
{
    public interface Drawable
    {
        void Draw(DrawVisitor visitor);
    }

    public interface Updateable
    {
        void Update();
    }

    public abstract class iObject : Drawable, Updateable
    {
        public Size size;
        public Position position;
        public bool resizeable;

        public iObject(Position position, Size size, bool resizeable)
        {
            this.size = size;
            this.position = position;
            this.resizeable = resizeable;
        }

        public abstract void Draw(DrawVisitor visitor);

        public abstract void Update();



    }

    public abstract class Fallable_Object : iObject
    {
        public Fallable_Object(Position position, Size size, bool resizeable)
            :base(position, size, resizeable)
        {

        }

        public int velocity;
        public Collision collision;

        public void Update_Gravity(Gui_Manager guimanager)
        {
            this.collision = guimanager.Check_Collision(this);

            bool downblocked = false;
            bool upblocked = false;

            if (collision.DownObject.Visit<bool>(() => false, _ => true))
            {
                downblocked = true;
            }

            if (collision.DownObject.Visit<bool>(() => false, _ => true))
            {
                upblocked = true;
            }

            // handling gravity
            if ((downblocked == false && velocity <= 0 ) || (upblocked == false && velocity > 0))
            {
                velocity--;
                this.position.y = this.position.y - velocity;
            }
            else
            {
                velocity = 0;
            }
        }
    }

    public abstract class Stable_Object: iObject
    {
        public Stable_Object(Position position, Size size, bool resizeable)
            :base(position, size, resizeable)
        {

        }
    }
}