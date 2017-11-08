using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game2.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2.game
{
    public class Sprite : Input
    {

        #region FIelds

        public Animation animetion;
        public AnimetionMenager animetionManager;
        //protected Player Player;

        public Dictionary<string, Animation> _animetions;
        public Vector2 _position;
        public Texture2D _texture;
        public int height, width;
        #endregion


        public Texture2D texture;
        public Vector2 Velocity1;
        public Color Colour = Color.White;
        public float speed;
        public Input Input;
        
       
        //move
        public Vector2 Origin;
        public float rotation;
        public float RotationVexlocity = 3f;
        public float LinearVerocity = 10f;
        //move

        public Player player;

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

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }
        public Sprite(Texture2D texture1)
        {
            texture = texture1;
        }
        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            animetionManager.Update(gameTime);

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (texture != null)
            {
                spriteBatch.Draw(texture, Position, null, Colour, rotation, Origin, 1, SpriteEffects.None, 0f);
            }
            else if (animetionManager != null)
                animetionManager.Draw(spriteBatch);
            else throw new Exception("This ain't right..!");

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

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
                rotation -= MathHelper.ToRadians(RotationVexlocity);
            if (Keyboard.GetState().IsKeyDown(Input.Right))
                rotation += MathHelper.ToRadians(RotationVexlocity);
            var direction = new Vector2((float)Math.Cos(MathHelper.ToRadians(90) - rotation), -(float)Math.Sin(MathHelper.ToRadians(90) - rotation));
            if (Keyboard.GetState().IsKeyDown(Input.Up))
                Velocity1 = direction * LinearVerocity;
            if (Keyboard.GetState().IsKeyDown(Input.Down))
                Velocity1 = -direction * LinearVerocity;
        }
        protected virtual void setAnimetion()
        {
            if (Velocity1.X > 0)
                animetionManager.Play(_animetions["WalkRight"]);
            else if (Velocity1.X < 0)
                animetionManager.Play(_animetions["WalkLeft"]);
            else if (Velocity1.Y > 0)
                animetionManager.Play(_animetions["WalkDown"]);
            else if (Velocity1.Y < 0)
                animetionManager.Play(_animetions["WalkUp"]);
        }
        public Sprite(Dictionary<string, Animation> animetions)
        {
            _animetions = animetions;
            animetionManager = new AnimetionMenager(_animetions.First().Value);
        }
        
    }

}
