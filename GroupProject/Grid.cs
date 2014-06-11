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

        public Vector2 GetSquare(float a_X, float a_Y)
        {
            return new Vector2(a_X / 50, a_Y / 50);
        }

        public Vector2 GetSquare(int a_X, int a_Y)
        {
            return new Vector2((int)(a_X / 50), (int)(a_Y / 50));
        }

        public void LoadGrid(int L)
        {
            Matrix = new bool[m_width, m_height];
            if (L == 0)
            {
                Matrix[2, 1] = true;
                Matrix[2, 2] = true;
                Matrix[2, 3] = true;
                Matrix[2, 4] = true;
                Matrix[2, 5] = true;
                Matrix[2, 6] = true;
                Matrix[2, 7] = true;
                Matrix[2, 8] = true;
                Matrix[2, 9] = true;
                Matrix[2, 10] = true;
                Matrix[3, 1] = true;
                Matrix[3, 4] = true;
                Matrix[3, 6] = true;
                Matrix[3, 10] = true;
                Matrix[4, 1] = true;
                Matrix[4, 4] = true;
                Matrix[4, 6] = true;
                Matrix[4, 10] = true;
                Matrix[5, 1] = true;
                Matrix[5, 6] = true;
                Matrix[5, 7] = true;
                Matrix[5, 10] = true;
                Matrix[6, 1] = true;
                Matrix[6, 2] = true;
                Matrix[6, 3] = true;
                Matrix[6, 4] = true;
                Matrix[6, 6] = true;
                Matrix[6, 10] = true;
                Matrix[7, 1] = true;
                Matrix[7, 2] = true;
                Matrix[7, 3] = true;
                Matrix[7, 4] = true;
                Matrix[7, 6] = true;
                Matrix[7, 7] = true;
                Matrix[7, 8] = true;
                Matrix[7, 10] = true;
                Matrix[8, 1] = true;
                Matrix[8, 10] = true;
                Matrix[9, 1] = true;
                Matrix[9, 3] = true;
                Matrix[9, 4] = true;
                Matrix[9, 5] = true;
                Matrix[9, 6] = true;
                Matrix[9, 7] = true;
                Matrix[9, 8] = true;
                Matrix[9, 10] = true;
                Matrix[10, 1] = true;
                Matrix[10, 10] = true;
                Matrix[11, 1] = true;
                Matrix[11, 2] = true;
                Matrix[11, 3] = true;
                Matrix[11, 4] = true;
                Matrix[11, 5] = false;
                Matrix[11, 6] = true;
                Matrix[11, 7] = true;
                Matrix[11, 8] = true;
                Matrix[11, 9] = true;
                Matrix[11, 10] = true;
                Matrix[12, 1] = true;
                Matrix[12, 10] = true;
                Matrix[13, 1] = true;
                Matrix[13, 3] = true;
                Matrix[13, 4] = true;
                Matrix[13, 7] = true;
                Matrix[13, 8] = true;
                Matrix[13, 10] = true;
                Matrix[14, 1] = true;
                Matrix[14, 10] = true;
                Matrix[15, 1] = true;
                Matrix[15, 3] = true;
                Matrix[15, 4] = true;
                Matrix[15, 5] = true;
                Matrix[15, 6] = true;
                Matrix[15, 7] = true;
                Matrix[15, 8] = true;
                Matrix[15, 10] = true;
                Matrix[16, 1] = true;
                Matrix[16, 6] = true;
                Matrix[16, 10] = true;
                Matrix[17, 1] = true;
                Matrix[17, 3] = true;
                Matrix[17, 4] = true;
                Matrix[17, 5] = true;
                Matrix[17, 6] = true;
                Matrix[17, 8] = true;
                Matrix[17, 10] = true;
                Matrix[18, 1] = true;
                Matrix[18, 6] = true;
                Matrix[18, 10] = true;
                Matrix[19, 1] = true;
                Matrix[19, 3] = true;
                Matrix[19, 4] = true;
                Matrix[19, 6] = true;
                Matrix[19, 8] = true;
                Matrix[19, 9] = true;
                Matrix[19, 10] = true;
                Matrix[20, 1] = true;
                Matrix[20, 3] = true;
                Matrix[20, 6] = true;
                Matrix[20, 9] = true;
                Matrix[20, 10] = true;
                Matrix[21, 1] = true;
                Matrix[21, 2] = true;
                Matrix[21, 3] = true;
                Matrix[21, 4] = true;
                Matrix[21, 5] = true;
                Matrix[21, 6] = true;
                Matrix[21, 7] = true;
                Matrix[21, 8] = true;
                Matrix[21, 9] = true;
                Matrix[21, 10] = true;
            }

            if (L == 1)
            {
                Matrix[2, 1] = true;
                Matrix[2, 2] = true;
                Matrix[2, 3] = true;
                Matrix[2, 4] = true;
                Matrix[2, 5] = true;
                Matrix[2, 6] = true;
                Matrix[2, 7] = true;
                Matrix[2, 8] = true;
                Matrix[2, 9] = true;
                Matrix[2, 10] = true;
                Matrix[3, 1] = true;
                Matrix[3, 8] = true;
                Matrix[3, 9] = true;
                Matrix[3, 10] = true;
                Matrix[4, 1] = true;
                Matrix[4, 4] = true;
                Matrix[4, 6] = true;
                Matrix[4, 8] = true;
                Matrix[4, 9] = true;
                Matrix[4, 10] = true;
                Matrix[5, 1] = true;
                Matrix[5, 4] = true;
                Matrix[5, 8] = true;
                Matrix[5, 9] = true;
                Matrix[5, 10] = true;
                Matrix[6, 1] = true;
                Matrix[6, 2] = true;
                Matrix[6, 3] = true;
                Matrix[6, 4] = true;
                Matrix[6, 6] = true;
                Matrix[6, 8] = true;
                Matrix[6, 10] = true;
                Matrix[7, 1] = true;
                Matrix[7, 2] = true;
                Matrix[7, 4] = true;
                Matrix[7, 8] = true;
                Matrix[7, 10] = true;
                Matrix[8, 1] = true;
                Matrix[8, 2] = true;
                Matrix[8, 4] = true;
                Matrix[8, 5] = true;
                Matrix[8, 6] = true;
                Matrix[8, 10] = true;
                Matrix[9, 1] = true;
                Matrix[9, 8] = true;
                Matrix[9, 10] = true;
                Matrix[10, 1] = true;
                Matrix[10, 3] = true;
                Matrix[10, 4] = true;
                Matrix[10, 5] = true;
                Matrix[10, 10] = true;
                Matrix[11, 1] = true;
                Matrix[11, 7] = true;
                Matrix[11, 8] = true;
                Matrix[11, 9] = true;
                Matrix[11, 10] = true;
                Matrix[12, 1] = true;
                Matrix[12, 2] = true;
                Matrix[12, 3] = true;
                Matrix[12, 4] = true;
                Matrix[12, 6] = true;
                Matrix[12, 7] = true;
                Matrix[12, 8] = true;
                Matrix[12, 9] = true;
                Matrix[12, 10] = true;
                Matrix[13, 1] = true;
                Matrix[13, 10] = true;
                Matrix[14, 1] = true;
                Matrix[14, 3] = true;
                Matrix[14, 4] = true;
                Matrix[14, 7] = true;
                Matrix[14, 8] = true;
                Matrix[14, 10] = true;
                Matrix[15, 1] = true;
                Matrix[15, 10] = true;
                Matrix[16, 1] = true;
                Matrix[16, 2] = true;
                Matrix[16, 3] = true;
                Matrix[16, 5] = true;
                Matrix[16, 6] = true;
                Matrix[16, 7] = true;
                Matrix[16, 8] = true;
                Matrix[16, 10] = true;
                Matrix[17, 1] = true;
                Matrix[17, 5] = true;
                Matrix[17, 10] = true;
                Matrix[18, 1] = true;
                Matrix[18, 3] = true;
                Matrix[18, 5] = true;
                Matrix[18, 6] = true;
                Matrix[18, 7] = true;
                Matrix[18, 8] = true;
                Matrix[18, 10] = true;
                Matrix[19, 1] = true;
                Matrix[19, 5] = true;
                Matrix[19, 10] = true;
                Matrix[20, 1] = true;
                Matrix[20, 2] = true;
                Matrix[20, 3] = true;
                Matrix[20, 5] = true;
                Matrix[20, 6] = true;
                Matrix[20, 7] = true;
                Matrix[20, 8] = true;
                Matrix[20, 10] = true;
                Matrix[21, 1] = true;
                Matrix[21, 2] = true;
                Matrix[21, 3] = true;
                Matrix[21, 4] = true;
                Matrix[21, 5] = true;
                Matrix[21, 6] = true;
                Matrix[21, 7] = true;
                Matrix[21, 8] = true;
                Matrix[21, 9] = true;
                Matrix[21, 10] = true;
            }
            if (L == 2)
            {
                Matrix[2, 1] = true;
                Matrix[2, 2] = true;
                Matrix[2, 3] = true;
                Matrix[2, 4] = true;
                Matrix[2, 5] = true;
                Matrix[2, 6] = true;
                Matrix[2, 7] = true;
                Matrix[2, 8] = true;
                Matrix[2, 9] = true;
                Matrix[2, 10] = true;
                Matrix[3, 1] = true;
                Matrix[3, 4] = true;
                Matrix[3, 10] = true;
                Matrix[4, 1] = true;
                Matrix[4, 4] = true;
                Matrix[4, 6] = true;
                Matrix[4, 8] = true;
                Matrix[4, 10] = true;
                Matrix[5, 1] = true;
                Matrix[5, 4] = true;
                Matrix[5, 5] = true;
                Matrix[5, 8] = true;
                Matrix[5, 10] = true;
                Matrix[6, 1] = true;
                Matrix[6, 4] = true;
                Matrix[6, 8] = true;
                Matrix[6, 10] = true;
                Matrix[7, 1] = true;
                Matrix[7, 4] = true;
                Matrix[7, 10] = true;
                Matrix[8, 1] = true;
                Matrix[8, 4] = true;
                Matrix[8, 7] = true;
                Matrix[8, 8] = true;
                Matrix[8, 10] = true;
                Matrix[9, 1] = true;
                Matrix[9, 4] = true;
                Matrix[9, 6] = true;
                Matrix[9, 10] = true;
                Matrix[10, 1] = true;
                Matrix[10, 4] = true;
                Matrix[10, 5] = true;
                Matrix[10, 6] = true;
                Matrix[10, 8] = true;
                Matrix[10, 10] = true;
                Matrix[11, 1] = true;
                Matrix[11, 4] = true;
                Matrix[11, 10] = true;
                Matrix[12, 1] = true;
                Matrix[12, 4] = true;
                Matrix[12, 5] = true;
                Matrix[12, 6] = true;
                Matrix[12, 8] = true;
                Matrix[12, 10] = true;
                Matrix[13, 1] = true;
                Matrix[13, 6] = true;
                Matrix[13, 10] = true;
                Matrix[14, 1] = true;
                Matrix[14, 3] = true;
                Matrix[14, 4] = true;
                Matrix[14, 6] = true;
                Matrix[14, 7] = true;
                Matrix[14, 8] = true;
                Matrix[14, 10] = true;
                Matrix[15, 1] = true;
                Matrix[15, 6] = true;
                Matrix[15, 10] = true;
                Matrix[16, 1] = true;
                Matrix[16, 3] = true;
                Matrix[16, 4] = true;
                Matrix[16, 6] = true;
                Matrix[16, 7] = true;
                Matrix[16, 8] = true;
                Matrix[16, 10] = true;
                Matrix[17, 1] = true;
                Matrix[17, 6] = true;
                Matrix[17, 10] = true;
                Matrix[18, 1] = true;
                Matrix[18, 3] = true;
                Matrix[18, 4] = true;
                Matrix[18, 6] = true;
                Matrix[18, 8] = true;
                Matrix[18, 10] = true;
                Matrix[19, 1] = true;
                Matrix[19, 6] = true;
                Matrix[19, 10] = true;
                Matrix[20, 1] = true;
                Matrix[20, 3] = true;
                Matrix[20, 4] = true;
                Matrix[20, 8] = true;
                Matrix[20, 9] = true;
                Matrix[20, 10] = true;
                Matrix[21, 1] = true;
                Matrix[21, 2] = true;
                Matrix[21, 3] = true;
                Matrix[21, 4] = true;
                Matrix[21, 5] = true;
                Matrix[21, 6] = true;
                Matrix[21, 7] = true;
                Matrix[21, 8] = true;
                Matrix[21, 9] = true;
                Matrix[21, 10] = true;
            }
        }
    }
}
