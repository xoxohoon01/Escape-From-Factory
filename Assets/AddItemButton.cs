using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemButton : MonoBehaviour
{
    public Player player;

    public InteractableObjectSO item;
    public void AddItem()
    {
        player.inventory.inventory.AddItem(item);
    }

    public void AddToolbar()
    {
        player.inventory.toolbar.AddItem(player.inventory.inventory.Slots[0]);
    }

}
