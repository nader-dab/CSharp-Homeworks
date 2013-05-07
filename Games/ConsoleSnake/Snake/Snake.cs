namespace Snake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Snake
    {
        private int startPositionX = 0;
        private int startPositionY = 0;
        private Direction direction = Direction.Right;
        private int startingLength = 0;

        public Snake()
            : this(0, 0)
        {
        }

        public Snake(int startPositionX, int startPositionY)
            : this(startPositionX, startPositionY, Direction.Right)
        {
        }

        public Snake(int startPositionX, int startPositionY, Direction startingDirection)
            : this(startPositionX, startPositionY, startingDirection, 0)
        {
        }

        public Snake(int startPositionX, int startPositionY, Direction startingDirection, int startingLength)
        {
            this.startPositionX = startPositionX;
            this.startPositionY = startPositionY;
            this.Direction = startingDirection;
            this.Body = new List<BodyPart>();
            this.startingLength = startingLength;

            if (startingLength > 0)
            {
                for (int index = 0; index < startingLength; index++)
                {
                    this.AddBodyPart();
                }
            }
        }

        public List<BodyPart> Body { get; set; }

        public Direction Direction { get; set; }

        public void AddBodyPart()
        {
            if (this.Body.Count != 0)
            {
                this.Body.Add(new BodyPart(this.Body.Last().Position.X, this.Body.Last().Position.Y, '*'));
            }
            else
            {
                this.Body.Add(new BodyPart(this.startPositionX, this.startPositionY, '@'));
            }
        }

        public void Update()
        {
            if (this.Body.Count == 0)
            {
                return;
            }

            Coordinates lastBodyPartCoordinates = new Coordinates(this.Body[0].Position.X, this.Body[0].Position.Y);

            this.UpdateHead();

            if (this.Body.Count == 1)
            {
                return;
            }

            this.UpdateTail(lastBodyPartCoordinates);
        }

        public void Draw()
        {
            for (int index = 0; index < this.Body.Count; index++)
            {
                ColorConsole.SetCursorPosition(this.Body[index].Position.X, this.Body[index].Position.Y);
                ColorConsole.WriteLine(this.Body[index].Form, ConsoleColor.Green);
            }
        }

        private void UpdateHead()
        {
            switch (this.Direction)
            {
                case Direction.Up: 
                    this.Body[0].Position.Y--; 
                    break;
                case Direction.Right: 
                    this.Body[0].Position.X++; 
                    break;
                case Direction.Down: 
                    this.Body[0].Position.Y++; 
                    break;
                case Direction.Left: 
                    this.Body[0].Position.X--; 
                    break;
                default: 
                    throw new ArgumentException("Invalid direction.");
            }
        }

        private void UpdateTail(Coordinates lastBodyPartCoordinates)
        {
            for (int index = 1; index < this.Body.Count; index++)
            {
                Coordinates currentBodyPartCoordinates = new Coordinates(this.Body[index].Position.X, this.Body[index].Position.Y);
                this.Body[index].Position.X = lastBodyPartCoordinates.X;
                this.Body[index].Position.Y = lastBodyPartCoordinates.Y;
                lastBodyPartCoordinates = currentBodyPartCoordinates;
            }
        }
    }
}
