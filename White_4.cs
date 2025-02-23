namespace Lab_6 {
    public class White_4 {
        public struct Participant {
            // Поля
            private string _name;
            private string _surname;
            private double[] _scores;

            // Свойства
            public string Name => _name != null ? _name : "Unknown";
            public string Surname => _surname != null ? _surname : "Unknown";
            public double[] Scores {
                get {
                    if (_scores == null) {
                        return new double[0];
                    }

                    var newArray = new double[_scores.Length];
                    Array.Copy(_scores, newArray, _scores.Length);
                    return newArray;
                }
            }
            public double TotalScore => _scores.Sum();
            

            // Конструктор
            public Participant(string name, string surname) {
                _name = name != null ? name : "Unknown";
                _surname = surname != null ? surname : "Unknown";
                _scores = new double[0];
            }

            // Методы
            public void PlayMatch(double result) {
                const double eps = 0.0001;

                if (!(Math.Abs(result - 0) < eps || Math.Abs(result - 0.5) < eps || Math.Abs(result - 1) < eps)) {
                    throw new ArgumentException("Result can be one of: 0, 0.5, 1", nameof(result));
                }

                var newArray = new double[_scores.Length + 1];
                Array.Copy(_scores, newArray, _scores.Length);
                newArray[_scores.Length] = result;
                _scores = newArray;
            }

            public static void Sort(Participant[] array) {
                if (array == null) {
                    throw new ArgumentNullException("Array can't be null", nameof(array));
                }
                if (array.Length == 0) {
                    throw new ArgumentException("Array must not be empty", nameof(array));
                }

                var newArray = array.OrderByDescending(p => p.TotalScore).ToList();
                newArray.CopyTo(array);
            }

            public void Print() {
               Console.WriteLine("Name: " + Name + "\tSurname: " + Surname + "\tTotal score: " + TotalScore); 
            }

        }
    }
}