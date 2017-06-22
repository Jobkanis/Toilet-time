using System;

namespace Toilet_time
{
    enum TouchPositions
    {
        Up, Down, Left, Right
    }

    public class Collision
    {
        public Collision()
        {

        }

        TouchPositions Touch()
        {
            return new TouchPositions();
        }

        public iObject Object()
        {

            return new Main_Character();
        }

    }
}