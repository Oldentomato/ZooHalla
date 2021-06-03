using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public string s_name { get; set; }
    public int i_dmg { get; set; }
    public WEAPONRATING i_rating { get; set; }
    public float f_attspeed { get; set; }
    public float f_range { get; set; }
    public Sprite S_Icon { get; set; }

    protected Vector2 direction; // 아이템이 튕겨져나오는 위치벡터

    protected abstract void DestroyItem();
    protected virtual void CollPlayer(Collider2D coll,int num)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            GameObject gam = GameObject.Find("ItemMng");
            if (gam.GetComponent<ItemMng>().GetItemInfo(num))
            {
                DestroyItem();
            }
            
        }
    }

    protected virtual Vector2 ItemOutInitial()
    {
        Vector2 RandomVec = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
        //Vector2 tempVec = transform.position * RandomVec;
        //RandomVec = RandomVec.normalized;
        return RandomVec;
    }
    protected virtual void ItemOut(Vector2 desVec2, float speed = 0.3f)
    {
        transform.position = Vector2.Lerp(transform.position, desVec2, speed*Time.deltaTime);
    }
    
}
