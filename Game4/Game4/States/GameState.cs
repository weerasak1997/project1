using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game4.Object;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game4.States
{
    public class GameState : State
    {
        public Game1 game;
 
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
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
            
        }
    }
}
