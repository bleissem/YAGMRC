using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAGMRC
{
    public class MoveFilesToGameFolderItems
    {
        public string Displayed
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public MoveFilesToGameFolderItems Item
        {
            get
            {
                return this;
            }
        }

        public const int Zero = 0;
        public const int One = 1;
        public const int All = int.MaxValue;

        public static List<MoveFilesToGameFolderItems> DataSourceItems(MoveFilesToGameFolderItems existing)
        {
            List<int> createList = new List<int>() { Zero, One, All };
            if (!createList.Contains(existing.Quantity))
            {
                createList.Add(existing.Quantity);
            }

            var resultList = new List<MoveFilesToGameFolderItems>();
            foreach (var quantityToCreate in createList)
            {
                resultList.Add(Create(quantityToCreate));
            }

            return resultList;
        }

        public static MoveFilesToGameFolderItems Create(int numberFilesToKeep)
        {
            string displayed = "all";
            if ((int.MaxValue != numberFilesToKeep) && (numberFilesToKeep >= 0))
            {
                displayed = numberFilesToKeep.ToString();
            }

            return new MoveFilesToGameFolderItems() { Displayed = displayed, Quantity = numberFilesToKeep };
        }
    }
}
