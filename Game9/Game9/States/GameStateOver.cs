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
    class GameStateOver : State
    {

        public int state = 0;


        private List<Component> _component;
        public GameStateOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Control/button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 400),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 600),
                Text = "Quit",
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


            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);

        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
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
