using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game4.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game4.Manager
{
    public class AnimetionMenager
    {
        public Animation animation;
        private float _timer;
        public Vector2 Position { get; set; }

        public AnimetionMenager(Animation animation1)
        {
            animation = animation1;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animation.Texture, Position,
                              new Rectangle(animation.currentFrame * animation.FrameWidth,
                                            0,animation.FrameWidth,animation.FrameHeight ),Color.White);
        }
        public void Play(Animation animation1)
        {
            if (animation == animation1)
                return;

            animation = animation1;
            animation.currentFrame = 0;
            _timer = 0;
        }
        public void Stop()
        {
            _timer = 0f;
            animation.currentFrame = 0;
        }
        public void Update(GameTime gameTime)
        {
            if (animation.FrameCount > 1)
            {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(_timer > animation.FrameSpeed)
            {
                _timer = 0f;
                animation.currentFrame++;

                if (animation.currentFrame >= animation.FrameCount)
                    animation.currentFrame = 0;
            }
            }
            
        }
    }
}
