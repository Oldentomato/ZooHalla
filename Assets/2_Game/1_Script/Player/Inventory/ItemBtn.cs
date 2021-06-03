using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBtn : MonoBehaviour
{
    private RectTransform ItemTrans;
    //private Item GetItemInfo;
    public GameObject GetItemInfoGam;
    public Text GetItemInfoText;

    private void Start()
    {
        ItemTrans = GetComponent<RectTransform>();
    }
    public void SelectedItem()
    {
        transform.position = Input.mousePosition;
    }

    public void GetInfo(Item item)
    {
        //GetItemInfo = item;
        GetItemInfoText.text =
            item.s_name
            + "\n\n"
            + item.i_rating
            + " 등급 \n\n"
            + item.i_dmg
            + " 데미지 \n\n"
            + "공격속도: "
            + item.f_attspeed
            + "\n\n";

    }

    public void ShowItemInfo()
    {
        GetItemInfoGam.SetActive(true);
    }
    public void CloseItemInfo()
    {
        GetItemInfoGam.SetActive(false);
    }

    public void DropedItem()
    {

        GameObject temp = GetClicked2DObject((-1) - (1 << LayerMask.NameToLayer("ItemSlot")));
        if (temp != null)
        {
            if (temp.CompareTag("ItemSlot"))
            {
                transform.SetParent(temp.transform);
            }
            else if (temp.CompareTag("ItemIcon"))
            {
                Debug.Log(temp.name);
            }

        }
        else
        {
            Debug.Log("Cant Find Collider");
        }
        ItemTrans.anchoredPosition = Vector2.zero;
    }


    private GameObject GetClicked2DObject(int layer = -1)
    {
        GameObject target = null;
        //int mask = 1 << layer;


        Vector2 pos = Input.mousePosition;
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit;

        hit = layer == -1 ? Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity) :
                            Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, layer);

        if (hit)
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

}
