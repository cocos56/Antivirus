using UnityEngine;
using UnityEngine.UI;

namespace City
{
    public class Health : MonoBehaviour
    {
        /*
         * 处理病毒的血量
         */
        public int hp = 100;
        public GameObject tankExplosion;
        public AudioClip tankExplosionAudio;

        public Slider hpSlider;

        private int hpTotal;

        // Start is called before the first frame update
        void Start()
        {
            hpTotal = hp;
            City.virus+=1;
        }

        void VariusDamage()
        {
            // if (hp <= 0) return;
            hp -= Random.Range(10, 20);
            hpSlider.value = (float)hp / hpTotal;
            City.time += 2;
            if (hp <= 0)
            {//收到伤害之后 血量为0 控制死亡效果
                City.virus -= 1;
                City.time += 20;
                AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
                GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}