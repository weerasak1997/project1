using System.Collections.Generic;
using Game2.game;
using Game2.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Game2.Gamescreen;
using Game2.spriteseet;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D wall;
        Texture2D getwall1;
        Texture2D mouse;
        Texture2D character;
        Vector2 wallPosition;
        Vector2 mousePosition;
        Vector2 charactorPosition;
        KeyboardState previousState;
        KeyboardState nowState;

        private SpriteSheet spriteSheet;

        private List<Sprite> _sprites;
        private MouseControl mouseControl;
        float sRotation = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            wallPosition = new Vector2(0, 0);
            charactorPosition = new Vector2(300, 300);
            
        }

        
        protected override void Initialize()
        {
            spriteSheet = new SpriteSheet("character", 58, 86, 6, 1, true);
            graphics.PreferredBackBufferWidth = 1850;
            graphics.PreferredBackBufferHeight = 1000;
            Window.AllowUserResizing = true;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            base.Initialize();
        }

       
        protected override void LoadContent()
        {
            spriteSheet.LoadContent(Content, GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            getwall1 = this.Content.Load<Texture2D>("getwall1");
            ScreenManager.Instance.LoadContent(Content);
            mouse = this.Content.Load<Texture2D>("mouse");
            character = this.Content.Load<Texture2D>("character");
            wall = this.Content.Load<Texture2D>("wall");
            mouseControl = new MouseControl(mouse);
            _sprites = new List<Sprite>()
            {
                new Player(character)
                {
                    Input = new Input()
                    {
                        Left = Keys.A,
                        Right = Keys.D,
                        Up = Keys.W,
                        Down = Keys.S,

                    },
                    Position = new Vector2(960,500),
                    Colour = Color.White,
                    Origin = new Vector2(character.Width / 2, character.Height / 2),

                },
                new Player(getwall1)
                {
                    Input = new Input()
                    {
                        Left = 0,
                        Right = 0,
                        Up = 0,
                        Down = 0,

                    },
                    Position = new Vector2(300,300),
                    Colour = Color.White,
                    Origin = new Vector2(character.Width / 2, character.Height / 2),

                },
            };
        }
  
        protected override void UnloadContent()
        {
            ScreenManager.Instance.UnloadContent();
        }

       
        protected override void Update(GameTime gameTime)
        {
            MouseState state = Mouse.GetState();
            mouseControl.Mouse(state);
            foreach(var sprite in _sprites)
            sprite.Update(gameTime, _sprites);
            ScreenManager.Instance.Update(gameTime);
            //
            if (gameTime.TotalGameTime.TotalSeconds > 5)
            {
                spriteSheet.Update(gameTime);
            }


            base.Update(gameTime);

        }

        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            //spriteBatch.Draw(spriteSheet.CurrentFrame, Vector2.Zero, Color.White);
            //spriteBatch.Draw(getwall1, Vector2.Zero, Color.White);
            //ScreenManager.Instance.Draw(spriteBatch);


            //move
            foreach (var sprite in _sprites)
            sprite.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        } //New class

    }      
}
