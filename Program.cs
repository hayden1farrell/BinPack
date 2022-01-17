using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BinPackTell
{
    struct Bin{
        public int Space;
        public StringBuilder Items;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //2,3,4,1,3,2,3,3,2
            Console.WriteLine("Enter Max bin size");
            int maxBinSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter packet string");
            string packetData = Console.ReadLine();
            int[] packets = packetData.Split(',').Select(n => Convert.ToInt32(n)).ToArray();

            Console.WriteLine("Number of items: " + packets.Length);

            if(packets.Max() > maxBinSize){
                Console.WriteLine("one of the inputs was to big");
                System.Environment.Exit(0);
            }

            BinPack(maxBinSize, packets);
        }

        private static void BinPack(int maxBinSize, int[] packets)
        {
            Dictionary<int, Bin> storage = new Dictionary<int, Bin>();
            Bin modifedBin = new Bin();
            Console.WriteLine("Alog starting");

            foreach (int currentPacket in packets)
            {
                bool validbin = false;

                for (int i = 1; i <= storage.Count; i++)
                {
                    if(storage[i].Space + currentPacket <= maxBinSize){
                        StringBuilder items = new StringBuilder();
                        items.Append(storage[i].Items + "," + currentPacket.ToString());
                        modifedBin.Space = storage[i].Space + currentPacket;
                        modifedBin.Items = items;
                        validbin = true;
                        storage[i] = modifedBin;
                        break;
                    }
                }
                if(validbin == false){
                    CreateNewBin(currentPacket, storage);
                }
            }


            Console.WriteLine("Complete");
            DisplayItems(storage);
        }
        static Dictionary<int, Bin> CreateNewBin(int packet, Dictionary<int, Bin> storage){
            StringBuilder items = new StringBuilder();
            items.Append(packet.ToString());
            int newBinNumber = storage.Count + 1;
            Bin newBin = new Bin(); newBin.Space = packet;
            newBin.Items = items;
            storage.Add(newBinNumber, newBin);

            return storage;
        }

        static void DisplayItems(Dictionary<int, Bin> storage){
            long binsUsed = 0;
            foreach (var item in storage)
            {
                Console.WriteLine($"Bin: {item.Key}     Space used: {item.Value.Space}      Items: {item.Value.Items}");
                binsUsed++;
            }
            Console.WriteLine("Total bins: " + binsUsed);
        }
    }
}
