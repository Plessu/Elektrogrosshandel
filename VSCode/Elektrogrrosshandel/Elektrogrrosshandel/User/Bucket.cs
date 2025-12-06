using Elektrogrosshandel.Hardware;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrosshandel.User
{
    internal class Bucket
    {
        private int BucketID { get; set; }
        private double BucketValue { get; set; }
        private string BucketName { get; set; }
        private DateTime CreatedAt { get; set; }
        private List<Hardware.ComputerHardware> Articels { get; set; }
        private List<int> Quantity { get; set; }
        private List<int> ArticelIDs { get; set; }


        private static List<int> UsedBucketIDs = new List<int>();


        private Bucket(int bucketID, string bucketName, double bucketValue)
        {
            BucketID = bucketID;
            BucketValue = bucketValue;
            BucketName = bucketName;

            CreatedAt = DateTime.Now;
            Articels = new List<Hardware.ComputerHardware>();
            Quantity = new List<int>();
            ArticelIDs = new List<int>();
 
        }

        public static void AddArticelToBucket(Bucket bucket,int articelID, int quantity)
        {
            if (bucket.ArticelIDs.Contains(articelID))
            {
                int index = bucket.ArticelIDs.IndexOf(articelID);
                bucket.Quantity[index] += quantity;
            }
            else
            {
                Hardware.ComputerHardware bucketHardware = Hardware.ComputerHardware.GetArticelByID(articelID);
                bucket.ArticelIDs.Add(articelID);
                bucket.Articels.Add(bucketHardware);
            }

            bucket.BucketValue += ComputerHardware.GetArticelPriceByID(articelID) * quantity;

        }
        public static Bucket CreateBucket(int accountID, string bucketName)
        {
            int newBucketID;
            double bucketValue = 0;

            do
            {
                newBucketID = new Random().Next(100000, 999999);
            } while (UsedBucketIDs.Contains(newBucketID));

            UsedBucketIDs.Add(newBucketID);

            return new Bucket(newBucketID, bucketName, bucketValue);
        }

        public Markup GetBucketInformation()
        {
            return new Markup($"[bold yellow]Bucket ID:[/] {BucketID}\n[bold yellow]Bucket Name:[/] {BucketName}\n[bold yellow]Created At:[/] {CreatedAt}\n[bold yellow]Number of Articels:[/] {Articels.Count}");
        }
    }
}
