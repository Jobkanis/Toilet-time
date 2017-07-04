using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toilet_time_main
{
    public class Factory_screen
    {
        public Gui_Manager gui_manager;
        public Color inputcolorWASD = new Color();
        public Color inputcolorArrows = new Color();
        public Color hovercolorWASD = new Color();
        public Color hovercolorArrows = new Color();
        public Color inputcolorGamePad = new Color();
        public Color hovercolorGamePad = new Color();
        public BackgroundType Background;

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
                //main menu
                    {
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            gui_stuff.Add(new Button(350, 100, 100, 50, "Play", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(5); }));
                            gui_stuff.Add(new Button(350, 200, 100, 50, "Settings", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(2); }));
                            gui_stuff.Add(new Button(350, 300, 100, 50, "Exit", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.exit = true; }));
                        }
                        else if (gui_manager.systemtype == Systemtype.android)
                        {
                            gui_stuff.Add(new Button(400, 200, 100, 50, "Play", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(4); }));
                            gui_stuff.Add(new Button(400, 300, 100, 50, "Exit", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.exit = true; }));
                        }
                        break;
                    }

                case 2:
                //settings menu
                    {
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            gui_stuff.Add(new Button(350, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(1); }));
                        }

                        gui_stuff.Add(new Button(350, 200, 100, 50, "Controls", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(3); }));
                        gui_stuff.Add(new Button(350, 300, 100, 50, "Sounds", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(4); }));

                        break;
                    }

                case 3:
                //control settings
                    {
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            gui_stuff.Add(new Button(350, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(2); }));
                            if (gui_manager.inputmechanism == 3)
                            {
                                inputcolorGamePad = Color.Red;
                                hovercolorGamePad = Color.Gray;
                                inputcolorWASD = Color.Black;
                                hovercolorWASD = Color.IndianRed;
                                inputcolorArrows = Color.Black;
                                hovercolorArrows = Color.IndianRed;
                            }

                            if (gui_manager.inputmechanism == 2)
                            {
                                inputcolorGamePad = Color.Black;
                                hovercolorGamePad = Color.IndianRed;
                                inputcolorWASD = Color.Red;
                                hovercolorWASD = Color.Gray;
                                inputcolorArrows = Color.Black;
                                hovercolorArrows = Color.IndianRed;
                            }

                            if (gui_manager.inputmechanism == 1)
                            {
                                inputcolorGamePad = Color.Black;
                                hovercolorGamePad = Color.IndianRed;
                                inputcolorWASD = Color.Black;
                                hovercolorWASD = Color.IndianRed;
                                inputcolorArrows = Color.Red;
                                hovercolorArrows = Color.Gray;
                            }
                            gui_stuff.Add(new Button(350, 200, 100, 50, "Arrows", inputcolorArrows, hovercolorArrows, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(1); guimanager.Create_screen(3); }));
                            gui_stuff.Add(new Button(350, 300, 100, 50, "Wasd", inputcolorWASD, hovercolorWASD, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(2); guimanager.Create_screen(3); }));

                            if (gui_manager.Gamepadonline == true)
                            {
                                gui_stuff.Add(new Button(350, 400, 100, 50, "GamePad", inputcolorGamePad, hovercolorGamePad, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(3); guimanager.Create_screen(3); }));
                            }
                        }
                        break;
                    }

                case 4:
                //sound settings
                    {
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                            gui_stuff.Add(new Button(350, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(2); }));
                        {
                            Color MCMO, MC, SCMO, SC; String soundtext, musictext;
                            if (gui_manager.sound_handler.togglebackground) { MC = Color.Black; MCMO = Color.IndianRed; musictext = "Music: on"; } else { MC = Color.Red; MCMO = Color.Gray; musictext = "Music: off"; }
                            if (gui_manager.sound_handler.togglesoundeffect) { SC = Color.Black; SCMO = Color.IndianRed; soundtext = "Sounds: on"; } else { SC = Color.Red; SCMO = Color.Gray; soundtext = "Sounds: off"; }
                            gui_stuff.Add(new Button(350, 200, 100, 50, musictext, MC, MCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.ToggleBackground(!guimanager.sound_handler.togglebackground); if (guimanager.sound_handler.togglebackground) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Music: on"; } else { button.regularcolor = Color.Red; button.mouseovercolor = Color.Gray; button.label.text = "Music: off"; } }));
                            gui_stuff.Add(new Button(350, 300, 100, 50, soundtext, SC, SCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.Togglesoundeffect(!guimanager.sound_handler.togglesoundeffect); if (guimanager.sound_handler.togglesoundeffect) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Sounds: on"; } else { button.regularcolor = Color.Red; button.mouseovercolor = Color.Gray; button.label.text = "Sounds: off"; } }));
                        }
                        break;
                    }

                case 5:
                //level 1
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 6));

                        //interactions
                        Interacting_Objects.Add(new Baby(400, 0));
                        Interacting_Objects.Add(new End_Goal(600, 0));


                        //platforms
                        stable_objects.Add(new Platform(0, 300, 800, 20));

                        break;
                    }

                case 6:
                //level 2
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 7));

                        //interactions
                        Interacting_Objects.Add(new Baby(600, 0));
                        Interacting_Objects.Add(new End_Goal(1000, 0));
                        Interacting_Objects.Add(new Deadly_Brick(400, 0));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(800, -300, 1.5f));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 1200, 20));

                        break;
                    }

                case 7:
                //level 3
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 8));

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

                case 8:
                //level 4
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 1));

                        //interactions
                        Interacting_Objects.Add(new Baby(1505, 0));
                        Interacting_Objects.Add(new End_Goal(1000, 0));
                        Interacting_Objects.Add(new Deadly_Brick(800, 0));

                        Interacting_Objects.Add(new Toilet_Paper_Drop(300, -300, 0.8f));

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
                gui_stuff.Add(new Button(0, 0, 50, 20, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(1); }));

                //sound settings in game
                Color MCMO, MC, SCMO, SC;
                if (gui_manager.sound_handler.togglebackground) { MC = Color.Black; MCMO = Color.IndianRed; } else { MC = Color.DarkRed; MCMO = Color.Black; }
                if (gui_manager.sound_handler.togglesoundeffect) { SC = Color.Black; SCMO = Color.IndianRed; } else { SC = Color.DarkRed; SCMO = Color.Black; }
                gui_stuff.Add(new Button(50, 0, 50, 20, "Music", MC, MCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.ToggleBackground(!guimanager.sound_handler.togglebackground); if (guimanager.sound_handler.togglebackground) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; } }));
                gui_stuff.Add(new Button(100, 0, 50, 20, "Sound", SC, SCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.Togglesoundeffect(!guimanager.sound_handler.togglesoundeffect); if (guimanager.sound_handler.togglesoundeffect) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; } }));

                //pausebutton in game
                Color pause, pausehover; String pausetext;
                if (gui_manager.sound_handler.togglebackground) { pause = Color.Black; pausehover = Color.IndianRed; pausetext = "Pause"; } else { pause = Color.Red; pausehover = Color.Gray; pausetext = "Resume"; }
                gui_stuff.Add(new Button(150, 0, 50, 20, pausetext, pause, pausehover, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.ToggleBackground(!guimanager.sound_handler.togglebackground); if (guimanager.sound_handler.togglebackground) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Pause"; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; button.label.text = "Resume"; } }));

                Background = BackgroundType.ingamebackground;
            }
            else
            {
                Background = BackgroundType.menubackground;
            }

            return new Screen(Background, fallable_objects, stable_objects, gui_stuff, Interacting_Objects, islevel);
        }
    }
}