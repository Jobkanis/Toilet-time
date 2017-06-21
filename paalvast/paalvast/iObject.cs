using System;

namespace paalvast
{
    interface Drawable
    {
        void Draw();
    }

    interface Updateable
    {
        void Update();
    }

    interface iObject : Drawable , Updateable
    {

    }
}