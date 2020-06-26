using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeopleHealth : MonoBehaviour
{
    public int peolpehp = 10000;
    public AudioClip peopleDieAudio;
    public Slider hpSlider;
    private int hpTotal;
    Animator peopleAnimator;
    AnimatorStateInfo stateInfo;

    // Use this for initialization
    void Start()
    {
        hpTotal = peolpehp;
        peopleAnimator = transform.GetComponent<Animator>();
        stateInfo= peopleAnimator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (ItemButton.spriteIndex == 3)
        {
            AddPeopleHealth();
            ItemButton.spriteIndex = -1;
        }
    }

    public void PeopleDamage()
    {
        peolpehp -= Random.Range(80, 100);

        hpSlider.value = (float)peolpehp / hpTotal;
        if (peolpehp <= 0)
        {//收到伤害之后 血量为0 控制死亡效果
            GameObject.Instantiate(peopleDieAudio, transform.position + Vector3.up, transform.rotation);

            AnimatorStateInfo stateInfo = peopleAnimator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Base Layer.run(2D)"))
            {
                if (stateInfo.normalizedTime >= 1f)
                {
                    peopleAnimator.Play("Dead");
                    StartCoroutine(GameEnd());
                }
            }
            else
            {
                peopleAnimator.Play("Dead");
                StartCoroutine(GameEnd());
            }
        }
    }

    public void PeopleDamageSlow()
    {
        peolpehp -= Random.Range(10, 20);
        hpSlider.value = (float)peolpehp / hpTotal;
        if (peolpehp <= 0)
        {//收到伤害之后 血量为0 控制死亡效果
            GameObject.Instantiate(peopleDieAudio, transform.position + Vector3.up, transform.rotation);

            if (stateInfo.IsName("Base Layer.run(2D)"))
            {
                if (stateInfo.normalizedTime >= 1f)
                {
                    peopleAnimator.Play("Dead");
                    StartCoroutine(GameEnd());
                }
            }
            else
            {
                peopleAnimator.Play("Dead");
                StartCoroutine(GameEnd());
            }
        }
    }

    IEnumerator  GameEnd()
    {
        //使用协程
        yield return new WaitForSeconds(3);
        
        End.win = false;
        SceneManager.LoadSceneAsync("End");
    }

    
    public void AddPeopleHealth()
    {
        peolpehp += Random.Range(200, 400);
        if(peolpehp/(float)hpTotal>=100)
        {
            hpSlider.value = 100;
        }
        else
        {
            hpSlider.value = (float)peolpehp / hpTotal;
        }
    }
}
