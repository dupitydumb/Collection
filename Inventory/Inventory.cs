using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public static Inventory instance;
    public List<Items> items = new List<Items>();
    // Start is called before the first frame update
    void Start()
    {
        if (instance = null)
        {
            
            instance = this;
            return;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(Items item)
    {
        items.Add(item);
    }
}
