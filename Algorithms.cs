using System;
using System.Collections.Generic;
using System.Linq;

namespace Program
{
    static class Pathfinding
    {
        public static int nodesExamined;
        private class Node<T> where T : INode<T>
        {
            public T data;
            public Node<T> parent;
            public float F { get => G + H; }
            public float G { get; set; }
            public float H { get; set; }

            public Node(T data)
            {
                this.data = data;
                G = System.Int32.MaxValue;
                H = System.Int32.MaxValue;
            }
            public float HCost(Node<T> end) //Start.HCOST()
            {
                Point dst = end.data.Position - data.Position;
                return MathF.Sqrt((dst.x * dst.x) + (dst.y * dst.y));
            }
            public float GCost(Node<T> start)
            {
                Point dst = data.Position - start.data.Position;
                return MathF.Sqrt((dst.x * dst.x) + (dst.y * dst.y));
            }
        }
        public static List<T> ASTAR<T>(T _start, T _end) where T : INode<T>
        {
            Node<T> start = new Node<T>(_start);
            Node<T> end = new Node<T>(_end);
            Node<T> current = start;

            if (end.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }
            if (start.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }

            List<Node<T>> openSet = new List<Node<T>>();
            List<Node<T>> closedSet = new List<Node<T>>();

            current.G = 0;
            current.H = start.HCost(end);
            openSet.Add(start);

            while (openSet.Count > 0)
            {
                openSet.Sort((x, y) => x.F.CompareTo(y.F));
                current = openSet[0];

                closedSet.Add(current);
                openSet.Remove(current);

                if (current.data.Position == end.data.Position)
                {
                    List<T> path = new List<T>();
                    while (current != start)
                    {
                        path.Add(current.data);
                        current = current.parent;
                    }
                    path.Add(start.data);
                    path.Reverse();
                    nodesExamined = closedSet.Count;
                    return path;
                }
                T[] neighbours = current.data.Neighbours;
                int length = neighbours.Length;

                //Generic class overhead
                Node<T>[] genericNeighbours = new Node<T>[length];
                for (int i = 0; i < length; i++)
                {
                    genericNeighbours[i] = new Node<T>(neighbours[i]);
                }

                foreach (Node<T> node in genericNeighbours)
                {
                    if (closedSet.Any(x => x.data.Position == node.data.Position))
                    {
                        continue;
                    }
                    else if (!openSet.Any(x => x.data.Position == node.data.Position))
                    {
                        node.parent = current;
                        node.G = current.G + node.GCost(current);
                        node.H = node.HCost(end);
                        openSet.Add(node);
                    }
                    else if (openSet.Any(x => x.data.Position == node.data.Position))
                    {
                        if (node.GCost(current) < node.G)
                        {
                            node.G = current.G + node.GCost(current);
                        }
                    }
                }
            }
            nodesExamined = closedSet.Count;
            return new List<T> { start.data };
        }
        public static List<T> Greedy<T>(T _start, T _end) where T : INode<T>
        {
            Node<T> start = new Node<T>(_start);
            Node<T> end = new Node<T>(_end);
            Node<T> current = start;

            if (end.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }
            if (start.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }

            List<Node<T>> openSet = new List<Node<T>>();
            List<Node<T>> closedSet = new List<Node<T>>();

            current.H = start.HCost(end);
            openSet.Add(start);

            while (openSet.Count > 0)
            {
                openSet.Sort((x, y) => x.H.CompareTo(y.H));
                current = openSet[0];

                closedSet.Add(current);
                openSet.Remove(current);

                if (current.data.Position == end.data.Position)
                {
                    List<T> path = new List<T>();
                    while (current != start)
                    {
                        path.Add(current.data);
                        current = current.parent;
                    }
                    path.Add(start.data);
                    path.Reverse();
                    nodesExamined = closedSet.Count;
                    return path;
                }
                T[] neighbours = current.data.Neighbours;
                int length = neighbours.Length;

                //Generic class overhead
                Node<T>[] genericNeighbours = new Node<T>[length];
                for (int i = 0; i < length; i++)
                {
                    genericNeighbours[i] = new Node<T>(neighbours[i]);
                }

                foreach (Node<T> node in genericNeighbours)
                {
                    if (closedSet.Any(x => x.data.Position == node.data.Position))
                    {
                        continue;
                    }
                    else if (!openSet.Any(x => x.data.Position == node.data.Position))
                    {
                        node.parent = current;
                        node.H = node.HCost(end);
                        openSet.Add(node);
                    }
                }
            }
            nodesExamined = closedSet.Count;
            return new List<T> { start.data };
        }
        public static List<T> Dijkstra<T>(T _start, T _end) where T : INode<T>
        {
            Node<T> start = new Node<T>(_start);
            Node<T> end = new Node<T>(_end);
            Node<T> current = start;

            if (end.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }
            if (start.data.Neighbours.Length < 1)
            {
                return new List<T> { _start };
            }
            List<Node<T>> openSet = new List<Node<T>>();
            List<Node<T>> closedSet = new List<Node<T>>();

            openSet.Add(start);

            while (openSet.Count > 0)
            {
                current = openSet[0];

                closedSet.Add(current);
                openSet.Remove(current);

                if (current.data.Position == end.data.Position)
                {
                    List<T> path = new List<T>();
                    while (current != start)
                    {
                        path.Add(current.data);
                        current = current.parent;
                    }
                    path.Add(start.data);
                    path.Reverse();
                    nodesExamined = closedSet.Count;
                    return path;
                }
                T[] neighbours = current.data.Neighbours;
                int length = neighbours.Length;

                //Generic class overhead
                Node<T>[] genericNeighbours = new Node<T>[length];
                for (int i = 0; i < length; i++)
                {
                    genericNeighbours[i] = new Node<T>(neighbours[i]);
                }

                foreach (Node<T> node in genericNeighbours)
                {
                    if (closedSet.Any(x => x.data.Position == node.data.Position))
                    {
                        continue;
                    }
                    else if (!openSet.Any(x => x.data.Position == node.data.Position))
                    {
                        node.parent = current;
                        openSet.Add(node);
                    }
                }
            }
            nodesExamined = closedSet.Count;
            return new List<T> { start.data };
        }
    }
}