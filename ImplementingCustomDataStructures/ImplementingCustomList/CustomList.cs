using System;


namespace CustomStructures
{
    public class CustomList
    {
        private const int StartingCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[StartingCapacity];
        }
        public int Count { get; private set; }
        public void Add(int number)
        {
            
            if (Count == items.Length)
            {
                Resize();
            }
            Count++;
            items[Count-1] = number;
            
        }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int result = items[index];
            items[index] = default;
            ShiftLeft(index);
            Count--;
            Shrink();
            return result;
            
        }

        public void Insert(int index, int value)
        {
            ValidateIndex(index);
            if (Count == items.Length)
            {
                Resize();
            }
            Count++;
            ShiftRight(index);
            items[index] = value;

        }

        //---------------------------
        //private methods

        private void Resize()
        {
            int[] newArray = new int[items.Length * 2];
            for(int i = 0; i < Count; i++)
            {
                newArray[i] = items[i];
            }
            items = newArray;
            
        }


        private void ValidateIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private void ShiftLeft(int startIndex)
        {
            for (int i = startIndex; i < Count-1;i++)
            {
                items[i] = items[i+1];
            }
            items[Count-1] = default;
        }

        private void ShiftRight(int startIndex)
        {
            for(int i = Count; i > startIndex;i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void Shrink()
        {
            if (Count <= items.Length / 4.0)
            {


                int[] newArray = new int[items.Length / 2];
                for (int i = 0; i < Count; i++)
                {
                    newArray[i] = items[i];


                }
                items = newArray;
            }
        }


    }
}
