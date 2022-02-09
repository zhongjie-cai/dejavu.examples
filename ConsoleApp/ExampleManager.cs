namespace ConsoleApp
{
    public interface IExampleManager
    {
        string Get();
    }

    public class ExampleManager : IExampleManager
    {
        private readonly IRandomActor _randomActor;

        public ExampleManager(IRandomActor randomActor)
        {
            _randomActor = randomActor;
        }

        public string Get()
        {
            return _randomActor.Act();
        }
    }
}
