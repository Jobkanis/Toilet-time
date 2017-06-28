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
        public Color inputcolorGamePad = new Color();
        public Color hovercolorGamePad = new Color();
        public DrawVisitor.BackgroundType Background;

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
                        if (gui_manager.inputmechanism == 3)
                        {
                            inputcolorGamePad = Color.Red;
                            hovercolorGamePad = Color.Red;
                            inputcolorWASD = Color.Black;
                            hovercolorWASD = Color.Black;
                            inputcolorArrows = Color.Black;
                            hovercolorArrows = Color.Black;
                        }

                        if (gui_manager.inputmechanism == 2)
                        {
                            inputcolorGamePad = Color.Black;
                            hovercolorGamePad = Color.Black;
                            inputcolorWASD = Color.Red;
                            hovercolorWASD = Color.Red;
                            inputcolorArrows = Color.Black;
                            hovercolorArrows = Color.Black;
                        }

                        if (gui_manager.inputmechanism == 1)
                        {
                            inputcolorGamePad = Color.Black;
                            hovercolorGamePad = Color.Black;
                            inputcolorWASD = Color.Black;
                            hovercolorWASD = Color.Black;
                            inputcolorArrows = Color.Red;
                            hovercolorArrows = Color.Red;
                        }
                        gui_stuff.Add(new Button(350, 200, 100, 50, "Wasd", inputcolorWASD, hovercolorWASD, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(2); guimanager.Create_screen(2); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Arrows", inputcolorArrows, hovercolorArrows, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(1); guimanager.Create_screen(2);}));

                        if (gui_manager.Gamepadonline == true)
                        {
                            gui_stuff.Add(new Button(350, 400, 100, 50, "GamePad", inputcolorGamePad, hovercolorGamePad, (Gui_Manager guimanager) => { guimanager.Getinputmechanism(3); guimanager.Create_screen(2); }));
                        }

                        break;
                    }
                case 3:
                    {
                        islevel = true;
                        
                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 4));

                        //interactions
                        Interacting_Objects.Add(new Baby(400, 0));
                        Interacting_Objects.Add(new End_Goal(600, 0));
                       

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 800, 20));

                        break;
                    }
                case 4:
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 5));

                        //interactions
                        Interacting_Objects.Add(new Baby(600, 0));
                        Interacting_Objects.Add(new End_Goal(1000, 0));
                        Interacting_Objects.Add(new Deadly_Brick(400, 0));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(800, -300, 1.5f));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 1200, 20));

                        break;
                    }


                case 5:
                    {
                        islevel = true;
                        
                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 6));
                        
                        //interactions
                        Interacting_Objects.Add(new Baby(690, 0));
                        Interacting_Objects.Add(new End_Goal(300, 0));
                        Interacting_Objects.Add(new Deadly_Brick(500, 0));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 400, 20));
                        stable_objects.Add(new Platform(400, 350, 300, 20));
                        stable_objects.Add(new Platform(680, 300, 50, 20));

                        break;
                    }
                case 6:
                    {
                        islevel = true;
                       
                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 1));

                        //interactions
                        Interacting_Objects.Add(new Baby(1505, 0));
                        Interacting_Objects.Add(new End_Goal(1000, 0));
                        Interacting_Objects.Add(new Deadly_Brick(800, 0));

                        Interacting_Objects.Add(new Toilet_Paper_Drop(300, -300, 1));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 300, 20));
                        stable_objects.Add(new Platform(350, 250, 250, 20));
                        stable_objects.Add(new Platform(800, 250, 300, 20));
                        stable_objects.Add(new Platform(1100, 200, 50, 20));
                        stable_objects.Add(new Platform(1300, 300, 50, 20));
                        stable_objects.Add(new Platform(1500, 400, 50, 20));

                        break;
                    }
                default:
                    {
                        islevel = false;
                        break;
                    }
            }

            if (islevel)
            {
                gui_stuff.Add(new Button(0, 0, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager) => { guimanager.Create_screen(1); }));
                Background = DrawVisitor.BackgroundType.ingamebackground;
            }
            else
            {
                Background = DrawVisitor.BackgroundType.menubackground;
            }

            return new Screen(Background, fallable_objects, stable_objects, gui_stuff, Interacting_Objects, islevel);
        }
    }
}