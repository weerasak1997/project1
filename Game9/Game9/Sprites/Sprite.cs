

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
    public class Sprite
    {
        #region FIelds
        public Animation animetion;
        public AnimetionMenager animetionManager;
        //protected Player Player;

        public Color _color = Color.White;
        public Dictionary<string, Animation> _animetions;
        public Vector2 _position;
        public Texture2D _texture;
        public int height, width;
        public string chacktype;
        public int Scores;
        public bool isRemoved;
        public string nextState;
        #endregion

        #region Properties
        public Input Input;
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                if (animetionManager != null)
                    animetionManager.Position = _position;
            }
        }

        public float speed = 2.5f;
        public Vector2 Velocity;
        public Wall _wall;

        #endregion

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, _color);
            }
            else if (animetionManager != null)
                animetionManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Up))
            {
                MyGlobals.Velocity.Y = -speed;

            }

            else if (Keyboard.GetState().IsKeyDown(Input.Down))
            {
                MyGlobals.Velocity.Y = speed;

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                MyGlobals.Velocity.X = -speed;

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                MyGlobals.Velocity.X = speed;

            }
        }

        public Sprite(Dictionary<string, Animation> animetions)
        {
            _animetions = animetions;
            animetionManager = new AnimetionMenager(_animetions.First().Value);
        }
        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        protected virtual void setAnimetion()
        {
            if (MyGlobals.Velocity.X > 0)
                animetionManager.Play(_animetions["WalkRight"]);
            else if (MyGlobals.Velocity.X < 0)
                animetionManager.Play(_animetions["WalkLeft"]);
            else if (MyGlobals.Velocity.Y > 0)
                animetionManager.Play(_animetions["WalkDown"]);
            else if (MyGlobals.Velocity.Y < 0)
                animetionManager.Play(_animetions["WalkUp"]);
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites, List<Wall> _wall)
        {
            Move();
            setAnimetion();
            animetionManager.Update(gameTime);
            foreach (var wall in _wall)
            wall.Update(gameTime, sprites);
            Position += MyGlobals.Velocity;
            MyGlobals.Velocity = Vector2.Zero;
        
    }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, animetionManager.animation.FrameWidth, animetionManager.animation.FrameHeight);
            }
        }

        #region Collision
        protected bool IsTouchingleft(Sprite sprite)
        {
            return this.Rectangle.Right + this.Velocity.X > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Left &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left + this.Velocity.X < sprite.Rectangle.Right &&
                  this.Rectangle.Right > sprite.Rectangle.Right &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Top &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprite.Rectangle.Bottom &&
                  this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }

        #endregion
    }
}
