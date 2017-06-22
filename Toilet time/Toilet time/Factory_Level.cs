using System;

namespace Toilet_time
{
    public class Factory_Level
    {
        public Factory_Level()
        {

        }

        public Level Draw_Level(int level_number)
        {
            switch (level_number)
            {
                case 1:
                    {
                        return new Level();
                    }
                default:
                    {
                        return new Level();
                    }
            }
        }
    }
}