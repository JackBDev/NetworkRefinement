using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
   [SyncVar] [SerializeField] private string displayName = "Missing Name";
   [SyncVar] [SerializeField] private Color playerColor = Color.red;

   [Server]
   public void SetDisplayName(string newDisplayName)
   {
       displayName = newDisplayName;
   }

   [Server]
   public void SetPlayerColor(Color newColor)
   {
       playerColor = newColor;
   }
}
