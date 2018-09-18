using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { LEFT, UP, RIGHT, DOWN}

public class Rule3A {

    Dictionary<Direction, int[,]> directions;

    #region Singleton
    private static Rule3A instance = null;

    private Rule3A()
    {
    }

    public static Rule3A Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Rule3A();
            }
            return instance;
        }
    }
    #endregion


    //public void InitializeRule() {
    //    directions = new Dictionary<Direction, int[,]>();
    //}




    public bool isValidPath(Vector2Int arrayPos, Direction direction, int player) {
        bool result = false;

        switch (direction) {
            case Direction.LEFT:
                if (arrayPos.x - 2 >=0 && UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x - 1, arrayPos.y)).playerNum == player)
                    result = true;
                    break;
            case Direction.UP:
                if (arrayPos.y - 2 >= 0 && UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x, arrayPos.y + 1)).playerNum == player)
                    result = true;
                break;
            case Direction.RIGHT:
                if (arrayPos.x + 2 <= UnitGrid.Instance.unitGrid.GetUpperBound(0) && UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x + 1, arrayPos.y)).playerNum == player)
                    result = true;
                break;
            case Direction.DOWN:
                if (arrayPos.y + 2 <= UnitGrid.Instance.unitGrid.GetUpperBound(0) && UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x - 1, arrayPos.y)).playerNum == player)
                    result = true;
                break;
            default:
                break;

            }

        return result;
    }

    public void RetrieveNewTerritories(int player) {
        //List<Vector2Int> result = new List<Vector2Int>();
        foreach (BasePawnsClass p in UnitGrid.Instance.unitGrid) {
            if (isCase1Success(new Vector2Int(p.x, p.y), player)) {
                StartCase1Animation(new Vector2Int(p.x, p.y), player);
            }
            if (isCase2Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase2Animation();
            }
            if (isCase3Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase3Animation();
            }
            if (isCase4Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase4Animation();
            }
            if (isCase5Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase5Animation();
            }
            if (isCase6Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase6Animation();
            }
            if (isCase7Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase7Animation();
            }
            if (isCase8Success(new Vector2Int(p.x, p.y), player))
            {
                StartCase8Animation();
            }
        }
      //  return result;
    }

    //public bool isFriendlyUnit(Vector2Int arrayPos, int player) {
    //    bool result = true;
    //        UnitGrid.Instance.unitGrid[arrayPos.x, arrayPos.y]
    //    return result;
    //}

    public bool CheckLeft(Vector2Int arrayPos, int player) {
        return isValidPath(arrayPos, Direction.LEFT, player);
    }

    public bool CheckUp(Vector2Int arrayPos, int player)
    {
        return isValidPath(arrayPos, Direction.UP, player);
    }

    public bool CheckRight(Vector2Int arrayPos, int player)
    {
        return isValidPath(arrayPos, Direction.RIGHT, player);
    }

    public bool CheckDown(Vector2Int arrayPos, int player)
    {
        return isValidPath(arrayPos, Direction.DOWN, player);
    }

    public bool isNeighborFound(Vector2Int arrayPos, int range, int player) {
        bool result = false;

        if (arrayPos.x + range <= UnitGrid.Instance.unitGrid.GetUpperBound(0) & arrayPos.y + range <= UnitGrid.Instance.unitGrid.GetUpperBound(0) & UnitGrid.Instance.GetUnit(new Vector2Int(arrayPos.x + range, arrayPos.y + range)).playerNum == player)
            result = true;

            return result;
    }

   

    #region PossibleCases
    public bool isCase1Success(Vector2Int arrayPos, int player) {
        bool result = true;

        if (!CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase2Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (!CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase3Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase4Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase5Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (!CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase6Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (!CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckDown(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase7Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;

        return result;
    }

    public bool isCase8Success(Vector2Int arrayPos, int player)
    {
        bool result = true;

        if (result && !CheckDown(arrayPos, player))
            result = false;
        if (result && !CheckLeft(arrayPos, player))
            result = false;
        if (result && !CheckUp(arrayPos, player))
            result = false;
        if (result && !CheckRight(arrayPos, player))
            result = false;

        return result;
    }
    #endregion

    #region Cases animation activation
    public void StartCase1Animation(Vector2Int startingPoint, int player) {
        GridManager.Instance.ActivateParticles(startingPoint, player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 1, startingPoint.y), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 2, startingPoint.y), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 2, startingPoint.y + 1), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 2, startingPoint.y + 2), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 1, startingPoint.y + 2), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x, startingPoint.y + 1), player);
        GridManager.Instance.ActivateParticles(new Vector2Int(startingPoint.x - 1, startingPoint.y + 1), player);
    }
    public void StartCase2Animation() { }
    public void StartCase3Animation() { }
    public void StartCase4Animation() { }
    public void StartCase5Animation() { }
    public void StartCase6Animation() { }
    public void StartCase7Animation() { }
    public void StartCase8Animation() { }

    #endregion

    public void TriggerAnimations() {

    }
}
