using ConsoleApp3;
Coord z1 = new Coord(1, 1, 1);
Coord z2 = new Coord(3, 2, 1);
Coord z3 = new Coord(4, 3, 1);
Console.WriteLine(Coord.Dist(z1, z2));
Coord.Equasion2D(z1, z2);
Coord.Equasion3D(z1, z2, z3);
Coord z4 = z1 + z2;
z4.show();