using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game4.Manager;
using Game4.Model;
using Game4.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Game4.Object
{
    public class SecurityGruad
    {

        public Animation animetion;
        public AnimetionMenager animetionManager;
        public Vector2 _position;
        public Texture2D _texture;
        public bool isRemoved;

        #region Properties
        public Dictionary<string, Animation> _animetions;
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

        public Vector2 Velocity;
        public int Smallest,Farest,Speed,chack;
        public String over = "Begin" ;
        public Game1 game;

        #endregion

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (_texture != null)
            {
                spriteBatch.Draw(_texture, Position, Color.White);
            }
            else if (animetionManager != null)
                animetionManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");
        }

        public SecurityGruad(Dictionary<string, Animation> animetions)
        {
            _animetions = animetions;
            animetionManager = new AnimetionMenager(_animetions.First().Value);
        }

        protected virtual void setAnimetion()
        {
            if (Velocity.X > 0)
                animetionManager.Play(_animetions["WalkRight"]);
            else if (Velocity.X < 0)
                animetionManager.Play(_animetions["WalkLeft"]);
            else if (Velocity.Y > 0)
                animetionManager.Play(_animetions["WalkDown"]);
            else if (Velocity.Y < 0)
                animetionManager.Play(_animetions["WalkUp"]);
        }

        public SecurityGruad(Texture2D texture)
        {
            _texture = texture;
        }
        
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
           
            if (chack == 1)
            {
                Velocity.X = Speed;
                if (Position.X > Farest) {

                    Speed = -Speed;
                    Velocity.X = -Speed;

                }
                    
                if (Position.X <= Smallest)

                    Speed = -Speed;
                    Velocity.X = Speed;

            }
            else
            {
                Velocity.Y = +Speed;
                if (Position.Y > Smallest)
                    Speed = -Speed;
                Velocity.Y = -Speed;

                if (Position.Y < Farest)
                    Speed = -Speed;
                Velocity.Y = Speed;
            }
            animetionManager.Update(gameTime);
            setAnimetion();
                foreach (var sprite in sprites)
                {

                    if ((this.Velocity.X > 0 && this.IsTouchingleft(sprite)) ||
                        (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                    over = "Over";
                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                       (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                    over = "Over";
                }

            Position += Velocity;
            Velocity = Vector2.Zero;
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
            return this.Rectangle.Right  > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Left +50&&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingRight(Sprite sprite)
        {
            return this.Rectangle.Left < sprite.Rectangle.Right+50 &&
                  this.Rectangle.Right > sprite.Rectangle.Right &&
                  this.Rectangle.Bottom > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Bottom;
        }
        protected bool IsTouchingTop(Sprite sprite)
        {
            return this.Rectangle.Bottom  > sprite.Rectangle.Top &&
                  this.Rectangle.Top < sprite.Rectangle.Top &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }
        protected bool IsTouchingBottom(Sprite sprite)
        {
            return this.Rectangle.Top  < sprite.Rectangle.Bottom &&
                  this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
                  this.Rectangle.Right > sprite.Rectangle.Left &&
                  this.Rectangle.Left < sprite.Rectangle.Right;
        }

        #endregion
    }
}
