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
    public class Dog
    {


            public Vector2 _position;
            public Texture2D _texture;
            public Texture2D _texture1;

            #region Properties
            public Dictionary<string, Animation1> _animetions;
            public Input Input;
            public Vector2 Position;

            public Vector2 Velocity;
            public int Smallest, Farest, chack;
            public float Speed;
            public Game1 game;
             public int chackBody = 1;

            #endregion

            public virtual void Draw(SpriteBatch spriteBatch)
            {

                spriteBatch.Draw(_texture, Position, Color.White);

            }



            public Dog(Texture2D texture, Texture2D texture2)
            {
                _texture = texture;
                _texture1 = texture2;
            }

            public virtual void Update(GameTime gameTime, List<Sprite> sprites)
            {
                foreach (var sprite in sprites)
                {
                if (sprite.Rectangle.Intersects(this.Rectangle) && this.chackBody == 1)
                    {
                        if (MyGlobals.chackBone <= 0)
                        {
                            MyGlobals.Over = "Over";

                        }
                        else
                        {
                            MyGlobals.chackBone -= 1;
                            this._texture = _texture1;
                            this.chackBody = 2;
                        }

                    }

                }


                Position += Velocity;
                Velocity = Vector2.Zero;
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
                return this.Rectangle.Right > sprite.Rectangle.Left &&
                      this.Rectangle.Left < sprite.Rectangle.Left + 50 &&
                      this.Rectangle.Bottom > sprite.Rectangle.Top &&
                      this.Rectangle.Top < sprite.Rectangle.Bottom;
            }
            protected bool IsTouchingRight(Sprite sprite)
            {
                return this.Rectangle.Left < sprite.Rectangle.Right + 50 &&
                      this.Rectangle.Right > sprite.Rectangle.Right &&
                      this.Rectangle.Bottom > sprite.Rectangle.Top &&
                      this.Rectangle.Top < sprite.Rectangle.Bottom;
            }
            protected bool IsTouchingTop(Sprite sprite)
            {
                return this.Rectangle.Bottom > sprite.Rectangle.Top &&
                      this.Rectangle.Top < sprite.Rectangle.Top &&
                      this.Rectangle.Right > sprite.Rectangle.Left &&
                      this.Rectangle.Left < sprite.Rectangle.Right;
            }
            protected bool IsTouchingBottom(Sprite sprite)
            {
                return this.Rectangle.Top < sprite.Rectangle.Bottom &&
                      this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                      this.Rectangle.Right > sprite.Rectangle.Left &&
                      this.Rectangle.Left < sprite.Rectangle.Right;
            }

            #endregion
        }
    }


