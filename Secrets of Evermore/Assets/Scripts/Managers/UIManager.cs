using UnityEngine;
using System.Collections;

public class UIManager
{

    //PUBLIC VARIABLES
    public InventoryPanel InvPanel;
    public CharacterPanel CharPanel;

    public bool IsInventoryActive = false;
    public bool IsCharPanelActive = false;

    //TO INITIALIZE THE PANELS
    public void Initialize()
    {
        //Find and assign
        InvPanel = GameObject.FindGameObjectWithTag("InventoryPanel").GetComponent<InventoryPanel>();
        CharPanel = GameObject.FindGameObjectWithTag("CharacterPanel").GetComponent<CharacterPanel>();

        //Initialize
        InvPanel.Initialize();
        CharPanel.Initialize();

        //Hide the panels
        InvPanel.gameObject.SetActive(false);
        CharPanel.gameObject.SetActive(false);
    }

    public void Refresh()
    {
        //Check if opening inventory
        if (Input.GetKeyDown(KeyCode.I))
        {
            IsInventoryActive = !IsInventoryActive;
            InvPanel.gameObject.SetActive(IsInventoryActive);
        }
        //Check if opening character panel
        if (Input.GetKeyDown(KeyCode.C))
        {
            IsCharPanelActive = !IsCharPanelActive;
            CharPanel.gameObject.SetActive(IsCharPanelActive);
        }

        //Update the inventory
        if (IsInventoryActive)
        {
            InvPanel.Refresh();
        }

        //Update the character panel
        if (IsCharPanelActive)
        {
            CharPanel.Refresh();
        }
    }

}
