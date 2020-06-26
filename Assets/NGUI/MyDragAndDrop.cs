using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDragAndDrop : UIDragDropItem
{
    //该方法用于获取拖拽的物体释放拖拽时，该物体所碰撞的对象
    //所以我们前面需要给Cell和Obj都添加Box Collider
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        //判断获取碰撞的对象的tag是否为Cell
        if (surface.tag == "Cell")
        {
            //将Obj放到碰撞的Cell的子列表中
            transform.parent = surface.transform;

            //设置Obj的相对于Cell的坐标为0
            transform.localPosition = Vector3.zero;
        }
        else
        {
            //如果碰撞的对象不是Cell，就将Obj放到tag为UIRoot的对象子列表中，解除Obj和Cell父子关系
            transform.parent = GameObject.FindGameObjectWithTag("UIRoot").transform;
        }

    }

}
