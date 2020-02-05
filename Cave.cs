using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace AI_Coursework
{
    public class Cave
    {
        private int caveID;
        private double xCoord;
        private double yCoord;
        private double gCost;
        private double hCost;
        private Cave parent;
        private List<Cave> neighbours;

        public Cave(int caveID, double xCoord, double yCoord)
        {
            this.caveID = caveID;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.neighbours = new List<Cave>();
        }

        public Cave Parent { get => parent; set => parent = value; }
        public List<Cave> Neighbours { get => neighbours; }
        public int CaveID { get => caveID;}
        public double XCoord { get => xCoord; set => xCoord = value; }
        public double YCoord { get => yCoord; set => yCoord = value; }
        public double GCost { get => gCost; set => gCost = value; }
        public double HCost { get => hCost; set => hCost = value; }
        public double FCost { get => gCost + hCost;}

        public void AddCaveToNeighbours(Cave neighbour)
        {
            this.neighbours.Add(neighbour);
        }
    }
}
