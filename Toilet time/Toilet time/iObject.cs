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

    public interface iObject : Drawable , Updateable
    {

    }

    public abstract class Fallable_Object : iObject
    {
        public abstract void Draw(DrawVisitor visitor);

        public abstract void Update();

        public void Fall()
        {

        }
    }

    public abstract class Stable_Object: iObject
    {
        public abstract void Draw(DrawVisitor visitor);

        public abstract void Update();
    }
}