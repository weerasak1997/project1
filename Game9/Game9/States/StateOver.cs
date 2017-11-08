using System.Linq;
using System.Text;
using Game9.Buttons;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Game9.States
{
    class StateOver : State
    {
        public int state = 0;
        public Texture2D Screen;
        public Vector2 screenPosition = new Vector2(0, 0);

        private List<Component> _component;
        public StateOver(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

            Screen = this._content.Load<Texture2D>("Screen/StateOver");

            var buttonBackTexture = _content.Load<Texture2D>("Control/buttonBack");
            var buttonMenuTexture = _content.Load<Texture2D>("Control/buttomMenu");
            var buttonQuitMenuTexture = _content.Load<Texture2D>("Control/buttonQuitMenu");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");


            var retryStateButton = new Button(buttonBackTexture, buttonFont)
            {
                Position = new Vector2(1485, 209),
            };
            retryStateButton.Click += RetryStateButton;
            var quitGameButton = new Button(buttonQuitMenuTexture, buttonFont)
            {
                Position = new Vector2(940, 432),
            };
            quitGameButton.Click += quitGameButton_Click;
            var meneGameButton = new Button(buttonMenuTexture, buttonFont)
            {
                Position = new Vector2(347, 480),
            };
           
            meneGameButton.Click += MeneGameButton_Click;

            _component = new List<Component>()
            {
                quitGameButton,
                meneGameButton,
                retryStateButton,
            };
        }

        private void MeneGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));

        }

        private void RetryStateButton(object sender, EventArgs e)
        {
            switch (MyGlobals.retry)
            {
                case 1: _game.ChangeState(new GameState1(_game, _graphicsDevice, _content)) ; break;
                case 2: _game.ChangeState(new GameState2(_game, _graphicsDevice, _content)); break;
                case 3: _game.ChangeState(new GameState3(_game, _graphicsDevice, _content)); break;
                case 4: _game.ChangeState(new GameState4(_game, _graphicsDevice, _content)); break;
                case 5: _game.ChangeState(new GameState5(_game, _graphicsDevice, _content)); break;
                case 6: _game.ChangeState(new GameState6(_game, _graphicsDevice, _content)); break;
            }
        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Screen, screenPosition, Color.White);

            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);

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
