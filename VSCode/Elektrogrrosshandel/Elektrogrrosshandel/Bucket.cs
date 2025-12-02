using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class Bucket
    {
        private int BucketID { get; set; }
        private int UserID { get; set; }
        private string BucketName { get; set; }
        private List<ArticleItem> ArticlesInBucket { get; set; }
        private List<int> ItemQuantity { get; set; }

        private decimal TotalPrice { get; set; }
        private static List<Bucket> buckets = new List<Bucket>();

        private static Dictionary<int, int> BucketIDs = new Dictionary<int, int>();

        private Bucket(int BucketID, int UserID, string BucketName)
        {
            string bucketID = UserID.ToString() + BucketID.ToString();
            this.BucketID = Int32.Parse(bucketID);
            this.UserID = UserID;
            this.BucketName = BucketName;
            this.ArticlesInBucket = new List<ArticleItem>();
            this.TotalPrice = 0;
        }
        private static void AddBucket(Bucket bucket)
        {
            buckets.Add(bucket);
        }
        public static void CreateBucket(int UserID, string BucketName)
        {
            int BucketSubID;
            if (BucketIDs.ContainsKey(UserID))
            {
                BucketSubID = BucketIDs[UserID] + 1;
                BucketIDs[UserID] = BucketSubID;
            }
            else
            {
                BucketSubID = 1;
                BucketIDs.Add(UserID, BucketSubID);
            }
            Bucket newBucket = new Bucket(BucketSubID, UserID, BucketName);
            AddBucket(newBucket);
        }
        public static void AddArticleToBucket(int BucketID, ArticleItem Item)
        {
            foreach (Bucket bucket in buckets)
            {
                if (bucket.BucketID == BucketID)
                {
                    bucket.ArticlesInBucket.Add(Item);
                    bucket.TotalPrice += ArticleItem.GetArticlePriceByItem(Item);
                    break;
                }
            }
        }

    }
}
