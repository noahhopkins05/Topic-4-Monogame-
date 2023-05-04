using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Topic_4_Monogame_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D bombTexture;
        SoundEffect explosion;
        SpriteFont timeFont;
        MouseState mouseState;
        float seconds, secondsCountDown;
        float startTime;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            bombTexture = Content.Load<Texture2D>("bomb (1)");
            timeFont = Content.Load<SpriteFont>("TimeFont");
            explosion = Content.Load<SoundEffect>("explosion");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            if (seconds > 10) // Takes a timestamp every 10 seconds.
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(bombTexture, new Rectangle(50, 50, 700, 400), Color.White);
            _spriteBatch.DrawString(timeFont, seconds.ToString("00.0"), new Vector2(270, 200), Color.Black); 


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}