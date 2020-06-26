using UnityEngine;

namespace town
{
    public class DestroyVirus : MonoBehaviour
    {
        public GameObject exploreVarius;
        public AudioClip exploreSound;
        void DestroyVarius()
        {
            AudioClip.Instantiate(exploreSound, transform.position, transform.rotation);
            GameObject.Instantiate(exploreVarius, transform.position, transform.rotation);
            Destroy(gameObject);//销毁的是脚本所挂的对象
        }
    }
}
