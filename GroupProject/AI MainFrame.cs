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
        public enum AIStates{ //state enums for ai
            Patrol,
            FindPath,
            ToPatrol,
            Pursue
        };

        public AI_MainFrame() // constructor
        {

        }

        Sprites AISprite;

        int CurrentNode;

        AIStates m_State;
        LinkedList<Delegate> AI; //runs all ai functions, add several to one delegate or to a node
        LinkedList<Vector2> MovementNodes; //the path the AI will folow

        Vector2 LastPlayerLocation; //Notes the players last known location, if reached the ai will lose player and go back to patrol

        public void SetState(AIStates a_State)
        {
            //kill current state, delete nodes, delete movment, delete path
            AI.Clear();
            MovementNodes.Clear();
            m_State = a_State;
        }

        // State Delegate loader

        private void PathFinding(Vector2 a_Target) //find path function
        {
            
        }

        private void Patrol() // follows the movement nodes from one end to another, 
        {
            
            Seek();
            if (MovementNodes.ElementAt(CurrentNode) == MovementNodes.Last())
            {
                MovementNodes.Reverse();
                CurrentNode = 1;
            }
        }

        private void Pursue(Vector2 a_Target)//pursue
        {
            PathFinding(a_Target);
            Seek();
        }

        private void Seek()
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
            else if(AISprite.Position == MovementNodes.ElementAt(CurrentNode))
            {
                CurrentNode++;
            }
        }

    }
}
