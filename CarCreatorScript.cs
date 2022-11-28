using UnityEngine;
using System.Collections.Generic;

public class CarCreatorScript : MonoBehaviour
{
    [SerializeField] public static bool[] UnlockedCars;
    public static int maxCarCount = 10;
    public static int[] CarLevelList;
    public static int TotalMergeCount;
    public static int TotalAddCount;
    public static MoneyScript MergeMoney = new MoneyScript(new List<int> ());
    public static MoneyScript AddMoney = new MoneyScript(new List<int> ());
    [SerializeField] public CarHolderScript[] carHolders;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip newCarAudio;
    [SerializeField] private AudioClip notEnoughMoneyAudio;
    [SerializeField] private AudioClip mergeAudio;
    [SerializeField] private GameBuilderScript gameBuilderScript;

    private void Start() {
        for (int i = 0; i < maxCarCount; i++) {
            bool addCar = CarLevelList[i] != 0;
            carHolders[i].SetHatch(addCar, CarLevelList[i]);
        }
    }

    private void OnTriggerEnter(Collider other) {
        transform.position = Vector3.zero;
    }
    private void OnCollisionEnter(Collision other) {
        transform.position = new Vector3(0f, 0.5f, 0f);
    }

    public void AddCarButtonClick() {
        var price = AddMoney.GetMoney();
        if (!GameBuilderScript.curMoney.CheckSubstractFromCurMoney(price)) {
            PlayNotEnoughMoneySound();
            return;
        }
        for(int i = 0; i < maxCarCount; i++) {
            if (!carHolders[i].hasCar) {
                carHolders[i].AddBaseCar();
                CarLevelList[i] = 1;
                TotalAddCount += 1;
                GameBuilderScript.curMoney.SubtractFromCurMoney(price);
                GetNewAddPrice();
                PlayAddCarSound();
                break;
            }
        }

        if (TotalAddCount == 1) {
            gameBuilderScript.TapTutorial();
        }
    }

    public void MergeCarButtonClick() {
        var price = MergeMoney.GetMoney();
        if (!GameBuilderScript.curMoney.CheckSubstractFromCurMoney(price)) {
            PlayNotEnoughMoneySound();
            return;
        }
        for (int i = 0; i < maxCarCount; i++) {
            if (CarLevelList[i] == 0 || CarLevelList[i] == 9) continue;
            for (int j = maxCarCount - 1; j > i; j--) {
                if (CarLevelList[i] == CarLevelList[j]) {
                    carHolders[i].LevelUpCar();
                    CarLevelList[i] += 1;
                    carHolders[j].RemoveCar();
                    CarLevelList[j] = 0;
                    TotalMergeCount += 1;
                    GameBuilderScript.curMoney.SubtractFromCurMoney(price);
                    GetNewMergePrice();
                    PlayMergedSound();
                    return;
                }
            }
        }
    }

    private void GetNewMergePrice() {
        var curAdd = 20 * TotalAddCount; 
        var coefficient = GameUtils.TurnIntToList(curAdd);
        coefficient.Insert(0, 0);
        coefficient.Insert(0, 0);
        MergeMoney.AddToCurMoney(coefficient);
    }

    private void GetNewAddPrice() {
        var curAdd = 13 * TotalAddCount; 
        var coefficient = GameUtils.TurnIntToList(curAdd);
        coefficient.Insert(0, 0);
        coefficient.Insert(0, 0);
        AddMoney.AddToCurMoney(coefficient);
    }

    private void PlayAddCarSound() {
        audioSource.PlayOneShot(newCarAudio);
    }

    private void PlayNotEnoughMoneySound() {
        audioSource.PlayOneShot(notEnoughMoneyAudio);
    }

    private void PlayMergedSound() {
        audioSource.PlayOneShot(mergeAudio);
    }
}
