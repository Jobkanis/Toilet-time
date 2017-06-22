using System;

namespace paalvast
{
    class Factory_Level
    {
        public Factory_Level()
        {

        }

        public Level Draw_Level(int level_number)
        {
            return new Level();
        }
    }
}