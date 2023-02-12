using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;
            Cores = cores;
            Frequency = frequency;
        }
        public string Brand { get; set; }
        public int Cores { get; set; }
        public double Frequency { get; set; }

        public override string ToString()
        {
            //return $"{Brand} CPU:\nCores: {Cores}\nFrequency: {Frequency:f1} GHz";

            StringBuilder str = new StringBuilder();
            str.AppendLine($"{Brand} CPU:");
            str.AppendLine($"Cores: {Cores}");
            str.AppendLine($"Frequency: {Frequency:f1} GHz");

            return str.ToString().TrimEnd();
        }
    }
}
