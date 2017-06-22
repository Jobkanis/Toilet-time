using System;

namespace Toilet_time
{
    public interface Drawable
    {
        void Draw();
    }

    public interface Updateable
    {
        void Update();
    }

    public interface iObject : Drawable , Updateable
    {

    }

    abstract class Fallable_Object : iObject
    {
        public abstract void Draw();

        public abstract void Update();

        public void Fall()
        {

        }
    }

    abstract class Stable_Object: iObject
    {
        public abstract void Draw();

        public abstract void Update();
    }
}