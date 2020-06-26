using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class Varius : MonoBehaviour
{


    public List<NavMeshAgent> variusArrary1;
    public List<NavMeshAgent> variusArrary2;
    public Transform target;

    public Transform[] points;
    int rangeIndex;
    public GameObject variusPrefab;
    public GameObject variusPrefab1;

    public float produceTime;
    public float fineTime;

    static bool w = false;
    public UILabel label;
    //记录病毒个数
    int variuscout = 20;
    private int variusDead = 0;
    
    // Use this for initialization
    void Start()
    {
        fineTime = produceTime;
        label.text = variuscout+"";
    }

    // Update is called once per frame
    void Update()
    {
        ContralVariusArray(variusArrary1);
        ContralVariusArray(variusArrary2);
        label.text = variuscout+"";
        if (w == false)
        {
            produceTime = produceTime - 1;
            if (produceTime < 0)
            {
                rangeVarius();
            }
        }
        VariusMove(variusArrary1);
        GameWin();
        VariusMove(variusArrary2);
    }
       
    //控制病毒变化点
    void ContralVariusArray(List<NavMeshAgent> t)
    {
        if(t.Count==0){return;}
        else
        {
            TransFromPiont(t);
        }
    }
    
    //病毒消灭时更新坐标
    void TransFromPiont(List<NavMeshAgent> t)//改变病毒的坐标
    {

        int a = 0;//计算缺失的病毒个数
        for (int i = 0; i < t.Count; i++)
        {
            if (t[i] == null)
            {
                changPoint(t,i);
                variuscout--;
                a++;
            }
        }
        
        // print(a);
        t.RemoveRange(t.Count - a, a);
    }

    //更换坐标
    void changPoint(List<NavMeshAgent> t,int indexpoint)
    {
        for (int i = indexpoint; i < t.Count - 1; i++)
        {
            t[i] = t[i + 1];
        }
    }

    //产生医院内部病毒
    void rangeVarius()
    {
        if (variuscout > 0&&variusDead<19)
        {
            //在医院的病毒
            rangeIndex = Random.Range(0, points.Length - 2);
            GameObject go = GameObject.Instantiate(variusPrefab, points[rangeIndex].transform.position,
                points[rangeIndex].transform.rotation);
            NavMeshAgent to = go.GetComponent<NavMeshAgent>();
            variusArrary1.Add(to);
            produceTime = fineTime;
            variusDead++;
        }
        else
        {
            w = true;
        }
    }

    //产生可以进入医院的病毒
    void rangeVariusOut()
    {
        if (variuscout > 0&&variusDead<19)
        {
            rangeIndex = Random.Range(points.Length - 2, points.Length);
            GameObject go = GameObject.Instantiate(variusPrefab1, points[rangeIndex].transform.position,
                points[rangeIndex].transform.rotation);
            NavMeshAgent to = go.GetComponent<NavMeshAgent>();
            //默认为walked
            to.areaMask += 8;
            variusArrary2.Add(to);
            variusDead++;
        }
        else
        {
            w = true;
        }
    }
    

    //产生不能进入医院的病毒
    void rangeVariusin()
    {
        if (variuscout > 0&&variusDead<19)
        {
            rangeIndex = Random.Range(points.Length - 2, points.Length);
            GameObject go = GameObject.Instantiate(variusPrefab1, points[rangeIndex].transform.position,
                points[rangeIndex].transform.rotation);
            NavMeshAgent to = go.GetComponent<NavMeshAgent>();
            variusArrary2.Add(to);
            variusDead++;
        }
        else
        {
            w = true;
        }
    }

    //病毒移动
    public void VariusMove(List<NavMeshAgent> t)
    {
        if (t.Count == 0) { return; }
        for (int i = 0; i < t.Count; i++)
        {
            if (t[i] != null)
            {
                t[i].SetDestination(target.position);
            }
        }
    }

    public void deleteget1()
    {
        rangeVariusOut();
    }

    public void deleteget2()
    {
        rangeVariusin();
    }

    public void EndVarius()
    {
        if (variusArrary2.Count == 0) { return; }
        for (int i = 0; i < variusArrary2.Count; i++)
        {
            variusArrary2[i].isStopped = true;
        }
        if (variusArrary1.Count == 0) { return; }
        for (int i = 0; i < variusArrary1.Count; i++)
        {
            variusArrary1[i].isStopped = true;
        }
    }
    
    //游戏胜利场景
    void  GameWin() 
    {
        if (variuscout == 0) 
        {
            End.win = true;
            variuscout = 20;
            SceneManager.LoadSceneAsync("End");
        }
    }
}
