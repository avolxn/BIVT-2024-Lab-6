namespace Lab_6 {
    public class White_2 {
        public struct Participant {

            // Поля
            private string _name;
            private string _surname;
            private double _firstJump;
            private double _secondJump;

            // Свойства
            public string Name => _name != null ? _name : "Unknown";
            public string Surname => _surname != null ? _surname : "Unknown";
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => _firstJump >= _secondJump ? _firstJump : _secondJump;

            // Конструктор
            public Participant(string name, string surname) {
                _name = name != null ? name : "Unknown";
                _surname = surname != null ? surname : "Unknown";
                _firstJump = 0;
                _secondJump = 0;
            }

            // Методы
            public static void Sort(Participant[] array) {
                if (array == null) {
                    throw new ArgumentNullException("Array can't be null", nameof(array));
                }
                if (array.Length == 0) {
                    throw new ArgumentException("Array must not be empty", nameof(array));
                }

                var newArray = array.OrderByDescending(p => p.BestJump).ToList();
                newArray.CopyTo(array);
            }

            public void Jump(double result) {
                if (result < 0) {
                    throw new ArgumentException("Result can't be negative", nameof(result));
                }

                if (_firstJump == 0) {
                    _firstJump = result;
                }
                else if (_secondJump == 0) {
                    _secondJump = result;
                }
            }

            public void Print() {
                Console.WriteLine("Name: " + Name + "\tSurname: " + Surname + "\tBestJump: " + BestJump);
            }
        }
    }
}