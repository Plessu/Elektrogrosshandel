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

        private Bucket(int BucketID, string BucketName)
        {
            this.BucketID = BucketID;
            this.BucketName = BucketName;
            this.ArticlesInBucket = new List<ArticleItem>();
            this.TotalPrice = 0;
        }
        private static void AddBucket(Bucket bucket)
        {
            buckets.Add(bucket);
        }
        public static Bucket CreateBucket(int BucketID, string BucketName)
        {
            Bucket newBucket = new Bucket(BucketID, BucketName);
            AddBucket(newBucket);
            return newBucket;
        }
        public static void AddArticleToBucket(int BucketID, ArticleItem Item, int Quantity)
        {
            foreach (Bucket bucket in buckets)
            {
                if (bucket.BucketID == BucketID)
                {
                    if (bucket.ArticlesInBucket.Contains(Item))
                    {
                        int index = bucket.ArticlesInBucket.IndexOf(Item);
                        bucket.ItemQuantity[index] += Quantity;
                    }
                    else
                    {
                           bucket.ArticlesInBucket.Add(Item);
                           bucket.ItemQuantity.Add(Quantity);
                    }
                    bucket.TotalPrice += ArticleItem.GetArticlePriceByItem(Item) * Quantity;
                    break;
                }
            }
        }

    }
}
