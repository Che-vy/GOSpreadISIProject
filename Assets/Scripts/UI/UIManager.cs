﻿using System.Collections;
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

    public void ShowConditionUI(string winner)
    {
        gui.ShowConditionUI(winner);
    }

    public void ShowUnitsUI(GameObject obj, int phase)
    {

        if (obj.tag.Contains("Kernel"))
        {
            if (phase == 1)
            {
                gui.DesactivateUI();
                gui.ShowKernelUI();

            }
        }
        else if (obj.tag.Contains("Units"))
        {
            gui.DesactivateUI();
            if (phase != 3)
            {
                InitializeUnitsUiInfos(obj.GetComponent<BasePawnsClass>());
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
    }

    public void PlayersTurnChange(int id)
    {
        if (id == 1)
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
