using UnityEngine;

public class ganzi : MonoBehaviour {

     Animation ani;
    
	// Use this for initialization
	void Start () {
        ani = GameObject.Find("ganzi 1").transform.GetComponent<Animation>();
        ani.Play("ganzistand");
    }

 
    // Update is called once per frame
    void Update () {
        if (ani.IsPlaying("ganzistand")&&ani["ganzistand"].normalizedTime>0.6f)
        {
            transform.SendMessage("deleteget1");
            ani.Play("ganzi");
        }
        if(ani.IsPlaying("ganzi") && ani["ganzi"].normalizedTime > 0.6f)
        {
            transform.SendMessage("deleteget2");
            ani.Play("ganzistand");
        }
	}
}
