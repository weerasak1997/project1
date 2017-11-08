﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game2.spriteseet

{
    public static class Texture2DEx
    {
        public static void GetData<T>(this Texture2D texture, T[,] data) where T : struct
        {
            T[] dataOneDimensions = new T[texture.Width * texture.Height];
            texture.GetData(dataOneDimensions);

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    data[x, y] = dataOneDimensions[x + y * texture.Width];
                }
            }
        }
    }
}
