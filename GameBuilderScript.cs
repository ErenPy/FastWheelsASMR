using UnityEngine;
using System.Collections.Generic;

public class GameBuilderScript : MonoBehaviour
{
    public static MoneyScript curMoney = new MoneyScript(new List<int> ());
    public static int totalCarMade;
    public static float earningPerSecond;
    public static int[] carOrder;
    public bool tutorialEnabled = false;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private Animator tutorialAnimator;
    [SerializeField] private GameObject tutorialText_00;
    [SerializeField] private GameObject tutorialText_01;

    private void Awake() {
        Data save = SaveSystem.LoadGame();
        if (SaveSystem.LoadGame() == null) {
            CarCreatorScript.CarLevelList = new int[12] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            CarCreatorScript.TotalAddCount = 0;
            CarCreatorScript.TotalMergeCount = 0;
            CarCreatorScript.AddMoney = new MoneyScript(new List<int> {0});
            CarCreatorScript.MergeMoney = new MoneyScript(new List<int> {0, 0, 0, 3});
            curMoney = new MoneyScript(new List<int> {0});
            StartTutorial();
        } else {
            CarCreatorScript.CarLevelList = save.carLevelList;
            CarCreatorScript.TotalAddCount = save.totalAddChickenCount;
            CarCreatorScript.TotalMergeCount = save.totalMergeCount;
            CarCreatorScript.AddMoney.SetMoney(save.curAddCost);
            CarCreatorScript.MergeMoney.SetMoney(save.curMergeCost);
            curMoney.SetMoney(save.curMoneyList);
        }
    }

    private void StartTutorial() {
        tutorial.SetActive(true);
        tutorialText_00.SetActive(true);
        tutorialEnabled = true;
    }

    public void TapTutorial() {
        tutorialText_00.SetActive(false);
        tutorialText_01.SetActive(true);
        tutorialAnimator.SetTrigger("SecondPart");
    }

    public void FinishTutorial() {
        tutorialText_01.SetActive(false);
        tutorial.SetActive(false);
    }
}
