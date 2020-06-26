using UnityEngine;

public class KnapSet : MonoBehaviour {

    public GameObject[] Cells;
    public string[] equipmentsName;
    public GameObject item;
    public UILabel content;//提示内容
    public UILabel equipmentcount;

    // Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
        {
            PickUp(); 
        }
        AdminatorKnosCount();
    }

    public void  PickUp()
    {
        int index = Random.Range(0, equipmentsName.Length);

        string name = equipmentsName[index];

        bool isFind = false;

        for(int i=0;i<Cells.Length; i++)
        {
            //判断当前格子有没有物品，如果有的话，判断当前游戏物品的名称
            if(Cells[i].transform.childCount>0&&Cells[i].transform.childCount<=2)
            {

                KnapsackItem item = Cells[i].GetComponentInChildren<KnapsackItem>();
                if(item.sprite.spriteName==name&&item.count<=2)
                {
                    isFind = true;
                    item.AddCount(1);
                    break;
                }
            }
            
            else if(Cells[i].transform.childCount == 3&&i==Cells.Length-1)
            {
                content.text = "背包装满！不能存放： " + name + "物品!";
                break;
            }
        }
        if (isFind == false)
        {
            for (int i = 0; i < Cells.Length; i++)
            {
                if (Cells[i].transform.childCount == 0)
                {
                    //当前位置没有物品
                    //添加我们新捡起的物品
                    //指定物体添加物体
                    GameObject go = NGUITools.AddChild(Cells[i], item);
                    go.GetComponent<UISprite>().spriteName = name;
                    go.transform.localPosition = Vector3.zero;
                    break;
                }
                else if(Cells[i].transform.childCount!= 0&&i==Cells.Length-1)
                {
                    content.text = "背包装满！不能存放： " + name + "物品!";
                    break;
                }
            }
        }
    }

    //int RemoveContent()
    //{

    //    yield return 20;
    //    content.text = "";
    //}
    void AdminatorKnosCount()
    {
        int count = 0;
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].transform.childCount > 0)
            {
                KnapsackItem item = Cells[i].GetComponentInChildren<KnapsackItem>();
                count += int.Parse(item.label.text);
                equipmentcount.text = count + "/18";
            }
        }
    }
}
