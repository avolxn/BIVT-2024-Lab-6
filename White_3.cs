namespace Lab_6 {
    public class White_3 {
        public struct Student {
            // Поля
            private string _name;
            private string _surname;
            private int[] _marks;
            private int _skips;

            // Свойства
            public string Name => _name != null ? _name : "Unknown";
            public string Surname => _surname != null ? _surname : "Unknown";
            public int Skipped => _skips;
            public double AvgMark => _marks != null ? Math.Round((double)_marks.Sum()/_marks.Length, 2) : 0;

            // Конструктор
            public Student(string name, string surname) {
                _name = name != null ? name : "Unknown";
                _surname = surname != null ? surname : "Unknown";
                _marks = new int[0];
                _skips = 0;
            }

            // Методы
            public void Lesson(int mark) {
                if (mark < 0) {
                    throw new ArgumentException("Mark can't be negative", nameof(mark));
                }

                if (mark == 0) {
                    _skips += 1;
                } else {
                    var newArray = new int[_marks.Length + 1];
                    Array.Copy(_marks, newArray, _marks.Length);
                    newArray[_marks.Length] = mark;
                    _marks = newArray;
                }
            }

            public static void SortBySkipped(Student [] array) {
                if (array == null) {
                    throw new ArgumentNullException("Array can't be null", nameof(array));
                }
                if (array.Length == 0) {
                    throw new ArgumentException("Array must not be empty", nameof(array));
                }

                var newArray = array.OrderByDescending(p => p.Skipped).ToList();
                newArray.CopyTo(array);
            }

            public void Print() {
               Console.WriteLine("Name: " + Name + "\tSurname: " + Surname + "\tAverage mark: " + AvgMark + "\t Skipped: " + Skipped); 
            }
        }
    }
}