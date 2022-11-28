using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoneyScript {
    [SerializeField] public List<int> Money;
    private string[] nameOfNumber = {"", "k", "m", "b", "t", "q"};

    public MoneyScript(List<int> money)
    {
        Money = money;
    }

    public List<int> GetMoney() {
        return Money;
    }

    public void SetMoney(List<int> money) {
        Money = money;
    }
    
    public void AddToCurMoney(List<int> money) {
        GameUtils.AddToList(Money, money);
    }

    public bool CheckSubstractFromCurMoney(List<int> money) {
        return GameUtils.CheckListBigger(Money, money);
    }
    
    public void SubtractFromCurMoney(List<int> money) {
        GameUtils.SubtractFromList(Money, money);
    }

    public void MultiplyMoney(List<int> money) {
        GameUtils.MultiplyList(Money, money);
    }

    public override string ToString() {
        var curUnit = Money.Count - 1;
        var digit = (curUnit - 2) / 3;
        string cashVal;
        if (curUnit == 0) {
            return  Money[curUnit].ToString();
        } else if (curUnit == 1) {
            return Money[curUnit].ToString() + Money[curUnit - 1].ToString();
        }
        
        if (curUnit % 3 == 0) {
            cashVal = Money[curUnit].ToString() + Money[curUnit - 1].ToString() + "." + Money[curUnit - 2].ToString() + nameOfNumber[digit];
        } else if (curUnit % 3 == 1) {
            cashVal = Money[curUnit].ToString() + Money[curUnit - 1].ToString() + Money[curUnit - 2].ToString() + nameOfNumber[digit];
        } else {
            cashVal = Money[curUnit].ToString() + "." + Money[curUnit - 1].ToString() + Money[curUnit - 2].ToString() + nameOfNumber[digit];
        }
        return cashVal;
    }
}