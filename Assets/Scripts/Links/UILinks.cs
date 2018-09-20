using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILinks : MonoBehaviour {

    [Header ("GameUI Setting")]
    public Text player1Name;
    public Text player2Name, player1NbTerritory, player2NbTerritory, phase;
    public GameUI gui;
    public GameObject player1Turn, player2Turn;
    public Button nextPhase, standBy;

    [Header("KernelUI Setting")]
    public GameObject kernelUi;

    [Header("UnitUI Setting")]
    public GameObject unitUi;
    public Text unitName, unitRange, unitMove;
    public Button move, upgrade;

    [Header("UpgradeUI Setting")]
    public GameObject upgradeUi;

}
