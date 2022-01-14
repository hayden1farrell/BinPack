using System;
using System.Collections.Generic;
using System.Linq;

namespace BinPack
{
    struct Bin{
        public string items;
        public int BinIndex;
    }
    class Program
    {

        static void BinPack(int maxBinSize, int[] packets){
            // Dictionary where key is the number of spaces left and values are the number of bins with that amount of space
            Dictionary<int, int> binMap = new Dictionary<int, int>();

            for(int i = 0; i <= maxBinSize; i++)
                binMap.Add(i, 0);

            DisplayBins(binMap);
        }

        static void DisplayBins( Dictionary<int, int> binMap){
            foreach (var item in binMap)
                Console.WriteLine($"KEY: {item.Key} VALUE: {item.Value}");
        }
        static void Main(string[] args)
        {
            //2,3,4,1,3,2,3,3,2
            Console.WriteLine("Enter Max bin size");
            int maxBinSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter packet string");
            string packetData = Console.ReadLine();
            int[] packets = packetData.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            if(packets.Max() > maxBinSize){
                Console.WriteLine("one of the inputs was to big");
                System.Environment.Exit(0);
            }

            BinPack(maxBinSize, packets);
        }
    }
}
