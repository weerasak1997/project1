using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game9.Manager;
using Game9.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game9.Sprites
{
    public class Item
    {

        public String ChackType;
        public Vector2 Position;
        public Texture2D _texture;
        public bool isRemoved;
        public Input Input;

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            {
                spriteBatch.Draw(_texture, Position, Color.White);
            }
        }

        public Item(Texture2D textture)
        {
            _texture = textture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            foreach (var sprite in sprites)
            {
                if ((MyGlobals.Velocity.X > 0 && this.IsTouchingleft(sprite)) ||
                    (MyGlobals.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                    MyGlobals.Velocity.X = 0;
                if (Keyboard.GetState().IsKeyDown(Input.Up))
                {
                    if(ChackType == "Gold")
                    {
                    this.isRemoved = true;
                    MyGlobals.Scores += 3000;

                    }
                    if (ChackType == "Money")
                    {
                        this.isRemoved = true;
                        MyGlobals.Scores += 1000;

                    }

                }
                if ((MyGlobals.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                   (MyGlobals.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                {
                    MyGlobals.Velocity.Y = 0;
                    if (ChackType == "Gold")
                    {
                        this.isRemoved = true;
                        MyGlobals.Scores += 3000;

                    }
                    if (ChackType == "Money")
                    {
                        this.isRemoved = true;
                        MyGlobals.Scores += 1000;

                    }

                }
                  
            }
        }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        #region Collision
        protected bool IsTouchingleft(Sprite sprite)
        {

            return sprite.Rectangle.Right + MyGlobals.Velocity.X > this.Rectangle.Left &&
                  sprite.Rectangle.Left < this.Rectangle.Left &&
                  sprite.Rectangle.Bottom > this.Rectangle.Top &&
                  sprite.Rectangle.Top < this.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {

            return sprite.Rectangle.Left + MyGlobals.Velocity.X < this.Rectangle.Right &&
                  sprite.Rectangle.Right > this.Rectangle.Right &&
                  sprite.Rectangle.Bottom > this.Rectangle.Top &&
                  sprite.Rectangle.Top < this.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return sprite.Rectangle.Bottom + MyGlobals.Velocity.Y > this.Rectangle.Top &&
                  sprite.Rectangle.Top < this.Rectangle.Top &&
                  sprite.Rectangle.Right > this.Rectangle.Left &&
                  sprite.Rectangle.Left < this.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return sprite.Rectangle.Top + MyGlobals.Velocity.Y < this.Rectangle.Bottom &&
                 sprite.Rectangle.Bottom > this.Rectangle.Bottom &&
                 sprite.Rectangle.Right > this.Rectangle.Left &&
                 sprite.Rectangle.Left < this.Rectangle.Right;
        }

        #endregion
    }
}