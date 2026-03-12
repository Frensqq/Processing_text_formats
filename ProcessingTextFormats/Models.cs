using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingTextFormats
{
    public class Models
    {
        public class SportTeam
        {
            public int id { get; set; }
            public string name { get; set; }
            public string secondname { get; set; }
            public int age { get; set; }
            public string typeSport { get; set; }
            public List<string> achivments { get; set; }

            public SportTeam(int Id, string Name,
                string SecondName, int Age, string TypeSport, List<string> Achivments)
            {
                this.id = Id;
                this.name = Name;
                this.secondname = SecondName;
                this.age = Age;
                this.typeSport = TypeSport;
                this.achivments = Achivments;
            }

            public SportTeam()
            {
                achivments = new List<string>();
            }

            public override string ToString()
            {
                string achivmentsStr = achivments != null && achivments.Count > 0
                    ? string.Join("\n  - ", achivments)
                    : "  • Нет достижений";

                return $"id - {id}\nИмя - {name}\nФамилия - {secondname}\nВозвраст - {age}\nТип спорта - {typeSport}\nДостижения:\n  - {achivmentsStr}\n";
            }
        }

        public class Storage<T>
        {
            private T _item { get; set; }

            public T GetItem() { return _item; }
            public void DisplayType()
            {
                Console.WriteLine($"Тип данных: {typeof(T)}");
            }
        }




    }
}
