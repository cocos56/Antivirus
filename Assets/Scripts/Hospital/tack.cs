using UnityEngine;

public class tack : MonoBehaviour {

    public GameObject shellPrefab;
    private KeyCode fireKey = KeyCode.Space;
    public float shellSpeed = 10;
    public int fireInterval = 20;
    public AudioClip shotAudio;
    public GameObject shellexplore;
    
    private static int cnt = 1;


    private Transform firePosition;

    // Use this for initialization
    void Start () {
        firePosition = transform.Find("FirePosition");
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(fireKey))
        {
            cnt = fireInterval;
        }

        if (Input.GetKey(fireKey))
        {
            cnt += 1;
            if (cnt > fireInterval)
            {
                cnt = 1;
                AudioSource.PlayClipAtPoint(shotAudio, transform.position,1f);
                GameObject fireExplore = GameObject.Instantiate(shellexplore, firePosition.position, firePosition.rotation) as GameObject;
                GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
                go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
            }
        }
    }
}
