using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Items item;

    public Inventory inventory;
    public InventoryUI inventoryUI;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventoryUI = GameObject.FindGameObjectWithTag("InventoryUI").GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.itemName);
        inventory.Add(item);
        inventoryUI.ApplyImage();
        Destroy(gameObject);
    }


   
    void OnMouseOver()
    {
        Debug.Log("Mouse is over " + item.itemName);
        if (Input.GetMouseButtonDown(0))
        {
            PickUp();
        }
    }
}
