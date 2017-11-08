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
    class MenuToFront : State
    {
        public int state = 0;
        public Texture2D Screen;


        public Texture2D Cloud1;
        public Texture2D Cloud2;
        public Texture2D Cloud3;
        public Texture2D Cloud4;
        public Vector2 Cloud1Position = new Vector2(0, 10);
        public Vector2 Cloud2Position = new Vector2(400, 200);
        public Vector2 Cloud3Position = new Vector2(800, 35);
        public Vector2 Cloud4Position = new Vector2(1200, 15);
        Random random = new Random();
        public Vector2 screenPosition = new Vector2(0, 0);
        public Game1 game;
        private List<Component> _component;
        public MenuToFront(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            Screen = this._content.Load<Texture2D>("Screen/ScreenMenu1");
            Cloud1 = _content.Load<Texture2D>("Cloud/Cloud1");
            Cloud2 = _content.Load<Texture2D>("Cloud/Cloud2");
            Cloud4 = _content.Load<Texture2D>("Cloud/Cloud1");
            Cloud3 = _content.Load<Texture2D>("Cloud/Cloud2");

            var buttonTexture = _content.Load<Texture2D>("Control/buttonSelect");
            var buttonMenuTexture = _content.Load<Texture2D>("Control/buttomMenu");
            var buttonQuitMenuTexture = _content.Load<Texture2D>("Control/buttonQuitMenu");
            var buttonNextTexture = _content.Load<Texture2D>("Control/buttonNext");
            var buttonNextBackTexture = _content.Load<Texture2D>("Control/buttonBackNext");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var oneStateButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(122,692),
            };
            oneStateButton.Click += OneStateButton_Click;

            var twoStateButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(723, 590),
            };
            twoStateButton.Click += TwoStateButton_Click;

            var threeStateButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1365, 672),
            };
            threeStateButton.Click += ThreeStateButton_Click;


            var quitGameButton = new Button(buttonQuitMenuTexture, buttonFont)
            {
                Position = new Vector2(1800, 20),
            };
            quitGameButton.Click += quitGameButton_Click;

            var meneGameButton = new Button(buttonMenuTexture, buttonFont)
            {
                Position = new Vector2(900, 850),
            };
            meneGameButton.Click += MeneGameButton_Click;

            var nextGameButton = new Button(buttonNextTexture, buttonFont)
            {
                Position = new Vector2(1800, 850),
            };
            nextGameButton.Click += NextGameButton_Click;

            var nextBackGameButton = new Button(buttonNextBackTexture, buttonFont)
            {
                Position = new Vector2(16, 850),
            };
            nextBackGameButton.Click += NextBackGameButton_Click;


            _component = new List<Component>()
            {
                oneStateButton,
                quitGameButton,
                twoStateButton,
                threeStateButton,
                meneGameButton,
                nextGameButton,
                nextBackGameButton,
            };
        }

        private void NextBackGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void NextGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuToFront2(_game, _graphicsDevice, _content));
        }

        private void MeneGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            
        }

        private void OneStateButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Advise1(_game, _graphicsDevice, _content));
        }

        private void TwoStateButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState2(_game, _graphicsDevice, _content));
        }

        private void ThreeStateButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState3(_game, _graphicsDevice, _content));
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(Screen, screenPosition, Color.White);
            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);
             spriteBatch.Draw(Cloud2, Cloud2Position, Color.White);
            spriteBatch.Draw(Cloud1, Cloud1Position, Color.White);
            spriteBatch.Draw(Cloud3, Cloud3Position, Color.White);
            spriteBatch.Draw(Cloud4, Cloud4Position, Color.White);
        }

        



        public override void PostUpdate(GameTime gameTime)
        {
            //Remove sptites if they ' re not needed
        }

        public override void Update(GameTime gameTime)
        {
            Cloud1Position.X += 1;
            if (Cloud1Position.X > 2000)
            {
                Cloud1Position.X = -50;

            }
            Cloud2Position.X += 1;
            if (Cloud2Position.X > 2000)
            {
                Cloud2Position.X = -10;

            }
            Cloud3Position.X += 1;
            if (Cloud3Position.X > 2000)
            {
                Cloud3Position.X = -50;

            }
            Cloud4Position.X += 1;
            if (Cloud4Position.X > 2000)
            {
                Cloud4Position.X = -10;

            }

            foreach (var component in _component)
                component.Update(gameTime);
        }

        public void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

    }
}
