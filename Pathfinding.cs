using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Coursework
{
    public static class Pathfinding
    {
        private static List<int> path;

        public static List<int> Findpath(Cave startCave, Cave endCave)
        {
            List<Cave> openList = new List<Cave>();
            HashSet<Cave> visitedSet = new HashSet<Cave>();
            openList.Add(startCave);

            while (openList.Count > 0)
            {
                Cave current = openList[0];

                for (int i = 0; i < openList.Count; i++)
                {
                    if (openList[i].FCost < current.FCost || openList[i].FCost == current.FCost)
                    {
                        if (openList[i].HCost < current.HCost)
                        {
                            current = openList[i];
                        }
                    }
                }

                openList.Remove(current);
                visitedSet.Add(current);

                if (current == endCave)
                {
                    path = new List<int>();
                    GetPath(startCave, endCave);
                    return path;
                }

                if(current.Neighbours == null)
                {
                    continue;
                }

                foreach (Cave neighbour in current.Neighbours)
                {
                    if (visitedSet.Contains(neighbour))
                    {
                        continue;
                    }

                    double newGCostNeighbour = current.GCost + CalculateDistance(neighbour, current);

                    if (newGCostNeighbour < neighbour.GCost || !openList.Contains(neighbour))
                    {
                        neighbour.GCost = newGCostNeighbour;
                        neighbour.HCost = CalculateDistance(neighbour, endCave);
                        neighbour.Parent = current;

                        if (!openList.Contains(neighbour))
                            openList.Add(neighbour);
                    }
                }
            }
            return path;
        }

        public static void GetPath(Cave startCave, Cave endCave)
        {
            Cave currentCave = endCave;

            while (currentCave != startCave)
            {
                path.Add(currentCave.CaveID);

                currentCave = currentCave.Parent;
            }
            path.Add(startCave.CaveID);
            path.Reverse();
        }

        public static double CalculateDistance(Cave from, Cave to)
        {
            return (Math.Sqrt(Math.Pow(from.XCoord - to.XCoord, 2) + Math.Pow(from.YCoord - to.YCoord, 2)));
        }
    }
}
