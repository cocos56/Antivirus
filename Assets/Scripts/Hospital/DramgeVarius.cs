using UnityEngine;

public class DramgeVarius : MonoBehaviour {

    //减血多
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "People")
        {
            print("aaaaa");
            other.SendMessage("PeopleDamage");
        }
    }
    //减血少
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "People")
        {
            other.SendMessage("PeopleDamageSlow");
        }
    }
}
