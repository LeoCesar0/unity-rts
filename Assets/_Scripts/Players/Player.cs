
public class Player
{
    // Start is called before the first frame update
    Types.PlayerOwner player;

    public PlayerResources resources  { get; private set; }

    public Player(Types.PlayerOwner player)
    {
        this.player = player;
    }

    private void Awake(){
        resources = new PlayerResources();
    }

}

