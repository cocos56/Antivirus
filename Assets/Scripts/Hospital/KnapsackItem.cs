using UnityEngine;

public class KnapsackItem : UIDragDropItem
{
    public UISprite sprite;
    public UILabel label;
    public int count = 1;

    public void AddCount(int number=1)
    {
        count += number;
        label.text = count+"";
    }

    public void ReduceCount(int number=1)
    {
        count += number;
        label.text = count + "";
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        
        if(surface.tag=="Cell")
        {
            this.transform.parent = surface.transform;
            this.transform.localPosition = Vector3.zero;
        }
        else if(surface.tag=="KnapsackItem")
        {
            Transform parent = surface.transform.parent;
            surface.transform.parent = this.transform.parent;
            surface.transform.localPosition = Vector3.zero;

            this.transform.parent = parent;
            this.transform.localPosition = Vector3.zero;
        }
    }
    
    public void DropItem(KnapsackItem ItemObject)
    {
        if(ItemObject.count == 1)
        {
            Destroy(ItemObject.gameObject, 0.5f);
        }
        if(ItemObject.count > 1)
        {
            ItemObject.count -= 1;
            ItemObject.label.text = count+"";
        }
    }
}
