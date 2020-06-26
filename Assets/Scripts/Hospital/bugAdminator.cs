using UnityEngine;

public class bugAdminator : MonoBehaviour {

    public UISprite knapsackk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="cube1")
        {

            Destroy(other.gameObject);
            knapsackk.SendMessage("PickUp");
        }
    }
}
