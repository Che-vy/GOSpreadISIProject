﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILinks : MonoBehaviour {

    [Header ("GameUI Setting")]
    public Text player1Name;
    public Text player2Name, player1NbTerritory, player2NbTerritory;
    public GameUI gui;
    public GameObject player1Turn, player2Turn;

    [Header("KernelUI Setting")]
    public GameObject kernelUi;

    [Header("UnitUI Setting")]
    public GameObject unitUi;
    public Text unitName, unitRange, unitMove;

    [Header("UpgradeUI Setting")]
    public GameObject upgradeUi;
}
