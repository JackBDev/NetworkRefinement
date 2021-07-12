using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text playerNameText = null;
    [SerializeField] private Renderer playerColorRenderer = null;

    [SyncVar(hook=nameof(SetDisplayNameUpdate))] [SerializeField] private string displayName = "Missing Name";
    [SyncVar(hook=nameof(SetPlayerColorUpdate))] [SerializeField] private Color playerColor = Color.red;

    #region server

    [Server] public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }

    [Server] public void SetPlayerColor(Color newColor)
    {
        playerColor = newColor;
    }

    [Command] private void CmdSetDisplayName(string newDisplayName)
    {
        RpcCallName(newDisplayName);

        SetDisplayName(newDisplayName);
    }

    #endregion

    #region client

    private void SetPlayerColorUpdate(Color oldColor, Color newColor)
    {
        playerColorRenderer.material.SetColor("_Color", newColor);
    }

    private void SetDisplayNameUpdate(string oldName, string newName)
    {
        playerNameText.text = newName;
    }

    
    [ContextMenu("Set My Name")] private void SetMyName()
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc] private void RpcCallName(string newDisplayName)
    {
        Debug.Log(newDisplayName);
    }

    #endregion
}