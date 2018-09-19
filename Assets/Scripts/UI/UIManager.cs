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

    public void ShowUnitsUI(GameObject obj)
    {
        if (obj.tag.Contains("Kernel"))
        {
            if (!GameFlow.uiLinks.kernelUi.activeSelf)
                gui.ShowKernelUI();
            if (GameFlow.uiLinks.unitUi.activeSelf)
                gui.HideUnitUI();
            if (GameFlow.uiLinks.upgradeUi.activeSelf)
                gui.HideUpgradeUI();
        }
        else if(obj.tag.Contains("Units"))
        {
            if (!GameFlow.uiLinks.unitUi.activeSelf)
                gui.ShowUnitUI(obj);
            if (GameFlow.uiLinks.kernelUi.activeSelf)
                gui.HideKernelUI();
            if (GameFlow.uiLinks.upgradeUi.activeSelf)
                gui.HideUpgradeUI();
        }
    }
}
