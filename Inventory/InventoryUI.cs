using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Inventory inventory;

    public List<Image> InvertorySlots = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {

        ApplyImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ApplyImage()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            InvertorySlots[i].sprite = inventory.items[i].icon;
        }
    }
}
