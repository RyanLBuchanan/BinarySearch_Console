namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var generator = new Random();
            var data = new int[15];

            for (var i = 0; i < data.Length; i++)
            {
                data[i] = generator.Next(10, 100);
            }

            Array.Sort(data);
            DisplayElements(data, 0, data.Length - 1);

            // Input first int from user
            Console.Write("\n Please enter an integer value (-1 to exit): ");
            int searchInt = int.Parse(Console.ReadLine());

            // Repeat intput
            while (searchInt != -1)
            {
                // Perform binary search
                int position = BinarySearch(data, searchInt);

                if (position != -1)
                {
                    Console.WriteLine($"The integer {searchInt} was found in position {position}.\n");
                }
                else
                {
                    Console.WriteLine($"The integer {searchInt} was not found.\n");
                }

                // Input next int
                Console.Write("\nPlease enter an integer value (-1 to exit): ");
                searchInt = int.Parse(Console.ReadLine());
            }
        }

        // Perform binary search on the data
        public static int BinarySearch(int[] values, int searchElement)
        {
            var low = 0;
            var high = values.Length - 1;
            var middle = (low + high) / 2;

            do
            {
                // Display reaming elements in array
                DisplayElements(values, low, high);   

                // Indicate current middle ; pad left with spaes for alignment
                Console.WriteLine("-- ".PadLeft((middle + 1) * 3));

                // If element is found at middle
                if (searchElement == values[middle])
                {
                    return middle;
                }
                else if (searchElement < values[middle])
                {
                    high = middle - 1;
                }
                else
                {
                    low = middle + 1;
                }

                middle = (low + high + 1) / 2;
            } while (low < high);

            return -1;
        }

        public static void DisplayElements(int[] values, int low, int high)
        {
            // Output three spaces for each element up to low for alignment
            Console.Write(string.Empty.PadLeft(low * 3));

            // Output elements left in array
            for (var i = low; i <= high; i++)
            {
                Console.Write($"{values[i]} ");
            }

            Console.WriteLine();
        }
    }
}