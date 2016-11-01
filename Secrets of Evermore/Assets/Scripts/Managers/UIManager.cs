using UnityEngine;
using System.Collections;

public class UIManager {

    public InventoryPanel InvPanel;
    CharacterPanel CharPanel;

    public bool IsInventoryActive = false;

    public void Initialize()
    {
        InvPanel = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<InventoryPanel>();
        //CharPanel = GameObject.FindGameObjectWithTag("CharacterPanel").GetComponent<CharacterPanel>();
        InvPanel.Initialize();

        //Hide the panels
        InvPanel.gameObject.SetActive(false);
    }

    public void Refresh()
    {
        //Check if opening inventory
        if(Input.GetKeyDown(KeyCode.I))
        {
            IsInventoryActive = !IsInventoryActive;
            InvPanel.gameObject.SetActive(IsInventoryActive);
        }
        //Update the inventory
        if(IsInventoryActive)
        {
            InvPanel.Refresh();
        }
    }

}
