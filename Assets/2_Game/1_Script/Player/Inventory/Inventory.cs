using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform[] GetSlots;
    public List<Item> InvenItem;
    public GameObject ItemIcon;
    [SerializeField]
    //20ĭ���� �ø� �������� �ִ�ϴ� ����; ������ �������� ���ô�
    private int InvenMax = 10;
    private int InvenNum = 0;


    public bool AddItem(Item GetItem)
    {
        
        if(InvenNum < InvenMax)
        {
            InvenItem.Add(GetItem);
            var ItemInfo = Instantiate(ItemIcon, GetSlots[InvenNum]);
            ItemInfo.GetComponent<Image>().sprite = InvenItem[InvenNum].S_Icon;
            ItemInfo.GetComponent<ItemBtn>().GetInfo(GetItem);
            InvenNum++;
            return true;
        }
        else
        {
            Debug.Log("No Slot");
            return false;
        }

    }

}
