using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace Game2.Gamescreen
{
    public class SplashScreen: Gamescreen
    {
        Texture2D image;
        string path;
        public override void LoadContent( )
        {
            base.LoadContent();
            image = this.content.Load<Texture2D>("getwall1");
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Vector2.Zero, Color.White);
        }
    }
}
