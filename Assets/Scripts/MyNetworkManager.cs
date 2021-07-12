using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class MyNetworkManager : NetworkManager
{
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        Debug.Log("I connected to a server!");
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);

        Color newColor = new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f));

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        
        player.SetDisplayName($"Player {numPlayers}");
        player.SetPlayerColor(newColor);

        Debug.Log($"There are now {numPlayers} player(s) connected to the server.");
    }
}
