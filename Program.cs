using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Program
{
    class Program
    {
        static int width = 32; // Get map width
        static int height = 32; // Get map height
        static int density = 15; // % of map that is not traversable
        static int process = 0; // Search algorithm
        public static bool allowDiagonal = false; // Toggle diagonal neighbours

        static Random random;
        static Point startPosition;
        static Point endPosition;
        static Block[,] map;
        static List<Block> path;
        static Block start;
        static Block end;
       
        static Stopwatch setneighbours;
        static Stopwatch processWatch;

        static void Main()
        {
            Console.Clear();
            random = new Random();
            CreateMap();
        }
        static void CreateMap()
        {
            width = Console.WindowWidth / 2;
            height = Console.WindowHeight - 15;
            map = new Block[width, height];

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    map[x, y] = new Block(x, y);
                    map[x, y].Position = new Point(x, y);
                }
            }
            LitterMap();
        }
        static void LitterMap()
        {
            foreach (Block b in map)
            {
                int x = random.Next(0, 100);

                if (x < density && b.Position != startPosition && b.Position != endPosition)
                {
                    b.isTraversable = false;
                }
            }
            SetMapNeighbours();
        }
        static void SetMapNeighbours()
        {
            setneighbours = new Stopwatch();
            setneighbours.Start();
            foreach (Block b in map)
            {
                b.SetNeighbours(map);
            }
            setneighbours.Stop();
            SetPositions();
        }
        static void SetPositions()
        {
            startPosition = new Point(
                Math.Clamp((int)startPosition.x, 0, width - 1),
                Math.Clamp((int)startPosition.y, 0, height - 1));

            endPosition = new Point(
                Math.Clamp((int)endPosition.x, 0, width - 1),
                Math.Clamp((int)endPosition.y, 0, height - 1));

            endPosition = new Point(width - 1, height - 1);

            start = map[startPosition.x, startPosition.y];
            end = map[endPosition.x, endPosition.y];
            Pathfind();
        }
        static void Pathfind()
        {
            processWatch = new Stopwatch();
            path = new List<Block>();
            switch (process)
            {
                case 0:
                    {
                        processWatch.Start();
                        path = Pathfinding.ASTAR<Block>(start, end);
                        processWatch.Stop();
                        break;
                    }
                case 1:
                    {
                        processWatch.Start();
                        path = Pathfinding.Greedy<Block>(start, end);
                        processWatch.Stop();
                        break;
                    }
                case 2:
                    {
                        processWatch.Start();
                        path = Pathfinding.Dijkstra<Block>(start, end);
                        processWatch.Stop();
                        break;
                    }
            }
            SetSymbols();
        }
        static void SetSymbols()
        {
            foreach (Block block in map)
            {
                if (block.isTraversable)
                    block.symbol = ' ';
                else
                {
                    block.symbol = '.';
                }
            }
            foreach (Block block in path)
            {
                block.symbol = '#';
                if (block == start)
                {
                    block.symbol = 'S';
                }
                if (block == end)
                {
                    block.symbol = 'E';
                }
            }
            PrintMap();
        }
        static void PrintMap()
        {
            Console.Clear();
            for (int y = map.GetLength(1) - 1; y >= 0; y--)
            {
                System.Console.WriteLine();
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    System.Console.Write(map[x, y].symbol + " ");
                }
            }
            PrintText();
        }
        static void PrintText()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            if (path.Count < 2)
                System.Console.WriteLine("No path found");
            else
                System.Console.WriteLine("{0} steps to complete", path.Count - 1);
            System.Console.WriteLine("Memory allocation completed in {0}ms", setneighbours.ElapsedMilliseconds);
            System.Console.WriteLine("Search process completed in {0}ms", processWatch.ElapsedMilliseconds);
            System.Console.WriteLine("{0} nodes examined", Pathfinding.nodesExamined);
            System.Console.WriteLine();
            System.Console.WriteLine("1. ASTAR");
            System.Console.WriteLine("2. Greedy Best-First Search");
            System.Console.WriteLine("3. Dijkstra");
            System.Console.WriteLine("4. Toggle diagonal movement");
            System.Console.WriteLine("5. Re-seed");
            System.Console.WriteLine("6. Exit");
            System.Console.WriteLine();
            System.Console.WriteLine("Use arrow keys to move start position");
            InputMenu();
        }
        static void InputMenu()
        {
            string command = Controls.GetInput();
            Point dir = new Point();

            switch (command)
            {
                case "1":
                    {
                        process = 0;
                        Pathfind();
                        return;
                    }
                case "2":
                    {
                        process = 1;
                        Pathfind();
                        return;
                    }
                case "3":
                    {
                        process = 2;
                        Pathfind();
                        return;
                    }
                case "4":
                    {
                        allowDiagonal = !allowDiagonal;
                        SetMapNeighbours();
                        return;
                    }
                case "5":
                    {
                        CreateMap();
                        return;
                    }
                case "6":
                    {
                        return;
                    }
                case "up":
                    {
                        dir.y = 1;
                        break;
                    }
                case "down":
                    {
                        dir.y = -1;
                        break;
                    }
                case "left":
                    {
                        dir.x = -1;
                        break;
                    }
                case "right":
                    {
                        dir.x = 1;
                        break;
                    }
                default:
                    {
                        InputMenu();
                        break;
                    }
            }
            Point d = new Point(
                Math.Clamp(startPosition.x + dir.x, 0, width - 1),
                Math.Clamp(startPosition.y + dir.y, 0, height - 1));

            if (map[d.x, d.y].isTraversable)
            {
                startPosition += dir;
                SetPositions();
            }
            else 
            {
                InputMenu();
            }
        }

    }
}