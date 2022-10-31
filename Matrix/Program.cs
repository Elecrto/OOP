using Matrix;

Console.WriteLine("Random matrix a:");
Matr a = new Matr(3, 3);
a.Show();

Console.WriteLine();

Console.WriteLine("Random matrix b:");
/*!Если нужно ввожить матрицу с клавиатуры, то удалите параметры у Matr!*/
Matr b = new Matr(3,3);
b.Show();

Console.WriteLine();

Console.WriteLine("1) a + b =");
Matr c = a + b;
c.Show();

Console.WriteLine();

Console.WriteLine("2) a * b =");
c = a * b;
c.Show();

Console.WriteLine();

Console.WriteLine("3) a / 2 =");
c = a / 2;
c.Show();

Console.WriteLine();

SquareMatr A = new SquareMatr(b);
Console.WriteLine("4) Det(b) = {0}", A.CalculateDeterminant());
RevMatr D = new RevMatr(A);

Console.WriteLine();

A.Show();

Console.WriteLine();
Console.WriteLine("5) Inv(b) =");
D.Inv().Show();