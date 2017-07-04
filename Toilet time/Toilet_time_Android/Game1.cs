using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;

namespace Toilet_time_Android
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        int CurrentWidth;
        int CurrentHeight;

        public Toilet_time_main.Gui_Manager gui_manager;
        public DrawVisitor draw_visitor;
        public Texture2D Texture_White_Pixel;
        public Texture2D Texture_Platform;
        public Texture2D Texture_Main_char;
        public Texture2D Texture_Main_Char_with_Baby;
        public Texture2D Texture_Baby;
        public Texture2D Texture_Toilet;
        public Texture2D Texture_Toilet_With_Baby;
        public Texture2D Texture_Toilet_Paper;
        public Texture2D Texture_Deadly_Bricks;
        public Texture2D Texture_Mouse;
        public Texture2D Texture_Spikes;
        public Texture2D Texture_Background_Wood;
        public Texture2D Texture_Enemy_Grandma;

        public SpriteFont Arial;

        public Input_Adapter_Android inputhandler;  
        
        public SoundEffect End_Level;
        public SoundEffect Baby_Cry;
        public SoundEffect Baby_Laugh;
        public SoundEffect Menu_Background;
        public SoundEffect Ingame_Background;
        
        public Toilet_time_main.SoundHandler sound_handler;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.IsMouseVisible = false;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            Texture_White_Pixel = Content.Load<Texture2D>("white_pixel");
            Texture_Platform = Content.Load<Texture2D>("brick");
            Texture_Main_char = Content.Load<Texture2D>("Main");
            Texture_Main_Char_with_Baby = Content.Load<Texture2D>("Main with baby");
            Texture_Baby = Content.Load<Texture2D>("baby");
            Texture_Toilet = Content.Load<Texture2D>("Endgametoilet");
            Texture_Toilet_With_Baby = Content.Load<Texture2D>("Endgame_with_toilet");
            Texture_Toilet_Paper = Content.Load<Texture2D>("Toilet_Papier");
            Texture_Deadly_Bricks = Content.Load<Texture2D>("DeadlyBricks");
            Texture_Background_Wood = Content.Load<Texture2D>("Background_Wood");
            Texture_Mouse = Content.Load<Texture2D>("mouse");
            Texture_Enemy_Grandma = Content.Load<Texture2D>("enemygrandma");
            Texture_Spikes = Content.Load<Texture2D>("spikes");

            Arial = Content.Load<SpriteFont>("Arial");

            
            End_Level = Content.Load<SoundEffect>("End_Level");
            Baby_Cry = Content.Load<SoundEffect>("Baby_Crying");
            Baby_Laugh = Content.Load<SoundEffect>("Baby_Laughing");

            Ingame_Background = Content.Load<SoundEffect>("Ingame_Background");
            Menu_Background = Content.Load<SoundEffect>("Menu_background");
            

            sound_handler = new Toilet_time_main.SoundHandler(Menu_Background, Ingame_Background, End_Level, Baby_Laugh,Baby_Cry);

            CurrentWidth = graphics.GraphicsDevice.DisplayMode.Width;
            CurrentHeight = graphics.GraphicsDevice.DisplayMode.Height;

            inputhandler = new Input_Adapter_Android(CurrentHeight, CurrentWidth);
            draw_visitor = new DrawVisitor(CurrentWidth, CurrentHeight, 2f, spriteBatch, graphics, Arial, Texture_White_Pixel, Texture_Platform, Texture_Main_char, Texture_Main_Char_with_Baby, Texture_Baby, Texture_Toilet, Texture_Toilet_With_Baby, Texture_Deadly_Bricks, Texture_Toilet_Paper, Texture_Spikes, Texture_Background_Wood, Texture_Mouse, Texture_Enemy_Grandma);
            gui_manager = new Toilet_time_main.Gui_Manager(draw_visitor, sound_handler, inputhandler, Toilet_time_main.Systemtype.android);




            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>


        float updatetimenow = 0;
        float updateprevtime = 0;
        float updatetimedifference = 0;

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            // TODO: Add your update logic here


            updateprevtime = updatetimenow;
            updatetimenow = (float)gameTime.TotalGameTime.TotalMilliseconds;
            updatetimedifference = (updatetimenow - updateprevtime) / 1000;

            gui_manager.Update((updatetimedifference));
            if (gui_manager.exit == true)
            {
                this.Exit();
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        float drawprevtime = 0;
        float drawtimenow = 0;
        float drawtimedifference = 0;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            drawprevtime = updatetimenow;
            drawtimenow = (float)gameTime.TotalGameTime.TotalMilliseconds;
            drawtimedifference = (updatetimenow - updateprevtime) / 1000;

            // TODO: Add your drawing code here
            gui_manager.Draw(drawtimedifference);
            base.Draw(gameTime);
        }
    }
}
