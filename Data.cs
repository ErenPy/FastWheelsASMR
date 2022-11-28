using System.Collections.Generic;
using UnityEngine;

// Make Serializable to Save Changes
[System.Serializable]
public class Data
{
    // Game Settings
    [SerializeField] public bool soundStatus;
    [SerializeField] public bool hapticStatus;
    // Player Settings
    [SerializeField] public List<int> curMoneyList = new List<int> ();
    [SerializeField] public List<int> curAddCost = new List<int> ();
    [SerializeField] public List<int> curMergeCost = new List<int> ();
    [SerializeField] public bool[] unlockedHatchList;
    [SerializeField] public int[] carLevelList;
    [SerializeField] public int totalMergeCount;
    [SerializeField] public int totalAddChickenCount;
    public Data()
    {
        curMoneyList = GameBuilderScript.curMoney.GetMoney();
        curAddCost = CarCreatorScript.AddMoney.GetMoney();
        curMergeCost = CarCreatorScript.MergeMoney.GetMoney();
        carLevelList = CarCreatorScript.CarLevelList;
        totalAddChickenCount = CarCreatorScript.TotalAddCount;
        totalMergeCount = CarCreatorScript.TotalMergeCount;
    }
}