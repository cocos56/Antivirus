using System.Collections;
using UnityEngine;

public class ItemButton : MonoBehaviour
{ 
    UIButton button;
    KnapsackItem knapaackitem;
    UISprite ItemSprite;
    static public int spriteIndex=-1;
    public string[] itemEqument;


    private void Start()
    {
        button = transform.GetComponent<UIButton>();
        //ui监听者
        UIEventListener.Get(button.gameObject).onClick = OnButtonClick;
        knapaackitem = transform.GetComponent<KnapsackItem>();
        ItemSprite = transform.GetComponent<UISprite>();
    }

    private void OnButtonClick(GameObject go)
    {
        if(go==button.gameObject)
        {
            knapaackitem.DropItem(knapaackitem);
            ////获取装备的下标
            for (int i = 0; i < itemEqument.Length; i++)
            {
                if (Comparer.Equals(ItemSprite.spriteName, itemEqument[i]))
                {
                    spriteIndex = i;
                    break;
                }
            }
        }
    }
}
