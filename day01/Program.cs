var directions = File.ReadAllLines("input.txt")
    .Where(l => !string.IsNullOrWhiteSpace(l))
    .Select(l => new CoordinateCalculator(l))
    .First();

System.Console.WriteLine(directions.DistanceFromStart);

System.Console.WriteLine(directions.DistanceOfFirstLocationVisitedTwice);