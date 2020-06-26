using UnityEngine;

namespace City
{
    public class Attack : MonoBehaviour
    {
        /*    本类用于处理消毒弹的发射
         * 
         */
        public GameObject shellPrefab;
        private KeyCode fireKey = KeyCode.Space;
        public float shellSpeed = 10;
        public int fireInterval = 20;
        public AudioClip shotAudio;

        private Transform firePosition;
        private static int cnt = 1;

        // Start is called before the first frame update
        void Start()
        {
            firePosition = transform.Find("FirePosition");
        }

        // Update is called once per frame
        void Update()
        {
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
                    AudioSource.PlayClipAtPoint(shotAudio, transform.position);
                    GameObject go = GameObject.Instantiate(shellPrefab, firePosition.position, firePosition.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
                }
            }
        }
    }
}
