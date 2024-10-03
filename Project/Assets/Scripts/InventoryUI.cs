using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{   
    private TextMeshProUGUI keyText;

    // Start is called before the first frame update
    void Start()
    {
        keyText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKeyText(PlayerInventory playerInventory)
    {
        keyText.text = playerInventory.numKeys.ToString() + "/5";
    }


}
