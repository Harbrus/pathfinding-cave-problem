using System;
using System.Collections.Generic;
using System.Text;

namespace AI_Coursework
{
    public class CavesNetwork
    {
        private Cave[] caves;
        private bool[,] cavesConnections;
        private int numberOfCaves;
        private string[] cavesData;
        private int ID = 1;
        public CavesNetwork(string[] caves)
        {
            this.cavesData = caves;
            this.numberOfCaves = Int16.Parse(this.cavesData[0]);
            this.caves = new Cave[numberOfCaves];
            CreateCaves();
            CreateCavesNetwork();
        }

        public Cave[] Caves { get => caves; }
        public int NumberOfCaves { get => numberOfCaves; }

        private void CreateCaves()
        {
            // Counter used to populate the Cave array network.
            int counter = 0;

            for (int i = 1; i < (numberOfCaves * 2) + 1; i += 2)
            {
                int xCoord = Int16.Parse(cavesData[i]);
                int yCoord = Int16.Parse(cavesData[i + 1]);
                Cave cave = new Cave(ID, xCoord, yCoord);
                caves[counter] = cave;
                ID++;
                counter++;
            }
        }

        private void CreateCavesNetwork()
        {
            int row = 0, col = 0;

            for (int curr = (numberOfCaves * 2) + 1; curr < cavesData.Length; curr++)
            {
                if (cavesData[curr].Equals("1"))
                {
                    caves[col].AddCaveToNeighbours(caves[row]);
                }

                col++;

                if (col == numberOfCaves)
                {
                    row++;
                    col = 0;
                }
            }
        }
    }
}
