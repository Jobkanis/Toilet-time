using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time
{
    public class Factory_screen
    {
        public Gui_Manager gui_manager;
        public Color inputcolorWASD= new Color();
        public Color inputcolorArrows = new Color();
        public Color hovercolorWASD = new Color();
        public Color hovercolorArrows = new Color();
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
            bool islevel;

            switch (level_number)
            {

                case 1:
                    {
                        islevel = false;
                        gui_stuff.Add(new Button(350, 100, 100, 50, "Play", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(3); } ));
                        gui_stuff.Add(new Button(350, 200, 100, 50, "Settings", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(2); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Exit", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.game.Exit(); }));
                        break;
                    }
                case 2:
                    {
                        islevel = false;
                        gui_stuff.Add(new Button(350, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(1); }));
                        if (gui_manager.inputmechanism == 2)
                        {
                            
                            inputcolorWASD = Color.Red;
                            hovercolorWASD = Color.Red;
                            inputcolorArrows = Color.Black;
                            hovercolorArrows = Color.Black;
                        }

                        if (gui_manager.inputmechanism == 1)
                        {
                            inputcolorWASD = Color.Black;
                            hovercolorWASD = Color.Black;
                            inputcolorArrows = Color.Red;
                            hovercolorArrows = Color.Red;
                        }
                        gui_stuff.Add(new Button(350, 200, 100, 50, "Wasd", inputcolorWASD, hovercolorWASD, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(2); guimanager.Create_screen(2); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Arrows", inputcolorArrows, hovercolorArrows, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(1); guimanager.Create_screen(2);}));
                        break;
                    }
                case 3:
                    {
                        islevel = true;
                        gui_stuff.Add(new Button(0, 0, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(1); }));
                        
                        //character
                        fallable_objects.Add(new Main_Character(200, 240, 1));

                        //interactions
                        Interacting_Objects.Add(new Baby(1505, 0));
                        Interacting_Objects.Add(new End_Goal(1000, 0));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 500, 50));
                        stable_objects.Add(new Platform(300, 250, 300, 50));
                        stable_objects.Add(new Platform(800, 250, 300, 50));
                        stable_objects.Add(new Platform(1100, 200, 50, 50));
                        stable_objects.Add(new Platform(1300, 300, 50, 50));
                        stable_objects.Add(new Platform(1500, 400, 50, 50));

                        break;
                    }
                default:
                    {
                        islevel = false;
                        break;
                    }
            }
            return new Screen(fallable_objects, stable_objects, gui_stuff, Interacting_Objects, islevel);
        }
    }
}