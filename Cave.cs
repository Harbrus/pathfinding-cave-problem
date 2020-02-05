using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AI_Coursework
{
    public class Cave : IHeapITem<Cave>
    {
        private int caveID;
        private double xCoord;
        private double yCoord;
        private double gCost;
        private double hCost;
        private double fCost;
        private Cave parent;
        private List<Cave> neighbours;
        private int index;

        public Cave(int caveID, double xCoord, double yCoord)
        {
            this.caveID = caveID;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.neighbours = new List<Cave>();
        }

        public Cave Parent { get; set; }
        public List<Cave> Neighbours { get => neighbours; }
        public int CaveID { get => caveID;}
        public double XCoord { get => xCoord; set => xCoord = value; }
        public double YCoord { get => yCoord; set => yCoord = value; }
        public double GCost { get => gCost; set => gCost = value; }
        public double HCost { get => hCost; set => hCost = value; }
        public double FCost { get => gCost + hCost;}
        public int Index { get => index; set => index = value; }

        public void AddCaveToNeighbours(Cave neighbour)
        {
            this.neighbours.Add(neighbour);
        }

        public int CompareTo(Cave other)
        {
            int comparison = this.FCost.CompareTo(other.FCost);

            if (comparison == 0)
            {
                comparison = this.HCost.CompareTo(other.HCost);
            }

            return -comparison; // return if lower
        }
    }
}
