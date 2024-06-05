namespace DesignPatterns.Mediator
{
    public class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public bool IsBusy { get; set; }
        public IMediator? Mediator { get; set; } 

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {this.Id} is busy!");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {this.Id} is free!");
        }
    }
}
