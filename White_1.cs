namespace Lab_6 {
    public class White_1 {
        public struct Participant {

            // Поля
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            
            // Свойства
            public string Surname => _surname != null ? _surname : "Unknown";
            public string Club => _club != null ? _club : "Unknown";
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => Math.Round(_firstJump + _secondJump, 2);

            // Конструктор
            public Participant(string surname, string club) {
                _surname = surname != null ? surname : "Unknown";
                _club = club != null ? club : "Unknown";
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

                var newArray = array.OrderByDescending(p => p.JumpSum).ToList();
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
                Console.WriteLine("Surname: " + Surname + "\tClub: " + Club + "\tJumpSum: " + JumpSum);
            }
        }
    }
}