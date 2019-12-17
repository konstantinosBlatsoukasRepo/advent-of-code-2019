# First Puzzle

  - when you want to hold unique items in a collection use `HashSet` (it's like a set in mathematics) 
  - a `List` data structure may hold duplicate values, if you want to hold only the unique values
    you can achieve it by initialize a new `HashSet` with the list as an argument to constructor

		`var secondWirePoints = Day3Utils.GetWirePoints(secondWireDirections);`
        `var secondUniqueWirePoints = new HashSet<string>(secondWirePoints);`

# Second Puzzle

  - linq power

	code no using linq
	`
		var commonPoints = new HashSet<string>();
        foreach (var secondWirePoint in secondWirePoints)
        {
			if (firstWirePoints.Contains(secondWirePoint))
            {
				commonPoints.Add(secondWirePoint);
            }
        }
	`

	code using linq
	`
		return secondWirePoints
        .Where(p => firstWirePoints.Contains(p))
        .ToHashSet();
	`