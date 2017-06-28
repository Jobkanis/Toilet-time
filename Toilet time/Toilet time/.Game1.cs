using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Media;

namespace Toilet_time
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Gui_Manager gui_manager;
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

        public Texture2D Texture_Background_Wood;

        public SpriteFont arial;
        public SoundEffect End_Level;
        public SoundEffect Baby_Cry;
        public SoundEffect Baby_Laugh;
        public SoundEffect Menu_Background;
        public SoundEffect Ingame_Background;
        public SoundHandler sound_handler;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            this.IsMouseVisible = true;
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
            arial = Content.Load<SpriteFont>("arial");

            Texture_White_Pixel = Content.Load<Texture2D>("white_pixel");
            Texture_Platform = Content.Load<Texture2D>("brick");
            Texture_Main_char = Content.Load<Texture2D>("Main");
            Texture_Main_Char_with_Baby = Content.Load<Texture2D>("Main with baby");
            Texture_Baby = Content.Load<Texture2D>("Baby");
            Texture_Toilet = Content.Load<Texture2D>("Endgametoilet");
            Texture_Toilet_With_Baby = Content.Load<Texture2D>("Endgame_with_toilet");
            Texture_Toilet_Paper = Content.Load<Texture2D>("Toilet_Papier");
            Texture_Deadly_Bricks = Content.Load<Texture2D>("DeadlyBricks");
            Texture_Background_Wood = Content.Load<Texture2D>("Background_Wood");



            End_Level = Content.Load<SoundEffect>("End_Level");
            Baby_Cry = Content.Load<SoundEffect>("Baby_Crying");
            Baby_Laugh = Content.Load<SoundEffect>("Baby_Laughing");

            Ingame_Background = Content.Load<SoundEffect>("Ingame_Background");
            Menu_Background = Content.Load<SoundEffect>("Menu_background");

            sound_handler = new SoundHandler(Menu_Background, Ingame_Background, End_Level, Baby_Laugh, Baby_Cry);
            
            draw_visitor = new DrawVisitor(spriteBatch, graphics, arial, Texture_White_Pixel, Texture_Platform, Texture_Main_char, Texture_Main_Char_with_Baby, Texture_Baby, Texture_Toilet, Texture_Toilet_With_Baby, Texture_Deadly_Bricks, Texture_Toilet_Paper, Texture_Background_Wood);
            gui_manager = new Gui_Manager(this, draw_visitor, sound_handler);
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            gui_manager.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            gui_manager.Draw((float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000);
            base.Draw(gameTime);
        }
    }
}
