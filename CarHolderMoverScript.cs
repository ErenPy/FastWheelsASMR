using UnityEngine;
using System.Collections.Generic;
using PathCreation;

public class CarHolderMoverScript : MonoBehaviour
{
    public PathCreator pathCreator;
    private float speed = 2.6f;
    public GameObject[] carHolders;
    private float distanceTraveled;
    private List<Marker> oldPosList = new List<Marker>();
    [SerializeField] private float distanceBetween;
    // Update is called once per frame
    private void FixedUpdate()
    {
        oldPosList.Add(new Marker(carHolders[0].transform.position, carHolders[0].transform.rotation));
        int carHolderCount = 0;
        for (int i = oldPosList.Count - 1; i >= 0; i--) {
            if (carHolderCount == 9) {
                oldPosList.RemoveRange(0, i);
                break;
            }
            if (Vector3.Distance(carHolders[carHolderCount].transform.position, oldPosList[i].position) > distanceBetween) {
                carHolders[carHolderCount + 1].transform.SetPositionAndRotation(oldPosList[i].position, oldPosList[i].rotation);
                carHolderCount += 1; 
            }
        }
        var curSpeed = (TouchController.tapsPerSecond / 3f) + speed;
        distanceTraveled += curSpeed * Time.fixedDeltaTime;
        carHolders[0].transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        carHolders[0].transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTraveled);
    }
}

public class Marker {
    public Vector3 position;
    public Quaternion rotation;

    public Marker(Vector3 pos, Quaternion rot) {
        position = pos;
        rotation = rot;
    }
}
