using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game9.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game9.Manager
{
    public class AnimetionMenager1
    {
        public Animation1 _animation;
        private float _timer;
        public Vector2 Position { get; set; }

        public AnimetionMenager1(Animation1 animation1)
        {
            _animation = animation1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_animation.Texture, Position,
                              new Rectangle(_animation.currentFrame * _animation.FrameWidth,
                                            0, _animation.FrameWidth, _animation.FrameHeight), Color.White);
        }
        public void Play(Animation1 animation1)
        {
            if (_animation == animation1)
                return;

            _animation = animation1;
            _animation.currentFrame = 0;
            _timer = 0;
        }
        public void Stop()
        {
            _timer = 0f;
            _animation.currentFrame = 0;
        }
        public void Update(GameTime gameTime)
        {
            if (_animation.FrameCount > 1)
            {
                _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timer > _animation.FrameSpeed)
                {
                    _timer = 0f;
                    _animation.currentFrame++;

                    if (_animation.currentFrame >= _animation.FrameCount)
                        _animation.currentFrame = 0;
                }
            }

        }
    }
}
