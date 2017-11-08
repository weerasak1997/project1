using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.game
{
    public class Sprite : Input
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 Velocity1;
        public Color Colour = Color.White;
        public float speed;
        public Input Input;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            }
        }
        public Sprite(Texture2D texture1)
        {
            texture = texture1;
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Colour);
        }
        #region Collision
        protected bool IsTouchingleft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity1.X > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Left &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Right;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity1.X < sprite.Rectangle.Right &&
                  this.Rectangle.Right > sprite.Rectangle.Right &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Right;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity1.Y > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Top &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity1.Y < sprite.Rectangle.Bottom &&
                  this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }
        #endregion
    }

}
