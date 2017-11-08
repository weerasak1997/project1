using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game9.Model;
using Game9.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game9.States
{
    class GameState5 : State
    {
        public Game1 game;


        public GameState5(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {

        }

        public void LoadContent()
        {

        }

        public override void Draw(GameTime GameTime, SpriteBatch spriteBatch)
        {


        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime game)
        {
            MyGlobals.retry = 5;
        }
    }
}
