namespace ConsoleApp
{
    public interface IRandomActor
    {
        string Act();
    }

    public class RandomActor : IRandomActor
    {
        private readonly IRandomNumber _randomNumber;

        public RandomActor(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
        }

        private static string GenerateFirstPart(int number)
        {
            if (number < 0)
            {
                return "?";
            }
            if (number < 25)
            {
                return "I";
            }
            if (number < 50)
            {
                return "L";
            }
            if (number < 75)
            {
                return "N";
            }
            if (number < 100)
            {
                return "M";
            }
            return "!";
        }

        private static string GenerateSecondPart(int number)
        {
            number %= 10;
            switch (number)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
                case 9:
                    return "J";
            }
            return "!";
        }

        public string Act()
        {
            var number1 = _randomNumber.Next(100);
            var part1 = GenerateFirstPart(number1);
            var number2 = _randomNumber.Next(100);
            var part2 = GenerateSecondPart(number2);
            return $"{part1}-{number1}|{part2}-{number2}";
        }
    }
}