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
        if (nbPlayers != 0)
        {
            GameFlow.uiLinks.player1Name.text = "Player 1 Name : " + PlayerManager.Instance.getPlayer(1).name;
            if (nbPlayers > 1)
                GameFlow.uiLinks.player2Name.text = "Player 2 Name : " + PlayerManager.Instance.getPlayer(2).name;
        }
    }

    public void UpdateGameUI()
    {
        if (nbPlayers != 0)
        {
            GameFlow.uiLinks.player1NbTerritory.text = "Nb Territory : " + PlayerManager.Instance.getPlayer(1).zone;

            if (nbPlayers > 1)
                GameFlow.uiLinks.player2NbTerritory.text = "Nb Territory : " + PlayerManager.Instance.getPlayer(2).zone;
        }

    }

    public void ShowKernelUI()
    {
        GameFlow.uiLinks.kernelUi.SetActive(true);
    }

    public void CreateUnit()
    {
        Movements.CanItMove(Movements.LastObjetSelectionne.GetComponent<BasePawnsClass>());
        PlayerManager.Instance.getPlayer(PlayerManager.Instance.playerTurn).currentMode = CurrentMode.CREATE;
    }

    public void MoveUnit()
    {
        Movements.CanItMove(Movements.LastObjetSelectionne.GetComponent<BasePawnsClass>());
        PlayerManager.Instance.getPlayer(PlayerManager.Instance.playerTurn).currentMode = CurrentMode.MOVE;
    }

    public void HideKernelUI()
    {
        GameFlow.uiLinks.kernelUi.SetActive(false);
    }

    public void ShowMoveButton()
    {
        GameFlow.uiLinks.move.interactable = true;
    }
    public void HideMoveButton()
    {
        GameFlow.uiLinks.move.interactable = false;
    }

    public void ShowUpgradeButton()
    {
        GameFlow.uiLinks.upgrade.interactable = true;
    }
    public void HideUpgradeButton()
    {
        GameFlow.uiLinks.upgrade.interactable = false;
    }

    public void ShowUnitUI(GameObject Unit)
    {
        GameFlow.uiLinks.unitUi.SetActive(true);

    }

    public void HideUnitUI()
    {
        GameFlow.uiLinks.unitUi.SetActive(false);
    }

    public void ShowUpgradeUI()
    {
        GameFlow.uiLinks.upgradeUi.SetActive(true);
    }

    public void HideUpgradeUI()
    {
        GameFlow.uiLinks.upgradeUi.SetActive(false);
    }

    public void ChangePhase()
    {
        DesactivateUI();
        PlayerManager.Instance.getPlayer(PlayerManager.Instance.playerTurn).NextPhase();
    }

    public void StandBy()
    {
        DesactivateUI();
        PlayerManager.Instance.getPlayer(PlayerManager.Instance.playerTurn).StandBy();
    }

    public void DesactivateUI()
    {
        HideKernelUI();
        HideUnitUI();
        HideUpgradeUI();
    }

    public void InitializeUnitsUiInfos(BasePawnsClass basePawn)
    {
        GameFlow.uiLinks.unitName.text = basePawn.pawnType.ToString();
        GameFlow.uiLinks.unitRange.text = "Range : " + basePawn.rangeValue.ToString();
        GameFlow.uiLinks.unitMove.text = "Move : " + basePawn.movementValue.ToString();
    }

    public void SetPhaseInfo(int phase)
    {
        GameFlow.uiLinks.phase.text = "Phase " + phase.ToString();
    }
}
