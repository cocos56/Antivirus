﻿using UnityEngine;
/// <summary>
/// 设计随机事件
/// </summary>

namespace town
{
    public class CreatCars : MonoBehaviour 
    {
        float CreatTime = 5f; //设计创造狼的时间
        GameObject Cars; //申请一个病毒的模块


        void Update () 
        {
            CreatTime -= Time.deltaTime;    //开始倒计时
            if (CreatTime<=0)    //如果倒计时为0 的时候
            {
                CreatTime = Random.Range(3, 10);     //随机3到9秒内
                GameObject obj = (GameObject)Resources.Load("Prefabs/WolfNormal");    //加载预制体到内存
                Cars = Instantiate<GameObject>(obj);    //实例化敌人
                Cars.transform.position = new Vector3(Random.Range(408f, 77f),21f,Random.Range(87f,397f));    //随机生成狼的位置
            }
        }
    }
}