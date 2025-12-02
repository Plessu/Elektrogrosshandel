using System;
using System.Collections.Generic;
using System.Text;

namespace Elektrogrrosshandel
{
    internal class ArticleGroup
    {
        private string GroupName { get; set; }
        private int groupID { get; set; }

        private static List<ArticleGroup> articleGroups = new List<ArticleGroup>();
        private static List<int> GroupIDs = new List<int>();

        private ArticleGroup(string groupName, int groupID)
        {
            this.GroupName = groupName;
            this.groupID = groupID;    
        }

        public static ArticleGroup GetArticleGroupByID(int groupID)
        {
            foreach (var group in articleGroups)
            {
                if (group.groupID == groupID)
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

        public static void CreateArticleGroup(string groupName, int groupID)
        {
            ArticleGroup newGroup = new ArticleGroup(groupName, groupID);
            articleGroups.Add(newGroup);
        }
        public static void RemoveArticleGroup(int groupID)
        {
            foreach (var group in articleGroups)
            {
                if (group.groupID == groupID)
                {
                    articleGroups.Remove(group);
                    break;
                }
            }
        }
    }
}
