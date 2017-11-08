﻿using System;
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
    public class Money : Sprite
    {
        public Animation animetion;
        public AnimetionMenager animetionManager;
        public Money(Texture2D texture) :base  (texture)
        {
        }

        public Money(Dictionary<string, Animation> animetions) :base (animetions)
        {
            animetionManager = new AnimetionMenager(_animetions.First().Value);
        }
        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            
        }

    }
}
