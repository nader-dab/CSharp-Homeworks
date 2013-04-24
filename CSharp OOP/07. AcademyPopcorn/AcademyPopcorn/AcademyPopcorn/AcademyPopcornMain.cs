using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Task 1
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock leftWall = new IndestructibleBlock(new MatrixCoords(i, 0));
                engine.AddObject(leftWall);
                IndestructibleBlock rightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(rightWall);
            }

            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock ceiling = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(ceiling);
            }

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            // Task 5, 6, 7
            MeteoriteBall meteor = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            engine.AddObject(meteor);

            // Task 8, 9
            UnstoppableBall unstoppable = new UnstoppableBall(new MatrixCoords(4,4), new MatrixCoords(1, 1));
            engine.AddObject(unstoppable);
            UnpassableBlock unpassable = new UnpassableBlock(new MatrixCoords(9, 9));
            engine.AddObject(unpassable);
            // Task 10
            ExplodingBlock explodeBlock = new ExplodingBlock( new MatrixCoords(8,8));
            engine.AddObject(explodeBlock);

            // Task 11, 12
            GiftBlock gift = new GiftBlock(new MatrixCoords(10, 10));
            engine.AddObject(gift);

        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
