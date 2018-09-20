using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{

    private static UIManager instance = null;
    private GameUI gui;

    private UIManager()
    {
        gui = GameFlow.uiLinks.gui;
    }

    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new UIManager();
            }
            return instance;
        }
    }

    public void Initialization()
    {
        gui.Initialize();
    }

    public void Update()
    {
        gui.UpdateGameUI();
    }

    public void ShowUnitsUI(GameObject obj,int phase)
    {
        
        if (obj.tag.Contains("Kernel"))
        {
            if (phase == 1)
            {
                if (!GameFlow.uiLinks.kernelUi.activeSelf)
                    gui.ShowKernelUI();
                if (GameFlow.uiLinks.unitUi.activeSelf)
                    gui.HideUnitUI();
                if (GameFlow.uiLinks.upgradeUi.activeSelf)
                    gui.HideUpgradeUI();
            }
        }
        else if(obj.tag.Contains("Units"))
        {
            if (!GameFlow.uiLinks.unitUi.activeSelf)
            {
                InitializeUnitsUiInfos(obj.GetComponent<BasePawnsClass>());
                if (phase != 3)
                {
                    gui.ShowUnitUI(obj);
                    if (phase == 1)
                    {
                        gui.HideMoveButton();
                        gui.ShowUpgradeButton();
                    }
                    else if (phase == 2)
                    {
                        gui.ShowMoveButton();
                        gui.HideUpgradeButton();
                    }
                }
            }
            if (GameFlow.uiLinks.kernelUi.activeSelf)
                gui.HideKernelUI();
            if (GameFlow.uiLinks.upgradeUi.activeSelf)
                gui.HideUpgradeUI();
        }
    }

    public void PlayersTurnChange(int id)
    {
        if(id == 1)
        {
            GameFlow.uiLinks.player1Turn.SetActive(true);
            GameFlow.uiLinks.player2Turn.SetActive(false);
        }
        else
        {
            GameFlow.uiLinks.player1Turn.SetActive(false);
            GameFlow.uiLinks.player2Turn.SetActive(true);
        }
    }

    public void ActivateTurn()
    {
        GameFlow.uiLinks.nextPhase.interactable = true;
        GameFlow.uiLinks.standBy.interactable = true;
    }

    public void DesactivateTurn()
    {
        GameFlow.uiLinks.nextPhase.interactable = false;
        GameFlow.uiLinks.standBy.interactable = false;
    }

    public void InitializeUnitsUiInfos(BasePawnsClass basePawn)
    {
        gui.InitializeUnitsUiInfos(basePawn);
    }

    public void SetPhaseInfo(int phase)
    {
        gui.SetPhaseInfo(phase);
    }
}
