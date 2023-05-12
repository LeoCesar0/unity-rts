using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    private static PlayersManager _instance;
    public static PlayersManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public int numOfPlayers = 2;

    public int maxPlayers = 4;

    public List<Player> playersList = new List<Player>();

    void Start()
    {
        for (int i = 1; i <= Mathf.Min(numOfPlayers, maxPlayers); i++)
        {
            Types.PlayerOwner playerNum = Types.PlayerOwner.player1;
            switch (i){
                case 1:
                playerNum = Types.PlayerOwner.player1;
                break;
                case 2: 
                playerNum = Types.PlayerOwner.player2;
                break;
                case 3:
                playerNum = Types.PlayerOwner.player3;
                break;
                case 4: 
                playerNum = Types.PlayerOwner.player4;
                break;
            }

            Player player = new Player(playerNum);
            playersList.Add(player);
            Debug.Log(playerNum);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
