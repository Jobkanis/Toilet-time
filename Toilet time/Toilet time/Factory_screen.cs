using System;

namespace Toilet_time
{
    public class Factory_screen
    {
        public Factory_screen()
        {

        }

        public Screen Create_screen(int level_number)
        {
            Iterator<Fallable_Object> fallable_objects = new List<Fallable_Object>();
            Iterator<Stable_Object> stable_objects = new List<Stable_Object>();
            Iterator<iObject> gui_stuff = new List<iObject>();

            switch (level_number)
            {

                case 1:
                    {
                        //sceen size: 800 * 600

                        //character
                        fallable_objects.Add(new Main_Character(200, 240));

                        //platforms
                        stable_objects.Add(new Platform(0, 300,     500, 50));
                        stable_objects.Add(new Platform(300, 250,     300, 50));

                        //gui_stuff 
                        stable_objects.Add(new Platform(800, 250, 300, 50));
                        stable_objects.Add(new Platform(1100, 200, 50, 50));


                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return new Screen(fallable_objects, stable_objects, gui_stuff);
        }
    }
}