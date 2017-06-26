using System;

namespace Toilet_time
{
    /*
    public class Vector2
    {
        public float x_percent;
        public int x;
        public float y_percent;
        public int y;

        public Vector2(float x_percent, int x, float y_percent, int y)
        {
            this.x_percent = x_percent;
            this.x = x;
            this.y_percent = y_percent;
            this.y = y;
        }

    }
    */

    public class Position
    {
        public int x;
        public int y;
        public float y_per;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    public class Size
    {
        public int x;
        public int y;
        public Size(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}