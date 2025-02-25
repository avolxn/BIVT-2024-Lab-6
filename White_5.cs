namespace Lab_6 {
    public class White_5 {
        public struct Match {
            // Поля
            private readonly int _goals;
            private readonly int _misses;

            // Свойства
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => _goals - _misses;
            public int Score {
                get {
                    if (_goals > _misses) {
                        return 3;
                    } else if (_goals == _misses) {
                        return 1;
                    }
                    return 0;
                }
            }
            
            // Конструктор
            public Match(int goals, int misses) {
                if (goals < 0) {
                    Console.WriteLine("Goal count can't be negative");
                    return;
                }
                if (misses < 0) {
                    Console.WriteLine("Miss count can't be negative");
                    return;
                }

                _goals = goals;
                _misses = misses;
            }

            // Методы
            public void Print() {
               Console.WriteLine("Goals: " + Goals + "\tMisses: " + Misses); 
            }
        }

        public struct Team {
            // Поля
            private string _name;
            private Match[] _matches;

            // Свойства
            public string Name => _name;
            public Match[] Matches {
                get {
                    if (_matches == null) {
                        return new Match[0];
                    }

                    var newArray = new Match[_matches.Length];
                    Array.Copy(_matches, newArray, _matches.Length);
                    return newArray;
                }
            }
            public int TotalDifference => _matches != null ? _matches.Sum(p => p.Difference) : 0;
            public int TotalScore => _matches != null ? _matches.Sum(p => p.Score) : 0;
            
            // Конструктор
            public Team (string name) {
                _name = name;
                _matches = new Match[0];
            }

            // Методы
            public void PlayMatch(int goals, int misses) {
                if (_matches == null) {
                        Console.WriteLine("Array of matches wasn't initialized");
                        return;
                        // _matches = new Match[0];
                    }

                var newArray = new Match[_matches.Length + 1];
                Array.Copy(_matches, newArray, _matches.Length);
                Match match = new Match(goals, misses);
                newArray[_matches.Length] = match;
                _matches = newArray;
            }

            public static void SortTeams(Team[] teams) {
                if (teams == null) {
                    Console.WriteLine("Array of teams can't be null");
                    return;
                }
                if (teams.Length == 0) {
                    Console.WriteLine("Array of teams must not be empty");
                    return;
                }

                var newArray = teams.OrderByDescending(p => p.TotalScore).ToArray();
                Array.Copy(newArray, teams, newArray.Length);
            }

            public void Print() {
                Console.WriteLine("Name: " + Name + "\tTotal score: " + TotalScore + "\tTotal difference: " + TotalDifference);
            }
        }
    }
}