﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time
{
    public class Factory_screen
    {
        public Gui_Manager gui_manager;
        public Factory_screen(Gui_Manager gui_manager)
        {
            this.gui_manager = gui_manager;
        }

        public Screen Create_screen(int level_number)
        {
            Iterator<Fallable_Object> fallable_objects = new List<Fallable_Object>();
            Iterator<Stable_Object> stable_objects = new List<Stable_Object>();
            Iterator<iObject> gui_stuff = new List<iObject>();

            Iterator<iObject> Interacting_Objects = new List<iObject>();

            switch (level_number)
            {

                case 1:
                    {

                        gui_stuff.Add(new Button(350, 100, 100, 50, "play", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(3); } ));
                        gui_stuff.Add(new Button(350, 200, 100, 50, "Exit", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.game.Exit(); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Settings", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(2); }));
                        break;
                    }
                case 2:
                    {
                        gui_stuff.Add(new Button(350, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(1); }));
                        if (gui_manager.inputmechanism == 2)
                        {
                            //Color inputcolor = new
                        }
                        gui_stuff.Add(new Button(350, 200, 100, 50, "Wasd", Color.Black, Color.Gray, (Gui_Manager guimanager) =>
                        { guimanager.Getinputmechanism(1); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Arrows", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(1); }));
                        break;
                    }
                case 3:
                    {
                        //character
                        fallable_objects.Add(new Main_Character(200, 240));
                        Interacting_Objects.Add(new Baby(400, 0));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 500, 50));
                        stable_objects.Add(new Platform(300, 250, 300, 50));
                        stable_objects.Add(new Platform(800, 250, 300, 50));
                        stable_objects.Add(new Platform(1100, 200, 50, 50));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return new Screen(fallable_objects, stable_objects, gui_stuff, Interacting_Objects);
        }
    }
}