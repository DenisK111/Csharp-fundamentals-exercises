using Snake_Game_OOP.Contracts;
using Snake_Game_OOP.Dots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP
{
    public class Body
    {
        private readonly LinkedList<LinkedListNode<IDot>> body;


        public Body(InitialCoordinates coordinates)
        {
            this.body = new LinkedList<LinkedListNode<IDot>>();
            Generate(coordinates);
        }

        public LinkedList<LinkedListNode<IDot>> BodyOutput => body;

        public void AddDot(ConsoleKeyInfo direction, LinkedListNode<LinkedListNode<IDot>> lastDot)
        {
            if (direction.Key == ConsoleKey.UpArrow)
            {

                body.AddLast(new LinkedListNode<IDot>(new BodyDot(lastDot.Value.Value.X, lastDot.Value.Value.Y + 1)));
                if (body.Last.Value.Value.Y == GlobalConstants.lowerBorder)
                {
                    body.Last.Value.Value.Y = GlobalConstants.upperBorder;
                }
            }

            else if (direction.Key == ConsoleKey.DownArrow)
            {

                body.AddLast(new LinkedListNode<IDot>(new BodyDot(lastDot.Value.Value.X, lastDot.Value.Value.Y - 1)));
                if (body.Last.Value.Value.Y < GlobalConstants.upperBorder)
                {
                    body.Last.Value.Value.Y = GlobalConstants.lowerBorder - 1;
                }
            }
            else if (direction.Key == ConsoleKey.RightArrow)
            {

                body.AddLast(new LinkedListNode<IDot>(new BodyDot(lastDot.Value.Value.X - 1, lastDot.Value.Value.Y)));
                if (body.Last.Value.Value.X == GlobalConstants.leftBorder)
                {
                    body.Last.Value.Value.X = GlobalConstants.rightBorder - 1;
                }
            }
            else if (direction.Key == ConsoleKey.LeftArrow)
            {

                body.AddLast(new LinkedListNode<IDot>(new BodyDot(lastDot.Value.Value.X + 1, lastDot.Value.Value.Y)));
                if (body.Last.Value.Value.X > GlobalConstants.rightBorder)
                {
                    body.Last.Value.Value.X = GlobalConstants.leftBorder;
                }
            }

        }

        private void Generate(InitialCoordinates coordinates)
        {

            body.AddFirst(new LinkedListNode<IDot>(new SnakeHead(coordinates.CursorPositionX, coordinates.CursorPositionY)));

            for (int i = 0; i < GlobalConstants.initialBodyLength; i++)
            {
                body.AddLast(new LinkedListNode<IDot>(new BodyDot(coordinates.CursorPositionX + 1 + i, coordinates.CursorPositionY)));
            }


        }
    }
}
