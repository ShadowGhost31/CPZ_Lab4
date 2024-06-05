namespace DesignPatterns.Mediator
{
    public interface IMediator
    {
        void LandAircraft(Aircraft aircraft, Runway runway);
        void TakeOffAircraft(Aircraft aircraft, Runway runway);
    }

    public class CommandCentre : IMediator
    {
        private readonly List<Runway> _runways;
        private readonly List<Aircraft> _aircrafts;

        public CommandCentre(Runway[] runways, Aircraft[] aircrafts)
        {
            _runways = runways.ToList();
            _aircrafts = aircrafts.ToList();

            // Register runways and aircraft with the mediator
            foreach (var runway in _runways)
            {
                runway.Mediator = this;
            }
            foreach (var aircraft in _aircrafts)
            {
                aircraft.Mediator = this;
            }
        }

        public void LandAircraft(Aircraft aircraft, Runway runway)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is landing.");
            Console.WriteLine($"Checking runway.");

            if (!runway.IsBusy)
            {
                Console.WriteLine($"Aircraft {aircraft.Name} has landed.");
                runway.IsBusy = true;
                runway.HighLightRed();
            }
            else
            {
                Console.WriteLine($"Could not land, the runway is busy.");
            }
        }

        public void TakeOffAircraft(Aircraft aircraft, Runway runway)
        {
            Console.WriteLine($"Aircraft {aircraft.Name} is taking off.");
            runway.IsBusy = false;
            runway.HighLightGreen();
            Console.WriteLine($"Aircraft {aircraft.Name} has took off.");
        }
    }
}
