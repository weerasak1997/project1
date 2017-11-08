using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game9.States
{
    class GameState : State
    {
        public Game1 game;
        public State _currentState;
        public State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _currentState = new MenuToFront(_game, _graphicsDevice, _content);

        }

        public void LoadContent()
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _currentState.Draw(gameTime, spriteBatch);
            
        }

        public override void PostUpdate(GameTime gameTime)
        {
          

        }

        public override void Update(GameTime gameTime)
        {
           
                if (_nextState != null)
                {
                    _currentState = _nextState;

                    _nextState = null;
                }

                _currentState.Update(gameTime);

                _currentState.PostUpdate(gameTime);

            
        }
    }
}
