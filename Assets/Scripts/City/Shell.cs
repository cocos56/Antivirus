using UnityEngine;

namespace City
{
    public class Shell : MonoBehaviour {
        /*
         * 用于处理子弹攻击病毒的情况
         */
        public GameObject shellExplosionPrefab;

        public AudioClip shellExplosionAudio;



        public void OnTriggerEnter( Collider collider ) {
            AudioSource.PlayClipAtPoint(shellExplosionAudio,transform.position);
            GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
            GameObject.Destroy(this.gameObject);

            if (collider.tag == "Varius") {
                collider.SendMessage("VariusDamage");
            }
        }

    }
}
