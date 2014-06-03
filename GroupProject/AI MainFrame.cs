using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GroupProject
{
    class AI_MainFrame
    {

        /*public enum AIStates{ //state enums for ai
            Patrol,
            FindPath,
            ToPatrol,
            Pursue
        };*/

        public AI_MainFrame(Vector2 a_PatrolStart, Vector2 a_PatrolEnd, Vector2 a_Position, Grid a_Grid) // constructor
        {
            AISprite = new Enemy(50, 50, .2f);
            AISprite.Position = a_Position;

            MovementNodes = new LinkedList<Vector2>();

            MovementNodes.AddFirst(a_PatrolStart * 50);
            MovementNodes.AddLast(a_Position);

            PathFinding(a_PatrolEnd, a_Grid);

        }

        public Enemy AISprite;

        int CurrentNode;

        Vector2 m_CurrentPlace;

        LinkedList<Vector2> MovementNodes; //the path the AI will folow

        // State Delegate loader

        private void PathFinding(Vector2 a_Target, Grid a_Grid) //find path function
        {
            m_CurrentPlace = new Vector2(AISprite.Position.X / 50, AISprite.Position.Y / 50);

            Vector2 PreviousPlace = MovementNodes.ElementAt(0);
            Vector2 NextPlace = m_CurrentPlace;

            MovementNodes.AddFirst(m_CurrentPlace * 50);

            while (m_CurrentPlace != a_Target)
            {
                if (Math.Abs(m_CurrentPlace.X - a_Target.X) > Math.Abs(m_CurrentPlace.Y - a_Target.Y))
                {
                    if (m_CurrentPlace.X < a_Target.X && new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y) != PreviousPlace)
                    {
                        if (m_CurrentPlace.Y > a_Target.Y && new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1) != PreviousPlace)
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "RIGHT", "UP");
                        }
                        else
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "RIGHT", "DOWN");
                        }

                    }

                    else if (m_CurrentPlace.X > a_Target.X && new Vector2(m_CurrentPlace.X - 1, m_CurrentPlace.Y) != PreviousPlace)
                    {
                        if (m_CurrentPlace.Y > a_Target.Y && new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1) != PreviousPlace)
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "LEFT", "UP");
                        }
                        else
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "LEFT", "DOWN");
                        }

                    }
                }

                else
                {
                    if (m_CurrentPlace.Y > a_Target.Y && new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1) != PreviousPlace)
                    {
                        if (m_CurrentPlace.X < a_Target.X && new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y) != PreviousPlace)
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "UP", "RIGHT");
                        }
                        else
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "UP", "LEFT");
                        }

                    }

                    else if (m_CurrentPlace.Y < a_Target.Y && new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y + 1) != PreviousPlace)
                    {
                        if (m_CurrentPlace.X > a_Target.X && new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y) != PreviousPlace)
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "DOWN", "RIGHT");
                        }
                        else
                        {
                            PreviousPlace = DirectionCheck(PreviousPlace, a_Grid, "DOWN", "LEFT");
                        }

                    }
                }

                if (PreviousPlace == m_CurrentPlace)
                    break;
            }

        }

        public void Patrol() // follows the movement nodes from one end to another, 
        {
            
            Seek();
            if (AISprite.Position == MovementNodes.Last())
            {
                //MovementNodes.Reverse();
                CurrentNode = 1;
            }
        }

        //Checks if a direction is viable for the path find function
        //the directions are UP DOWN LEFT RIGHT, and are given from the Path finding function ONLY
        private Vector2 DirectionCheck(Vector2 a_PreviousPlace, Grid a_Grid, string a_PrimeDirection, string a_SecondDirection)
        {
           Vector2 RightTile = new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y);
           Vector2 LeftTile = new Vector2(m_CurrentPlace.X - 1, m_CurrentPlace.Y);
           Vector2 UpTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1);
           Vector2 DownTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y + 1);

           Vector2 ReturnTile;

            //checks if the prime direction is clear
           if (a_Grid.Matrix[(int)RightTile.X, (int)RightTile.Y] == false && a_PrimeDirection == "RIGHT" && RightTile != a_PreviousPlace)
           {
               
               m_CurrentPlace.X += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X - 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)LeftTile.X, (int)LeftTile.Y] == false && a_PrimeDirection == "LEFT" && LeftTile != a_PreviousPlace)
           {

               m_CurrentPlace.X -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)UpTile.X, (int)UpTile.Y] == false && a_PrimeDirection == "UP" && UpTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y + 1);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)DownTile.X, (int)DownTile.Y] == false && a_PrimeDirection == "DOWN" && DownTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1);
               return ReturnTile;
           }



           if (a_Grid.Matrix[(int)RightTile.X, (int)RightTile.Y] == false && a_SecondDirection == "RIGHT" && RightTile != a_PreviousPlace)
           {

               m_CurrentPlace.X += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X - 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)LeftTile.X, (int)LeftTile.Y] == false && a_SecondDirection == "LEFT" && LeftTile != a_PreviousPlace)
           {

               m_CurrentPlace.X -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)UpTile.X, (int)UpTile.Y] == false && a_SecondDirection == "UP" && UpTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y + 1);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)DownTile.X, (int)DownTile.Y] == false && a_SecondDirection == "DOWN" && DownTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1);
               return ReturnTile;
           }



           if (a_Grid.Matrix[(int)RightTile.X, (int)RightTile.Y] == false && RightTile != a_PreviousPlace)
           {

               m_CurrentPlace.X += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X - 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)LeftTile.X, (int)LeftTile.Y] == false && LeftTile != a_PreviousPlace)
           {

               m_CurrentPlace.X -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X + 1, m_CurrentPlace.Y);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)UpTile.X, (int)UpTile.Y] == false && UpTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y -= 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y + 1);
               return ReturnTile;
           }
           else if (a_Grid.Matrix[(int)DownTile.X, (int)DownTile.Y] == false && DownTile != a_PreviousPlace)
           {

               m_CurrentPlace.Y += 1;
               MovementNodes.AddLast(m_CurrentPlace * 50);
               ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y - 1);
               return ReturnTile;
           }

           ReturnTile = new Vector2(m_CurrentPlace.X, m_CurrentPlace.Y);
           return ReturnTile;

        }

        private void Seek()//a basic seek function
        {
            
            if (AISprite.Position != MovementNodes.ElementAt(CurrentNode))
            {
                if (MovementNodes.ElementAt(CurrentNode).X < AISprite.Position.X)
                {
                    AISprite.velocity = new Vector2(-1, 0);
                }
                if (MovementNodes.ElementAt(CurrentNode).X > AISprite.Position.X)
                {
                    AISprite.velocity = new Vector2(1, 0);
                }
                if (MovementNodes.ElementAt(CurrentNode).Y < AISprite.Position.Y)
                {
                    AISprite.velocity = new Vector2(0, -1);
                }
                if (MovementNodes.ElementAt(CurrentNode).Y > AISprite.Position.Y)
                {
                    AISprite.velocity = new Vector2(0, 1);
                }
            }
            if(AISprite.Position == MovementNodes.ElementAt(CurrentNode))
            {
                CurrentNode++;
            }
        }

    }
}
