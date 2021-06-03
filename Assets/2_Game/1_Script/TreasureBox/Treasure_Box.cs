using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Treasure_Box : MonoBehaviour
{
    public float f_distance;
    private GameObject GetPlayer;
    [SerializeField]
    private GameObject[] GetItemGam;
    private GameObject GetAniGam;

    public TextMeshPro GetText;
    private int num;
    private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        Initial();
    }

    private void Initial()
    {
        GetPlayer = GameObject.FindGameObjectWithTag("Player");
        GetText.text = "(Debug)Press E for open Chest";
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        Invoke("DestroyChest", 5f);
    }

    public void GetInfo(GameObject[] getitem, GameObject getani, int rate)
    {
        GetAniGam = getani;
        num = rate;
        GetItemGam = new GameObject[num];
        GetItemGam[0] = getitem[0];
        GetItemGam[1] = getitem[1];
    }

    private void DestroyChest()
    {
        if (isOpen)
        {
            Destroy(gameObject);
        }
        
    }

    private void DetectPlayer()
    {
        float dis = Vector2.Distance(transform.position, GetPlayer.transform.position);
        if(dis <= f_distance && !isOpen)
        {
            if (!GetText.gameObject.activeInHierarchy)
            {
                GetText.gameObject.SetActive(true);               
            }
            OpenChest();
        }
        else if (dis > f_distance && GetText.gameObject.activeInHierarchy)
        {
            GetText.gameObject.SetActive(false);
        }
    }

    private void OpenChest()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < num; i++)
            {
                var temp = Instantiate(GetAniGam, transform.position, Quaternion.identity);
                Instantiate(GetItemGam[i], transform.position, Quaternion.identity, temp.transform);
            }
            
            isOpen = true;
        }
    }
}
