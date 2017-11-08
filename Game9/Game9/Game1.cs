using System;
using System.Collections.Generic;
using Game9.Model;
using Game9.Sprites;
using Game9.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game9
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        Vector2 positionScores = new Vector2(0, 0);
        Vector2 screenPosition = new Vector2(0, 0);


        //Button
        public State _currentState;
        public State _nextState;


        public List<Sprite> _sprites;
        public void ChangeState(State state)
        {
            _nextState = state;
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1000;
            graphics.IsFullScreen = true;
            //Window.AllowUserResizing = true;
            graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);




        }

  
        protected override void UnloadContent()
        {
           
        }


        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (_nextState != null)
                {
                    _currentState = _nextState;

                    _nextState = null;
                }

                _currentState.Update(gameTime);

                _currentState.PostUpdate(gameTime);


                base.Update(gameTime);
            }

        } 
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            _currentState.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
