using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TooltipSystem : MonoBehaviour
{

    private static TooltipSystem current;
    public Tooltip tooltip;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
        Hide();
    }

    // Update is called once per frame
    public static void Show(string header, string content)
    {
        
        current.tooltip.gameObject.SetActive(true);
        current.tooltip.SetText(header, content);

    }

    public static void Hide()
    {
        current.tooltip.gameObject.SetActive(false);

    }
}
