using System.Collections.Generic;
public class GameUtils {
    public static List<int> TurnIntToList(int value) {
        var list = new List<int> ();
        while (value != 0) {
            list.Add(value % 10);
            value /= 10;
        }
        return list;
    }

    public static void MultiplyList (List<int> originalList, List<int> multiplierList) {
        var index = 0;
        var curAdd = 0;
        while (originalList.Count > index) {
            if (multiplierList.Count > index) {
                originalList[index] *= multiplierList[index];
                originalList[index] += curAdd;
            }

            if (originalList[index] >= 10) {
                curAdd = originalList[index] / 10;
                originalList[index] %= 10;
            }
            else {
                curAdd = 0;
            }
            
            if (multiplierList.Count > originalList.Count) {
                originalList.Add(0);
            } 
            index += 1;
        }
    }

    public static void AddToList(List<int> originalList, List<int> addList) {
        var index = 0;
        while (originalList.Count > index) {
            if (addList.Count > index) {
                originalList[index] += addList[index];
            }

            if (originalList[index] >= 10) {
                originalList[index] %= 10;
                if (originalList.Count - 1 < index + 1) {
                    originalList.Add(0);
                }
                originalList[index + 1] += 1; 
            }
            if (addList.Count > originalList.Count) {
                originalList.Add(0);
            } 
            index += 1;
        }
    }

    public static void SubtractFromList(List<int> originalList, List<int> subtractList) {
        var index = 0;
        while (originalList.Count > index) {
            if (subtractList.Count > index) {
                originalList[index] -= subtractList[index];
            }

            if (originalList[index] < 0) {
                originalList[index] += 10;
                originalList[index + 1] -= 1; 
            }
            index += 1;
        }

        for (int i = originalList.Count - 1; i > 0; i--) {
            if (originalList[i] == 0) {
                originalList.RemoveAt(i);
            }
            else {
                break;
            }
        }
    }

    public static bool CheckListBigger (List<int> originalList, List<int> otherList) {
        if (originalList.Count > otherList.Count) {
            return true;
        }
        else if (originalList.Count < otherList.Count) {
            return false;
        }
        else {
            for (int i = originalList.Count - 1; i >= 0; i--) {
                if (originalList[i] > otherList[i]) {
                    return true;
                }
                if (originalList[i] < otherList[i]) {
                    return false;
                }
            }
        }
        return true;
    }
}