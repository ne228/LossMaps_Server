using System;

namespace LossMaps_Server
{
    public class StatementRandomGenerator
    {
        private static readonly List<string> surnames = new List<string>
        {
            "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов", "Васильев", "Павлов", "Семенов", "Голубев", "Волков", "Зайцев", "Морозов", "Новиков", "Козлов", "Лебедев", "Козлов", "Макаров"
            // Дополните список своими фамилиями
        };

        private static readonly List<string> maleNames = new List<string>
        {
            "Иван", "Петр", "Александр", "Дмитрий", "Андрей", "Алексей", "Сергей", "Николай", "Владимир", "Михаил", "Егор", "Денис", "Игорь", "Кирилл", "Олег", "Станислав", "Максим", "Артем", "Никита"
            // Дополните список своими именами
        };

        private static readonly List<string> femaleNames = new List<string>
        {
            "Анна", "Екатерина", "Мария", "Александра", "Ольга", "Татьяна", "Ирина", "Елена", "Светлана", "Наталья", "Виктория", "Анастасия", "Юлия", "Дарья", "Евгения", "Надежда", "Валентина", "Ксения"
            // Дополните список своими именами
        };

        private static readonly List<string> patronymics = new List<string>
        {
            "Иванович", "Петрович", "Александрович", "Дмитриевич", "Андреевич", "Алексеевич", "Сергеевич", "Николаевич", "Владимирович", "Михайлович", "Егорович", "Денисович", "Игоревич", "Кириллович", "Олегович", "Станиславович", "Максимович", "Артемович", "Никитович"
            // Дополните список своими отчествами
        };
        string[] features = new string[]
        {
                    "Карие глаза", "Голубые глаза", "Зеленые глаза", "Красные волосы", "Темные волосы", "Светлые волосы",
                    "Лысина", "Седые волосы", "Длинные волосы", "Курчавые волосы", "Прямые волосы", "Средний рост", "Высокий рост",
                    "Низкий рост", "Седина", "Борода", "Усы", "Гладко выбрит", "Татуировка", "Пирсинг"
            // Дополните список своими признаками
        };

        private DateTime startDate = new DateTime(1980, 1, 1);
        private DateTime endDate = new DateTime(2013, 12, 31);
        private readonly Random random;

        public StatementRandomGenerator()
        {
            random = new Random();
        }

        public string GenerateRandomSurname()
        {
            return GetRandomElement(surnames);
        }

        public string GenerateRandomMaleName()
        {
            return GetRandomElement(maleNames);
        }


        public string GenerateRandomPatronymic()
        {
            return GetRandomElement(patronymics);
        }

        public string GenerateRandomFeatures()
        {
            int numberOfFeatures = random.Next(1, features.Length + 1);
            string[] selectedFeatures = new string[numberOfFeatures];

            for (int i = 0; i < numberOfFeatures; i++)
            {
                int randomIndex = random.Next(features.Length);
                selectedFeatures[i] = features[randomIndex];
            }

            return string.Join(", ", selectedFeatures);
        }

        DateTime GenerateRandomBirthDate()
        {
            int range = (endDate - startDate).Days;
            int randomDays = random.Next(range);

            return startDate.AddDays(randomDays);
        }

        DateTime GenerateRandomDate()
        {
            DateTime today = DateTime.Now;
            int daysOffset = random.Next(1, 31);
            
            return today.AddDays(-daysOffset);
        }

        (double latitude, double longitude) GenerateRandomCoordinates()
        {

            double stPetersburgLatitude = 59.9343;
            double stPetersburgLongitude = 30.3351;
            double radius = 10.0 / 111.32; // Примерный радиус в градусах
            // Генерация случайного угла
            double angle = 2 * Math.PI * random.NextDouble();

            // Генерация случайного радиуса в пределах указанного
            double randomRadius = Math.Sqrt(random.NextDouble()) * radius;

            // Вычисление новых координат
            double newLatitude = stPetersburgLatitude + randomRadius * Math.Sin(angle);
            double newLongitude = stPetersburgLongitude + randomRadius * Math.Cos(angle);

            return (newLatitude, newLongitude);
        }
        public Statement GetRandomStatement()
        {
            var statement = new Statement();
            statement.LastName = GenerateRandomSurname();
            statement.FirstName = GenerateRandomMaleName();
            statement.Patronymic = GenerateRandomPatronymic();    
            statement.Features = GenerateRandomFeatures();
            statement.BirthDate = GenerateRandomBirthDate();    
            statement.ApplicantLastName = GenerateRandomSurname();
            statement.ApplicantFirstName = GenerateRandomMaleName();
            statement.ApplicantPatronymic = GenerateRandomPatronymic();
            statement.DateTimeOfStatement = GenerateRandomDate();

            (double latitude, double longitude) = GenerateRandomCoordinates();
            statement.Latitude = latitude;
            statement.Longitude = longitude;    
                
            return statement;
        }

        private string GetRandomElement(List<string> list)
        {
            int index = random.Next(list.Count);
            return list[index];
        }
    }
}
