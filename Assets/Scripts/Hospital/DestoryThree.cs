using UnityEngine;

public class DestoryThree : MonoBehaviour {

    public GameObject beibao;
    public float time;
    float lefttime = 30;
    bool k=false;
    Transform CurrentTransfrom;

    // Use this for initialization
    void Start () {
        CurrentTransfrom = this.gameObject.transform;
        Destroy(this.gameObject, time);
        k = true;
    }

    // Update is called once per frame
    void Update () {
        if(k==true)
        {
            lefttime -= 1;
            if (lefttime < 0)
            {
                GameObject.Instantiate(beibao, CurrentTransfrom.position + Vector3.up, transform.rotation);
                k = false;
            }
        }
    }
}
