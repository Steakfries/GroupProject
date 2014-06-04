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
            LoadGrid();
        }

        public void MakeSprite()
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

        public void LoadGrid()
        {
            Matrix[0, 0] = true;
            Matrix[0, 1] = true;
            Matrix[0, 2] = true;
            Matrix[0, 3] = true;
            Matrix[0, 4] = true;
            Matrix[0, 5] = true;
            Matrix[0, 6] = true;
            Matrix[0, 7] = true;
            Matrix[0, 8] = true;
            Matrix[0, 9] = true;
            Matrix[1, 3] = true;
            Matrix[1, 5] = true;
            Matrix[1, 9] = true;
            Matrix[2, 0] = true;
            Matrix[2, 3] = true;
            Matrix[2, 5] = true;
            Matrix[2, 9] = true;
            Matrix[3, 0] = true;
            Matrix[3, 5] = true;
            Matrix[3, 6] = true;
            Matrix[3, 9] = true;
            Matrix[4, 0] = true;
            Matrix[4, 1] = true;
            Matrix[4, 2] = true;
            Matrix[4, 3] = true;
            Matrix[4, 5] = true;
            Matrix[4, 9] = true;
            Matrix[5, 0] = true;
            Matrix[5, 1] = true;
            Matrix[5, 2] = true;
            Matrix[5, 3] = true;
            Matrix[5, 5] = true;
            Matrix[5, 6] = true;
            Matrix[5, 7] = true;
            Matrix[5, 9] = true;
            Matrix[6, 0] = true;
            Matrix[6, 9] = true;
            Matrix[7, 0] = true;
            Matrix[7, 2] = true;
            Matrix[7, 3] = true;
            Matrix[7, 4] = true;
            Matrix[7, 5] = true;
            Matrix[7, 6] = true;
            Matrix[7, 7] = true;
            Matrix[7, 9] = true;
            Matrix[8, 0] = true;
            Matrix[8, 9] = true;
            Matrix[9, 0] = true;
            Matrix[9, 1] = true;
            Matrix[9, 2] = true;
            Matrix[9, 3] = true;
            Matrix[9, 4] = true;
            Matrix[9, 6] = true;
            Matrix[9, 7] = true;
            Matrix[9, 8] = true;
            Matrix[9, 9] = true;
        }
    }
}
