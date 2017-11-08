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
    public class Player : Sprite
    {


        public Sprite get;
       public AnimetionMenager animetionManager;
        public Player(Texture2D texture1) : base(texture1)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            setAnimetion();
            get.Update(gameTime);
            foreach (var sprite in sprites)
            {
            if(sprite == this)
            continue;
                if ((this.Velocity1.X > 0 && this.IsTouchingleft(sprite)) ||
                    (this.Velocity1.X < 0 && this.IsTouchingRight(sprite)))
                    this.Velocity1.X = 0;
                 if ((this.Velocity1.Y > 0 && this.IsTouchingTop(sprite)) ||
                    (this.Velocity1.Y < 0 && this.IsTouchingBottom(sprite)))
                    this.Velocity1.Y = 0;
            }
            Position += Velocity1;
            Velocity1 = Vector2.Zero;
        }
 
    }
}
