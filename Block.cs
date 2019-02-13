using System.Collections.Generic;

namespace Program
{
    class Block : INode<Block>
    {
        Block[] _neighbours;
        public Block[] Neighbours { get => _neighbours; }
        public Point Position { get; set; }

        public bool isTraversable = true;
        public char symbol = ' ';
        public Block() { }
        public Block(Point position)
        {
            Position = position;
        }
        public Block(int x, int y)
        {
            Position = new Point(x, y);
        }

        public void SetNeighbours(Block[,] map)
        {
            List<Block> neighbours = new List<Block>();

            foreach (Block b in map)
            {
                if (!b.isTraversable) { continue; }

                else if (b.Position == Position + Point.up)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.down)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.left)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.right)
                {
                    neighbours.Add(b);
                }
                if (!Program.allowDiagonal) continue;

                else if (b.Position == Position + Point.up + Point.right)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.up + Point.left)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.down + Point.right)
                {
                    neighbours.Add(b);
                }
                else if (b.Position == Position + Point.down + Point.left)
                {
                    neighbours.Add(b);
                }
            }
            _neighbours = neighbours.ToArray();
        }

    }
}