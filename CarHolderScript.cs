using System.Collections;
using UnityEngine;

public class CarHolderScript : MonoBehaviour
{
    public int carLevel;
    [SerializeField] private GameObject[] carTypes;
    public bool hasCar = false;
    private GameObject curCar;

    public void SetHatch(bool addCar, int level) {
        hasCar = addCar;
        if (addCar) {
            carLevel = level;
            curCar = Instantiate(carTypes[carLevel - 1], transform);
        }
    }

    public void AddBaseCar() {
        hasCar = true;
        carLevel = 1;
        curCar = Instantiate(carTypes[carLevel - 1], transform);
    }

    public void LevelUpCar() {
        carLevel += 1;
        Destroy(curCar);
        curCar = Instantiate(carTypes[carLevel - 1], transform);
    }

    public void RemoveCar() {
        hasCar = false;
        Destroy(curCar);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Gate") && hasCar) {
            curCar.GetComponent<CarScript>().AddCash();
        }
    }
}
