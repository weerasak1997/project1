using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game4.Manager;
using Game4.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game4.Object
{
    public class Player : Sprite
    {
        public Animation animetion;
        public AnimetionMenager animetionManager;


       public Player(Texture2D texture) :base  (texture)
        {
        }

        public Player(Dictionary<string, Animation> animetions) :base (animetions)
        {
            animetionManager = new AnimetionMenager(_animetions.First().Value);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();


            setAnimetion();
            animetionManager.Update(gameTime);
            foreach (var sprite in sprites)
            {
                if (sprite == this)
                    continue;
                if (sprite.chacktype == "wall")
                {
                    if ((this.Velocity.X > 0 && this.IsTouchingleft(sprite)) ||
                        (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                        this.Velocity.X = 0;
                    if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                       (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                        this.Velocity.Y = 0;
                }
                if (sprite.chacktype == "money")
                {
                    if ((this.Velocity.X > 0 && this.IsTouchingleft(sprite)) ||
                         (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                    {
                        this.Velocity.X = 0;
                        if (Keyboard.GetState().IsKeyDown(Input.E))
                        {
                            Scores += 1;
                            sprite.isRemoved = true;
                        }
                    }
                        
                    if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                       (this.Velocity.Y < 0 && this.IsTouchingBottom(sprite)))
                    {
                        this.Velocity.Y = 0;
                    if (Keyboard.GetState().IsKeyDown(Input.E))
                        {
                            Scores += 1;
                            sprite.isRemoved = true;
                        }

                    }
                        

                    
                }
            }
            Position += Velocity;
            Velocity = Vector2.Zero;
        }
    }
}
