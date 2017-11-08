﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game8.Control;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game8.States
{
    public class MenuState : State
    {
        private List<Component> _component;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click; 

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 400),
                Text = "Load Game",
            };
            loadGameButton.Click += LoadGameButton_Click; 

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(300, 600),
                Text = "Quit",
            };
            quitGameButton.Click += quitGameButton_Click; 


            _component = new List<Component>()
            {
                newGameButton,
                loadGameButton,
                quitGameButton,
            };
        }

        

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _component)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

      

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            
            Console.WriteLine("Load Game");
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
