using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class Grid
    {
        int m_width;
        int m_height;

        public bool[,] Matrix;
        public Sprites[] GridSprites;

        public Grid(int a_width, int a_height)
        {
            Matrix = new bool[a_width, a_height];
            m_width = a_width;
            m_height = a_height;
            MakeSprite();
        }

        void MakeSprite()
        {
            Sprites[] SpriteHolder = new Sprites[m_width * m_height];
            int SpriteNumber = 0;

            for(int i = 0; i < m_width; i++)
            {
                for (int j = 0; j < m_height; j++)
                {
                    if (Matrix[i, j] == true)
                    {
                        SpriteHolder[SpriteNumber] = new Sprites(50, 50, 1f);
                        SpriteHolder[SpriteNumber].Position = new Vector2(i * 50, j * 50);
                        SpriteNumber++;
                    }
                }
            }

            GridSprites = new Sprites[SpriteNumber];

            for (int i = 0; i < SpriteNumber; i++)
            {
                GridSprites[i] = SpriteHolder[i];
            }

        }
    }
}
