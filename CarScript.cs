using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Lofelt.NiceVibrations;

public class CarScript : MonoBehaviour
{
    [SerializeField] private List<int> price; 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sellSound;
    [SerializeField] private GameObject priceField;
    private MoneyScript value;

    private void Start() {
        value = new MoneyScript(price);
    }

    public void AddCash() {
        var priceF = Instantiate(priceField);
        priceF.GetComponent<TextMeshPro>().text = "+" + value.ToString() + "<sprite=0>";
        GameBuilderScript.curMoney.AddToCurMoney(value.GetMoney());
        PlayAddCashSound();
        PlayHapticFeedback();
        SaveSystem.SaveGame();
    }

    private void PlayAddCashSound() {
        audioSource.PlayOneShot(sellSound);
    }

    private void PlayHapticFeedback() {
        HapticPatterns.PlayPreset(HapticPatterns.PresetType.SoftImpact);
    }
}
