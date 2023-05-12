
public class PlayerResources
{

    public int wood { get; private set; } = 0;
    public int stone { get; private set; } = 0;
    public int food { get; private set; } = 0;
    public int gold { get; private set; } = 0;

    public void DepositResources(Types.ResourceType resourceType, int amount)
    {
        switch (resourceType)
        {
            case Types.ResourceType.wood:
                wood += amount;
                break;
            case Types.ResourceType.stone:
                stone += amount;
                break;
            case Types.ResourceType.food:
                food += amount;
                break;
            case Types.ResourceType.gold:
                gold += amount;
                break;
            default:
                throw new System.ArgumentException("Invalid resource type");
        }
    }
}
