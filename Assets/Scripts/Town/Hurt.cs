using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace town
{
    public class Hurt : MonoBehaviour
    {
        public Slider slider;
        public int hp = 100;
        private int hptal;
        public GameObject defeat;
        
        private void Start()
        {
            hptal = hp;
        }

        public  void VariusDamage()
        {
            
            if (hp <= 0) return;
            hp -= 25;
            slider.value =(float) hp / 100;
            if (hp <= 0)
            {//收到伤害之后 血量为0 控制死亡效果
                //AudioSource.PlayClipAtPoint(tankExplosionAudio, transform.position);
                //GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
                // SceneManager.LoadScene(1);//跳转到失败界面
                defeat.SetActive(true);
            }
        }
    }
}