using UnityEngine;

public class MyDragDropItem : UIDragDropItem
{ 
    //拖拽结束释放
	protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);

        print(surface);
    }
}
