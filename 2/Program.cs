int size = Convert.ToInt32(Console.ReadLine());
int[] array = new int[size];
for (int i = 0; i < array.Length; i++)
{
    array[i] = Convert.ToInt32(Console.ReadLine());
}
BubbleSort(array);
sequence_search(array, size);

static void BubbleSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
        for (int j = 0; j < array.Length - 1; j++)
            if (array[j] > array[j + 1])
            {
                int t = array[j + 1];
                array[j + 1] = array[j];
                array[j] = t;
            }
}

static void sequence_search(int[] array, int size)
{
    int[] array2 = new int[size];
    int b = 0;
    if ((array[b] + 1) == array[b + 1])
    {
        array2[b] = array[b];
        b++;
    }
    for (int i = 0; i < array.Length - 1; i++)
    {
        if ((array[i] + 1) == array[i + 1])
        {
            array2[b] = array[i + 1];
            b++;
        }
    }
    int[] array3 = new int[b];
    for (int i = 0; i < array3.Length; i++)
    {
        array3[i] = array2[i];
    }
    print_array(array3);
    }

static void print_array(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]}\t");
    }
    Console.WriteLine();
}
