
public class Knight : Unit
{
    public StatsSO defaultStats;

    protected override void Start()
    {
        stats = defaultStats;
        // Call the setup method
        base.Start();
        Setup();
    }

    // The setup method is abstract, so it must be overridden in a subclass
    protected override void Setup()
    {

    }


}
