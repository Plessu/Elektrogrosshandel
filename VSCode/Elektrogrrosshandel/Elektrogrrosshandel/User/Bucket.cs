// """

using Elektrogrosshandel.Hardware;
using Spectre.Console;

namespace Elektrogrosshandel.User
{
    internal class Bucket
    {
        public int BucketID { get; set; }
        private double BucketValue { get; set; }
        private string BucketName { get; set; }
        private DateTime CreatedAt { get; set; }
        private List<Hardware.ComputerHardware> Articels { get; set; }
        private List<int> Quantity { get; set; }
        private List<Int64> ArticelIDs { get; set; }


        private static List<int> UsedBucketIDs = new List<int>();

        public  Bucket(int bucketID, double bucketValue, string bucketName, DateTime createdAt, List<Hardware.ComputerHardware> articels, List<int> quantity)
        {
            BucketID = bucketID;
            BucketValue = bucketValue;
            BucketName = bucketName;
            CreatedAt = createdAt;
            Articels = articels;
            Quantity = quantity;
        }

        private Bucket(int bucketID, string bucketName, double bucketValue)
        {
            BucketID = bucketID;
            BucketValue = bucketValue;
            BucketName = bucketName;

            CreatedAt = DateTime.Now;
            Articels = new List<Hardware.ComputerHardware>();
            Quantity = new List<int>();
            ArticelIDs = new List<Int64>();

        }

        public static bool AddArticelToBucket(Bucket bucket, Int64 articelID, int quantity)
        {
            ComputerHardware articel = ComputerHardware.GetArticelByID(articelID);
            if (articel == null)
            {
                return false;
            }
            else
            {

                if (bucket.ArticelIDs.Contains(articelID))
                {
                    int index = bucket.Articels.IndexOf(articel);
                    bucket.Quantity[index] += quantity;
                }
                else
                {
                    Hardware.ComputerHardware bucketHardware = Hardware.ComputerHardware.GetArticelByID(articelID);
                    bucket.ArticelIDs.Add(articelID);
                    bucket.Articels.Add(bucketHardware);
                    bucket.Quantity.Add(quantity);
                }

                bucket.BucketValue += ComputerHardware.GetArticelPriceByID(articelID) * quantity;

                return true;
            }
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

        public static double GetBucketValue(Bucket bucket)
        {
            return bucket.BucketValue;
        }

        public static void ChangeBucketName(Bucket bucket, string newBucketName)
        {
            bucket.BucketName = newBucketName;
        }

        public Markup GetBucketInformation()
        {
            return new Markup($"[bold yellow]Bucket ID:[/] {BucketID} | [bold yellow]Bucket Name:[/] {BucketName}");
        }

        public static List<Markup> GetArticelsInBucket(Bucket bucket)
        {
            List<Markup> articelsInBucket = new List<Markup>();

            articelsInBucket.Add(new Markup($"[yellow]BucketID:[/] {bucket.BucketID}  [yellow]Bucket Name:[/] {bucket.BucketName}\n[bold blue underline]Articels in Bucket[/]"));

            foreach (ComputerHardware articel in bucket.Articels)
            {
                int index = bucket.Articels.IndexOf(articel);
                int quantity = bucket.Quantity[index];
                Markup articelInfo = new Markup($"[bold yellow]Articel Name:[/] {ComputerHardware.GetArticelName(articel)}\n[bold yellow]Quantity:[/] {quantity}\n[bold yellow]Price per unit:[/] {ComputerHardware.GetArticelPriceByHardware(articel)}\n[bold yellow]Total Price:[/] {ComputerHardware.GetArticelPriceByHardware(articel) * quantity}\n");
                articelsInBucket.Add(articelInfo);
            }

            return articelsInBucket;
        }
    }
}
