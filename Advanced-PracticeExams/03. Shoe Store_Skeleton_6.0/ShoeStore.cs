using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count { get { return Shoes.Count; } }
        public string AddShoe(Shoe shoe)
        {
            if(Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int counter = 0;

            for(int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material)
                {
                    Shoes.RemoveAt(i);
                    counter++;
                    i--;
                }
            }
            return counter;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(n => n.Type == type.ToLower()).ToList();
        }



        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(s => s.Size == size);
        }

        public string StockList(double size, string type)
        {
            List<Shoe> filteredShoes = Shoes
                .Where(n => n.Size == size && n.Type == type)
                .ToList();
            StringBuilder str = new StringBuilder();
            if(filteredShoes.Any())
            {
                str.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach(Shoe shoe in filteredShoes)
                {
                    str.AppendLine(shoe.ToString());
                }
            }
            else
            {
                str.AppendLine("No matches found!");
            }
            return str.ToString().TrimEnd();
        }
    }
}
