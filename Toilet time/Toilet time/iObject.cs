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
        public abstract void Draw(DrawVisitor visitor);

        public abstract void Update();

        public int x;
        public int y;
        public int x_size;
        public int y_size;

    }

    public abstract class Fallable_Object : iObject
    {
        public void Fall()
        {

        }
    }

    public abstract class Stable_Object: iObject
    {
 
    }
}