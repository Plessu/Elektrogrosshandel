using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class ArticleGroup
    {
        private string ParentGroup { get; set; }
        private string GroupName { get; set; }
        private int GroupID { get; set; }

        private static List<ArticleGroup> articleGroups = new List<ArticleGroup>();
        private static List<int> GroupIDs = new List<int>();
        private static Dictionary<int, List<ArticleItem>> ArticlesInGroup = new Dictionary<int, List<ArticleItem>>();

        private static List<string> ParentGroups = new List<string>()
        {
            "Computer",
            "Rack",
            "Cabinet"
        };
        private ArticleGroup(int ParentGroupID, string GroupName, int GroupID)
        {
            this.GroupName = GroupName;
            this.GroupID = GroupID;
            this.ParentGroup = ParentGroups[ParentGroupID];
        }

        public static void CreateArticleGroup(int ParentGroupID, string GroupName, int GroupID)
        {
            ArticleGroup newGroup = new ArticleGroup(ParentGroupID, GroupName, GroupID);
            articleGroups.Add(newGroup);
        }
        
        public static void RemoveArticleGroup(int GroupID)
        {
            foreach (var group in articleGroups)
            {
                if (group.GroupID == GroupID)
                {
                    articleGroups.Remove(group);
                    break;
                }
            }
        }

        public static void AddArticleToGroup(ArticleItem ItemToAdd, int GroupID)
        {
            ArticlesInGroup[GroupID].Add(ItemToAdd);
        }
        public static void RemoveArticleFromGroup(ArticleItem ItemToRemove, int GroupID)
        {
            ArticlesInGroup[GroupID].Remove(ItemToRemove);
        }

        public static int GetGroupID(int GroupID)
        {
            foreach (var group in articleGroups)
            {
                if (group.GroupID == GroupID)
                {
                    return group.GroupID;
                }
            }
            return -1;
        }
        public static ArticleGroup GetArticleGroupByID(int GroupID)
        {
            foreach (var group in articleGroups)
            {
                if (group.GroupID == GroupID)
                {
                    return group;
                }
            }
            return null;
        }

        public static List<ArticleGroup> GetArticleGroups()
        {
            return articleGroups;
        }
    }
}
