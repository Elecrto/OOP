using ConsoleApp3;
Coord z1 = new Coord(1, 1, 0);
Coord z2 = new Coord(2, 2, 0);
Coord z3 = new Coord(3, 2, 0);
Coord z4 = new Coord(4, 1, 0);


FourDots figure = new FourDots(z1, z2, z3, z4);

Console.WriteLine("Площадь фигуры: {0}", FourDots.S(figure));
Console.WriteLine("Лежат ли точки в одной плоскости: {0}", FourDots.IsInOnePlane(figure));
FourDots.IsConv(figure);
FourDots.WichFig(figure);