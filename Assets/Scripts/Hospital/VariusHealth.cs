using UnityEngine;
using UnityEngine.UI;

public class VariusHealth : MonoBehaviour {
    public int hp = 100;
    public GameObject VariusExplosion;
    public AudioClip VariusExplosionAudio;

    public Slider hpSlider;

    private int hpTotal;

    // Use this for initialization
    void Start()
    {
        hpTotal = hp;
    }

    void VariusDamage()
    {
        if (hp <= 0) return;
        hp -= Random.Range(10, 20);
        hpSlider.value = (float)hp / hpTotal;
        if (hp <= 0)
        {//收到伤害之后 血量为0 控制死亡效果
            AudioSource.PlayClipAtPoint(VariusExplosionAudio, transform.position);
            GameObject.Instantiate(VariusExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
