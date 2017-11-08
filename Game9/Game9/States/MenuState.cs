
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game9.Buttons;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace Game9.States

{
    public class MenuState : State
    {

        public int state = 0;
        public Texture2D screenTop;
        public Vector2 screenTopPosition = new Vector2(0, 0);

        private List<Component> _component;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            screenTop = _content.Load<Texture2D>("Screen/ScreenTop");
            var buttonTexture = _content.Load<Texture2D>("Control/buttonNewGame");
            var buttonTexture2 = _content.Load<Texture2D>("Control/buttonQuit");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(228, 407),
                Text = " ",
            };
            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture2, buttonFont)
            {
                Position = new Vector2(1416, 414),
                Text = " ",
            };
            quitGameButton.Click += quitGameButton_Click;


            _component = new List<Component>()
            {
                newGameButton,
                quitGameButton,
            };
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(screenTop, screenTopPosition,Color.White);
            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }



        public override void PostUpdate(GameTime gameTime)
        {
            //Remove sptites if they ' re not needed
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _component)
                component.Update(gameTime);
        }

        public void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

    }
}
