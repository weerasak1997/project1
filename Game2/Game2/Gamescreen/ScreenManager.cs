using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.Gamescreen
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Vector2 Dimension { private set; get; }
        public ContentManager Content { private set; get; }

        Gamescreen currentScreen;
        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                    instance = new ScreenManager();

                return instance;
                
            }
        }
        public ScreenManager()
        {
            Dimension = new Vector2(1800, 1400);
            currentScreen = new SplashScreen();
        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(Content.ServiceProvider, "Conternt");
            currentScreen.LoadContent();
        }
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
