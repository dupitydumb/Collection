using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    
    public string header;
    [TextArea(3, 10)]
    public string content;
    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipSystem.Show(header, content);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Hide();
    }
}
