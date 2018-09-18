using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    int nbPlayers = 0;

    public void Initialize()
    {
        nbPlayers = PlayerManager.Instance.players.Count;
        GameFlow.uiLinks.player1Name.text = "Player 1 Name : " + PlayerManager.Instance.getPlayer(1).name;
        if (nbPlayers > 1)
            GameFlow.uiLinks.player2Name.text = "Player 2 Name : " + PlayerManager.Instance.getPlayer(2).name;
    }

    public void UpdateGameUI()
    {
        GameFlow.uiLinks.player1NbTerritory.text = "Nb Territory : " + PlayerManager.Instance.getPlayer(1).zone;
        if (nbPlayers > 1)
            GameFlow.uiLinks.player2NbTerritory.text = "Nb Territory : " + PlayerManager.Instance.getPlayer(2).zone;
    }

    public void ShowKernelUI()
    {
        GameFlow.uiLinks.kui.SetActive(true);
    }

    public void HideKernelUI()
    {
        GameFlow.uiLinks.kui.SetActive(false);
    }
}
