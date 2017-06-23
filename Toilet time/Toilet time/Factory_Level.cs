using System;

namespace Toilet_time
{
    public class Factory_Level
    {
        public Factory_Level()
        {

        }

        public Level Create_Level(int level_number)
        {
            Iterator<Fallable_Object> fallable_objects = new List<Fallable_Object>();
            Iterator<Stable_Object> stable_objects = new List<Stable_Object>();
            switch (level_number)
            {

                case 1:
                    {
                        //sceen size: 800 * 600
                        stable_objects.Add(new Platform(0, 300,     60, 50));
                        stable_objects.Add(new Platform(50, 50,     50, 50));
                        fallable_objects.Add(new Main_Character(50, 240));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return new Level(fallable_objects, stable_objects);
        }
    }
}