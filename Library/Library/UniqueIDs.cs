using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class UniqueIDs
    {
        static List<int> usedIDs = new List<int>();
        public int CreatedID { get; set; }
        private int createdID = default;
        public UniqueIDs()
        {
            createdID = CreateID();
            if (usedIDs.Count == 0)
            {
                CreatedID = createdID;
                usedIDs.Add(CreatedID);
            }
            else
            if (!IsIDExists(usedIDs, ref createdID))
            {
                CreatedID = createdID;
                usedIDs.Add(CreatedID);
            }
        }
        public int CreateID()
        {
            Random rnd = new Random();
            CreatedID = rnd.Next(100000, 99999999);
            return CreatedID;
        }
        private bool IsIDExists(List<int> usedIDs, ref int createdID)
        {
            bool isExist = default;
            do
            {
                int index = BinarySearch(usedIDs, createdID, 0, usedIDs.Count - 1);
                if (index == -1)
                {
                    isExist = false;
                }
                else
                {
                    createdID = CreateID();
                    isExist = true;
                }

            } while (isExist);
            return isExist;
        }
        private int BinarySearch(List<int> usedIDs, int searchedID, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }
            var middle = (first + last) / 2;
            var middleValue = usedIDs[middle];

            if (middle == searchedID)
                return middle;
            else
            {
                if (middleValue > searchedID)
                {
                    return BinarySearch(usedIDs, searchedID, first, middle - 1);
                }
                else
                {
                    return BinarySearch(usedIDs, searchedID, middle + 1, last);
                }
            }
        }
    }
}
