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
        public int x;
        public int y;
        public int x_size;
        public int y_size;
        public bool resizeable;

        public iObject(int x, int y, int x_size, int y_size, bool resizeable)
        {
            this.x = x;
            this.y = y;
            this.x_size = x_size;
            this.y_size = y_size;
            this.resizeable = resizeable;
        }
        public abstract void Draw(DrawVisitor visitor);

        public abstract void Update();



    }

    public abstract class Fallable_Object : iObject
    {
        public Fallable_Object(int x, int y, int x_size, int y_size, bool resizeable)
            :base(x, y, x_size, y_size, resizeable)
        {

        }

        public void Fall()
        {

        }
    }

    public abstract class Stable_Object: iObject
    {
        public Stable_Object(int x, int y, int x_size, int y_size, bool resizeable)
            :base(x, y, x_size, y_size, resizeable)
        {

        }
    }
}