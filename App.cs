using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace AI_Coursework
{
    class App
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                string data = LoadCavesFromArgs(args);
                if (data != null)
                {
                    string[] caves = data.Split(',');

                    CavesNetwork cavesNetwork = new CavesNetwork(caves);
                    PrintResults(Pathfinding.Findpath(cavesNetwork.Caves[0], cavesNetwork.Caves[cavesNetwork.NumberOfCaves - 1], cavesNetwork.NumberOfCaves), args);
                }
            }
        }
        static string LoadCavesFromArgs(string[] args)
        {
            try
            {
                string directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filepath = Path.GetFullPath(directory) + @"\" + args[0] + ".cav";
                string file = System.IO.File.ReadAllText(filepath);
                return file;
            }

            catch (FileNotFoundException)
            {
                // if file not found
                return null;
            }

        }

        static void PrintResults(List<int> path, string[] args)
        {
            if (path != null)
            {
                string directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filepath = Path.GetFullPath(directory) + @"\" + args[0] + ".csn";
                string text = string.Join<int>(" ", path);
                System.IO.File.WriteAllText(@filepath, text);
            }
            else
            {
                string directory = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                string filepath = Path.GetFullPath(directory) + @"\" + args[0] + ".csn";
                System.IO.File.WriteAllText(@filepath, "0");
            }
        }
    }
}
