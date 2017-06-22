using System;

namespace Toilet_time
{
    enum TouchPositions
    {
        Up, Down, Left, Right
    }

    class Collision
    {
        public Collision()
        {

        }

        public TouchPositions Touch()
        {
            return new TouchPositions();
        }

        public iObject Object()
        {

            return new Main_Character();
        }

    }
}