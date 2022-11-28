using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curMoneyText;
    [SerializeField] private TextMeshProUGUI curMergeCostText;
    [SerializeField] private TextMeshProUGUI curAddCostText;
    [SerializeField] private Image addButton;
    [SerializeField] private Image mergeButton;
    
    private void LateUpdate() {
        string cashVal = GameBuilderScript.curMoney.ToString();
        curMoneyText.text = cashVal + "<sprite=0>";
        string curAddVal = CarCreatorScript.AddMoney.ToString();
        curAddCostText.text = "<sprite=0>" + curAddVal;  
        string curMergeVal = CarCreatorScript.MergeMoney.ToString();
        curMergeCostText.text = "<sprite=0>" + curMergeVal; 
        string curTapVal= TouchController.tapsPerSecond.ToString();
        EnableAddButton(GameUtils.CheckListBigger(GameBuilderScript.curMoney.Money, CarCreatorScript.AddMoney.Money));
        EnableMergeButton(GameUtils.CheckListBigger(GameBuilderScript.curMoney.Money, CarCreatorScript.MergeMoney.Money));
    }

    private void EnableAddButton(bool state) {
        if (state) {
            addButton.color = new Color(202f / 255f, 161f / 255f, 255f / 255f, 1f);
        }
        else {
            addButton.color = new Color(227f / 255f, 216f / 255f, 241f / 255f, 1f);
        }
    }

    private void EnableMergeButton(bool state) {
        if (state) {
            mergeButton.color = new Color(202f / 255f, 161f / 255f, 255f / 255f, 1f);
        }
        else {
            mergeButton.color = new Color(227f / 255f, 216f / 255f, 241f / 255f, 1f);
        }
    }
}
