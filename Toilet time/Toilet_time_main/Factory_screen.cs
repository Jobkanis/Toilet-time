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

        public Screen Create_screen(int level_number) // returns a screen class with the corresponding level_number
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
                        gui_manager.paused = false;
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            gui_stuff.Add(new Button(350, 100, 100, 50, "Play", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(5); }));
                            gui_stuff.Add(new Button(350, 200, 100, 50, "Settings", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(2); }));
                            gui_stuff.Add(new Button(350, 300, 100, 50, "Exit", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.exit = true; }));
                        }
                        else if (gui_manager.systemtype == Systemtype.android)
                        {
                            gui_stuff.Add(new Button(400, 100, 100, 50, "Play", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(5); }));
                            gui_stuff.Add(new Button(400, 200, 100, 50, "Settings", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(4); }));
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
                            gui_stuff.Add(new Button(350, 200, 100, 50, "Controls", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(3); }));
                            gui_stuff.Add(new Button(350, 300, 100, 50, "Sounds", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(4); }));

                        }

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
                            gui_stuff.Add(new Button(350, 180, 100, 50, "Arrows", inputcolorArrows, hovercolorArrows, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(1); guimanager.Create_screen(3); }));
                            gui_stuff.Add(new Button(350, 260, 100, 50, "Wasd", inputcolorWASD, hovercolorWASD, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(2); guimanager.Create_screen(3); }));

                            if (gui_manager.Gamepadonline == true)
                            {
                                gui_stuff.Add(new Button(350, 340, 100, 50, "GamePad", inputcolorGamePad, hovercolorGamePad, (Gui_Manager guimanager, Button button) => { guimanager.Getinputmechanism(3); guimanager.Create_screen(3); }));
                            }
                        }
                        break;
                    }

                case 4:
                    //sound settings
                    {
                        islevel = false;
                        int x = 350;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            x = 350;
                            gui_stuff.Add(new Button(x, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(2); }));

                        }
                        else if (gui_manager.systemtype == Systemtype.android)
                        {
                            x = 400;
                            gui_stuff.Add(new Button(x, 100, 100, 50, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(1); }));

                        }
                        Color MCMO, MC, SCMO, SC; String soundtext, musictext;
                        if (gui_manager.sound_handler.togglebackground) { MC = Color.Black; MCMO = Color.IndianRed; musictext = "Music: on"; } else { MC = Color.Red; MCMO = Color.Gray; musictext = "Music: off"; }
                        if (gui_manager.sound_handler.togglesoundeffect) { SC = Color.Black; SCMO = Color.IndianRed; soundtext = "Sounds: on"; } else { SC = Color.Red; SCMO = Color.Gray; soundtext = "Sounds: off"; }
                        gui_stuff.Add(new Button(x, 200, 100, 50, musictext, MC, MCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.ToggleBackground(!guimanager.sound_handler.togglebackground); if (guimanager.sound_handler.togglebackground) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Music: on"; } else { button.regularcolor = Color.Red; button.mouseovercolor = Color.Gray; button.label.text = "Music: off"; } }));
                        gui_stuff.Add(new Button(x, 300, 100, 50, soundtext, SC, SCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.Togglesoundeffect(!guimanager.sound_handler.togglesoundeffect); if (guimanager.sound_handler.togglesoundeffect) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Sounds: on"; } else { button.regularcolor = Color.Red; button.mouseovercolor = Color.Gray; button.label.text = "Sounds: off"; } }));
                    }
                    break;


                case 5:
                    //play settings
                    {
                        gui_manager.paused = false;
                        islevel = false;
                        if (gui_manager.systemtype == Systemtype.windows)
                        {
                            gui_stuff.Add(new Button(350, 150, 100, 50, "Easy mode", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Lifes_enabled = false; guimanager.Create_screen(6); }));
                            gui_stuff.Add(new Button(350, 250, 100, 50, "Hard mode", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Lifes_enabled = true; guimanager.Create_screen(6); }));
                        }
                        else if (gui_manager.systemtype == Systemtype.android)
                        {
                            gui_stuff.Add(new Button(400, 150, 100, 50, "Easy mode", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Lifes_enabled = false; guimanager.Create_screen(6); }));
                            gui_stuff.Add(new Button(400, 250, 100, 50, "Hard mode", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Lifes_enabled = true; guimanager.Create_screen(6); }));
                        }
                        break;
                    }

                case 6:
                    //level 1 - Robin 
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 7));
                        //interactions
                        Interacting_Objects.Add(new Baby(350, 0));
                        Interacting_Objects.Add(new End_Goal(500, 0));

                        //platforms
                        stable_objects.Add(new Platform(100, 300, 600, 20));


                        break;
                    }

                case 7:
                    //level 2 - Robin
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 8));

                        //interactions
                        Interacting_Objects.Add(new Baby(330, 0));
                        Interacting_Objects.Add(new End_Goal(600, 0));


                        //platforms
                        stable_objects.Add(new Platform(0, 400, 800, 20));
                        stable_objects.Add(new Platform(300, 300, 100, 20));

                        break;
                    }

                case 8:
                    //level 3 - Robin
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 9));
                        
                        //interactions
                        Interacting_Objects.Add(new Baby(200 - 340, 0));
                        Interacting_Objects.Add(new End_Goal(1000 - 340, 0));
                        Interacting_Objects.Add(new Deadly_Brick(300 - 340, 0));
                        Interacting_Objects.Add(new Deadly_Brick(371 - 340, 0));
                        Interacting_Objects.Add(new Deadly_Brick(650 - 340, 0));
                        Interacting_Objects.Add(new Deadly_Brick(721 - 340, 0));

                        //platforms
                        stable_objects.Add(new Platform(0 - 340, 300, 1200, 20));

                        break;
                    }

                case 9:
                    //level 4 - Robin
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(90 + 110, 0, 10));

                        //interactions
                        Interacting_Objects.Add(new Baby(15 + 110, 0));
                        Interacting_Objects.Add(new End_Goal(900 + 110, 0));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(400 + 110, -300, 1.0f));

                        //platforms
                        stable_objects.Add(new Platform(5 + 110, 200, 50, 20));
                        stable_objects.Add(new Platform(50 + 110, 380, 150, 20));
                        stable_objects.Add(new Platform(125 + 110, 275, 40, 20));
                        stable_objects.Add(new Platform(490 + 110, 400, 550, 20));

                        break;
                    }

                case 10:
                    //level 5 - Robin
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 11));

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

                case 11:
                    //level 6 Tahsin
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(10 + 190, 0, 16));
                        //interactions
                        Interacting_Objects.Add(new Baby(625 + 190, 150));
                        Interacting_Objects.Add(new End_Goal(500 + 190, 150));
                        Interacting_Objects.Add(new Deadly_Brick(150 + 190, 150));
                        Interacting_Objects.Add(new Enemy_Grandma(400 + 190, 0, 80, 100));
                        //platforms
                        stable_objects.Add(new Platform(5 + 190, 300, 290, 20));
                        stable_objects.Add(new Platform(400 + 190, 300, 150, 20));
                        stable_objects.Add(new Platform(600 + 190, 300, 70, 20));
                        break;

                    }


                case 16:
                    // level 7 ~Ogie
                    {
                        islevel = true;


                        //character
                        fallable_objects.Add(new Main_Character(200, 300, 12));
                        Interacting_Objects.Add(new Baby(750, 0));

                        //interactions
                        Interacting_Objects.Add(new End_Goal(800, 350));
                        Interacting_Objects.Add(new Spider(500, 350, true, 125));

                        //platforms
                        stable_objects.Add(new Platform(150, 400, 100, 20));
                        stable_objects.Add(new Platform(800, 400, 50, 20));
                        stable_objects.Add(new Platform(750, 100, 50, 20));
                        stable_objects.Add(new Platform(500, 100, 50, 20));
                        stable_objects.Add(new Platform(100, 300, 50, 20));
                        stable_objects.Add(new Platform(200, 175, 50, 20));
                        stable_objects.Add(new Platform(350, 400, 300, 20));
                        stable_objects.Add(new Platform(350, 375, 50, 20));
                        stable_objects.Add(new Platform(600, 375, 50, 20));

                        break;
                    }



                case 12:
                    //level 8 - Tahsin
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(320 - 120, 0, 17));
                        //interactions
                        Interacting_Objects.Add(new Baby(330 - 120, 150));
                        Interacting_Objects.Add(new End_Goal(900 - 120, 150));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(550 - 120, -480, 0.5f));
                        Interacting_Objects.Add(new Deadly_Brick(800 - 120, 0));
                        Interacting_Objects.Add(new Deadly_Brick(970 - 120, 0));

                        //platforms
                        stable_objects.Add(new Platform(5 - 120, 200, 55, 20));
                        stable_objects.Add(new Platform(65 - 120, 280, 90, 20));
                        stable_objects.Add(new Platform(200 - 120, 190, 20, 300));
                        stable_objects.Add(new Platform(220 - 120, 280, 50, 20));
                        stable_objects.Add(new Platform(220 - 120, 100, 200, 20));
                        stable_objects.Add(new Platform(290 - 120, 360, 90, 20));
                        stable_objects.Add(new Platform(430 - 120, 150, 100, 20));
                        stable_objects.Add(new Platform(600 - 120, 120, 150, 20));
                        stable_objects.Add(new Platform(800 - 120, 360, 250, 20));

                        break;
                    }


                case 17:
                    // level 9 ~Ogie
                    {
                        islevel = true;


                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 13));
                        Interacting_Objects.Add(new Baby(1110, 0));
                        Interacting_Objects.Add(new Enemy_Grandma(300, 0, 120, 50));

                        //interactions
                        Interacting_Objects.Add(new End_Goal(-150, 0));
                        Interacting_Objects.Add(new Deadly_Brick(740, 0));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(500, -400, 0.8f));
                        Interacting_Objects.Add(new Spike_Dropper(650, 0, 1.0f));

                        Interacting_Objects.Add(new Toilet_Paper_Drop(950, -400, 0.8f));

                        //platforms
                        stable_objects.Add(new Platform(-200, 300, 100, 20));

                        stable_objects.Add(new Platform(200, 300, 275, 20));
                        stable_objects.Add(new Platform(700, 300, 150, 20));
                        stable_objects.Add(new Platform(1100, 300, 50, 20));


                        break;

                    }




                case 13:
                    // level 11 - Tahsin
                    {
                        islevel = true;

                        //character
                        fallable_objects.Add(new Main_Character(50 + 150, 0, 14));
                        //interactions
                        Interacting_Objects.Add(new Baby(180 + 150, 0));
                        Interacting_Objects.Add(new End_Goal(900 + 150, 150));
                        Interacting_Objects.Add(new Enemy_Grandma(350 + 150, 0, 200, 100));
                        Interacting_Objects.Add(new Deadly_Brick(600 + 150, 0));
                        Interacting_Objects.Add(new Deadly_Brick(800 + 150, 0));

                        //platforms
                        stable_objects.Add(new Platform(0 + 150, 300, 1000, 20));
                        stable_objects.Add(new Platform(150 + 150, 120, 60, 20));
                        stable_objects.Add(new Platform(250 + 150, 140, 60, 20));
                        stable_objects.Add(new Platform(350 + 150, 160, 60, 20));
                        stable_objects.Add(new Platform(450 + 150, 180, 60, 20));
                        break;

                    }
                case 14: // level 12 ~ogie
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(30 + 170, 0, 15));
                        Interacting_Objects.Add(new Baby(950 + 170, 0));

                        //interactions
                        Interacting_Objects.Add(new End_Goal(0 + 170, 0));

                        // fallable objects
                        Interacting_Objects.Add(new Toilet_Paper_Drop(315 + 170, -320, 0.8f));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(510 + 170, -320, 0.8f));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(710 + 170, -320, 0.8f));



                        //Platforms
                        stable_objects.Add(new Platform(0 + 170, 150, 50, 20));
                        stable_objects.Add(new Platform(100 + 170, 250, 50, 20));
                        stable_objects.Add(new Platform(150 + 170, 350, 50, 20));
                        stable_objects.Add(new Platform(200 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(250 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(350 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(450 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(550 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(650 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(750 + 170, 400, 50, 20));
                        stable_objects.Add(new Platform(850 + 170, 350, 50, 20));
                        stable_objects.Add(new Platform(950 + 170, 250, 50, 20));
                        stable_objects.Add(new Platform(950 + 170, 150, 50, 20));
                        stable_objects.Add(new Platform(350 + 170, 100, 500, 20));

                        break;
                    }
                case 15:
                    //level 13 - Tahsin
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(200, 0, 18));
                        //interactions
                        Interacting_Objects.Add(new Baby(1100, 0));
                        Interacting_Objects.Add(new End_Goal(80, 0));
                        Interacting_Objects.Add(new Deadly_Brick(300, 0));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(400, -400, 0.8f));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(300, -300, 0.8f));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(890, -890, 0.8f));
                        Interacting_Objects.Add(new Toilet_Paper_Drop(1000, -1000, 0.8f));

                        //platforms
                        stable_objects.Add(new Platform(0, 300, 300, 20));
                        stable_objects.Add(new Platform(200, 250, 250, 20));
                        stable_objects.Add(new Platform(400, 200, 30, 20));
                        stable_objects.Add(new Platform(450, 300, 100, 20));
                        stable_objects.Add(new Platform(475, 300, 300, 20));
                        stable_objects.Add(new Platform(780, 250, 60, 20));
                        stable_objects.Add(new Platform(890, 200, 60, 20));
                        stable_objects.Add(new Platform(1000, 150, 60, 20));
                        stable_objects.Add(new Platform(1100, 100, 40, 20));
                        break;
                    }

                    case 18:
                    //level 10 - Robin
                    {
                        islevel = true;
                        //character
                        fallable_objects.Add(new Main_Character(20 + 180, 0, 1));
                        //interactions
                        Interacting_Objects.Add(new Deadly_Brick(650 + 180, 0));
                        Interacting_Objects.Add(new Baby(1315 + 180, 0));
                        Interacting_Objects.Add(new End_Goal(1460 + 180, 0));
                        Interacting_Objects.Add(new Spider(1140 + 180, -20, true, 60));
                        Interacting_Objects.Add(new Spider(1100 + 180, -20, false, 60));

                        //platforms
                        stable_objects.Add(new Platform(20 + 180, 350, 60, 20));
                        stable_objects.Add(new Platform(240 + 180, 350, 50, 20));
                        stable_objects.Add(new Platform(350 + 180, 310, 30, 20));
                        stable_objects.Add(new Platform(260 + 180, 240, 30, 20));
                        stable_objects.Add(new Platform(390 + 180, 180, 50, 20));
                        stable_objects.Add(new Platform(650 + 180, 180, 200, 20));
                        stable_objects.Add(new Platform(950 + 180, 320, 40, 20));
                        stable_objects.Add(new Platform(1030 + 180, 220, 10, 20));
                        stable_objects.Add(new Platform(1300 + 180, 190, 50, 20));
                        stable_objects.Add(new Platform(1350 + 180, -20, 40, 300));
                        stable_objects.Add(new Platform(1050 + 180, 350, 320, 20));
                        stable_objects.Add(new Platform(1030 + 180, 350, 20, 100));
                        stable_objects.Add(new Platform(1370 + 180, 350, 20, 100));
                        stable_objects.Add(new Platform(1450 + 180, 350, 80, 20));

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
                gui_stuff.Add(new Button(0, 0, 50, 30, "Back", Color.Black, Color.Gray, (Gui_Manager guimanager, Button button) => { guimanager.Create_screen(1); }));

                //sound settings in game
                Color MCMO, MC, SCMO, SC;
                if (gui_manager.sound_handler.togglebackground) { MC = Color.Black; MCMO = Color.IndianRed; } else { MC = Color.DarkRed; MCMO = Color.Black; }
                if (gui_manager.sound_handler.togglesoundeffect) { SC = Color.Black; SCMO = Color.IndianRed; } else { SC = Color.DarkRed; SCMO = Color.Black; }
                gui_stuff.Add(new Button(50, 0, 50, 30, "Music", MC, MCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.ToggleBackground(!guimanager.sound_handler.togglebackground); if (guimanager.sound_handler.togglebackground) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; } }));
                gui_stuff.Add(new Button(100, 0, 50, 30, "Sound", SC, SCMO, (Gui_Manager guimanager, Button button) => { guimanager.sound_handler.Togglesoundeffect(!guimanager.sound_handler.togglesoundeffect); if (guimanager.sound_handler.togglesoundeffect) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; } }));

                //pausebutton in game
                Color pause, pausehover; String pausetext;
                if (!gui_manager.paused) { pause = Color.Black; pausehover = Color.IndianRed; pausetext = "Pause"; } else { pause = Color.DarkRed; pausehover = Color.Gray; pausetext = "Resume"; }
                gui_stuff.Add(new Button(150, 0, 50, 30, pausetext, pause, pausehover, (Gui_Manager guimanager, Button button) => { guimanager.paused =! guimanager.paused; if (!guimanager.paused) { button.regularcolor = Color.Black; button.mouseovercolor = Color.IndianRed; button.label.text = "Pause"; } else { button.regularcolor = Color.DarkRed; button.mouseovercolor = Color.Gray; button.label.text = "Resume"; } }));
                if (gui_manager.Lifes_enabled)
                {
                    for (int i = 0; i < gui_manager.lifes; i++)
                    {
                        gui_stuff.Add(new Heart(203 + i * 30, 0));
                    }
                }
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