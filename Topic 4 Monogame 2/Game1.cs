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
        Texture2D bombTexture, explosionTexture;
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
            explosionTexture = Content.Load<Texture2D>("explosiontransparent");

        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            secondsCountDown = 1 - seconds;

            if (secondsCountDown < 0.02 && secondsCountDown > 0)
                explosion.Play();
            if (secondsCountDown <-9)
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            _spriteBatch.Draw(bombTexture, new Rectangle(50, 50, 700, 400), Color.White);
            _spriteBatch.DrawString(timeFont, secondsCountDown.ToString("00.0"), new Vector2(270, 200), Color.Black);
            if (secondsCountDown < 0)
            {
                _spriteBatch.Draw(explosionTexture, new Rectangle(100, 45, 600, 500), Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}