using Library;

Boat boat = new("Clausine", "træ", "flyder", new(2000, 01, 01), 123456, "kører godt", 20, 1);
boat.AddReperation("Fikset masten", new(2020, 02, 03));
boat.AddReperation("Fikset sejl", new(2021, 05, 16));
Console.WriteLine(boat);
Console.WriteLine(boat.GetReperationsAsString());

