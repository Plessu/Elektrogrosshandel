using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class ArticleItem
    {
        private int ArticleID { get; set; }
        private string ArticleName { get; set; }
        private string Manufacturer { get; set; }
        private string Model { get; set; }
        private int EAN { get; set; }
        private string[] ColorSelection { get; set; }
        private string Description { get; set; }
        private int[] Dimensions { get; set; }
        private int Weight { get; set; }
        private int Stock { get; set; }
        private int MinStock { get; set; }
        private int MaxStock { get; set; }
        private string[] Tags { get; set; }


        private decimal Price { get; set; }
        private ArticleGroup ArticleGroup { get; set; }

        private static List<ArticleItem> articleItems = new List<ArticleItem>();
        private static Dictionary<int, int> ArticleIDs = new Dictionary<int, int>();

        private ArticleItem(int ArticleID, string ArticleName, string Manufacturer, string Model,
            int EAN, string[] ColorSelection, string Description, int[] Dimensions, int Weight,
            int Stock, int MinStock, int MaxStock, string[] Tags, decimal Price, ArticleGroup ArticleGroup)
        {
            this.ArticleID = ArticleID;
            this.ArticleName = ArticleName;
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.EAN = EAN;
            this.ColorSelection = ColorSelection;
            this.Description = Description;
            this.Dimensions = Dimensions;
            this.Weight = Weight;
            this.Stock = Stock;
            this.MinStock = MinStock;
            this.MaxStock = MaxStock;
            this.Tags = Tags;
            this.Price = Price;
            this.ArticleGroup = ArticleGroup;   
        }

        private static void AddArticleItem(ArticleItem item)
        {
            articleItems.Add(item);
        }

        public static void CreateArticleItem(int GroupID, string ArticleName, string Manufacturer, string Model,
            int EAN, string[] ColorSelection, string Description, int[] Dimensions, int Weight,
            int Stock, int MinStock, int MaxStock, string[] Tags, decimal Price)
        {
            int ArticleSubID;
            string ArticleID = "";
            Random rnd = new Random();

            do
            {
                ArticleSubID = rnd.Next(100000, 999999);
                foreach (var id in ArticleIDs)
                {
                    if (id.Value == ArticleSubID)
                    {
                        continue;
                    }
                    else
                    {
                        ArticleIDs.Add(GroupID, ArticleSubID);
                        break;
                    }
                }
            } while (true);

            ArticleID = GroupID.ToString() + ArticleSubID.ToString();

            ArticleGroup articleGroup = ArticleGroup.GetArticleGroupByID(GroupID);

            ArticleItem newItem = new ArticleItem(Int32.Parse(ArticleID), ArticleName, Manufacturer, Model,
                    EAN, ColorSelection, Description, Dimensions, Weight,
                    Stock, MinStock, MaxStock, Tags, Price, articleGroup);

            ArticleGroup.AddArticleToGroup(newItem, GroupID);
            AddArticleItem(newItem);
        }

        public static List<ArticleItem> GetArticleItems()
        {
            return articleItems;
        }
    }
}
