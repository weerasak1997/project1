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
    class Advise1 : State
    {
        public int state = 0;

        private List<Component> _component;
        public Advise1(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Control/button2");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var playButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(150, 50),
                Text = "1",
            };
            playButton.Click += PlayButton_Click;
            /*
            var leftButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(150, 50),
                Text = "1",
            };
            leftButton.Click += LeftButton_Click;*/

            var rightButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(150, 50),
                Text = "1",
            };
            rightButton.Click += RightButton_Click;

            _component = new List<Component>()
            {
                playButton,
               
            };
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new Advise1_1(_game, _graphicsDevice, _content));
        }


        private void PlayButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState1(_game, _graphicsDevice, _content));

        }

     


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {


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