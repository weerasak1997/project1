using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.game
{
    class MouseControl
    {
        


        private Texture2D texture;

        public Vector2 mousePosition;
        public Vector2 Origin;
        public void Mouse(MouseState  Mouse)
        {
            MouseState stateMouse = Mouse;

            mousePosition.X = stateMouse.X;
            mousePosition.Y = stateMouse.Y;


        }

        public MouseControl(Texture2D texture1)
        {
            texture = texture1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, mousePosition);
        }
    }
}
