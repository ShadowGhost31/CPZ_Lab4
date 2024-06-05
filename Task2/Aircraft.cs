namespace DesignPatterns.Mediator
{
    public class Aircraft
    {
        public string Name;
        public IMediator? Mediator { get; set; } // Reference to the mediator

        public Aircraft(string name)
        {
            this.Name = name;
        }

        public void Land(Runway runway) // Delegates landing to the mediator
        {
            Mediator?.LandAircraft(this, runway);
        }

        public void TakeOff(Runway runway) // Delegates takeoff to the mediator
        {
            Mediator?.TakeOffAircraft(this, runway);
        }
    }
}
