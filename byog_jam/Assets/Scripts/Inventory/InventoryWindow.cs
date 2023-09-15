using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory targetInventory;
    [SerializeField] private RectTransform itemsPanel;
    List<GameObject> drawnIcons = new List<GameObject>();
    private void Start()
    {
        targetInventory.onItemAdd += OnItemAdded;
        Redwaw();
    }
    void OnItemAdded(Item obj) => Redwaw();
    private void Redwaw()
    {
        ClearDrown();
        for (var i = 0; i < targetInventory.items.Count; i++)
        {
            var item = targetInventory.items[i];

            var icon = new GameObject("Icon");
            icon.transform.SetParent(itemsPanel);
            icon.AddComponent<Image>().sprite = item.Icon;
            drawnIcons.Add(icon);

        }
    }
    private void ClearDrown()
    {
        for (int i = 0; i < drawnIcons.Count; i++)
        {
            Destroy(drawnIcons[i]);
        }
        drawnIcons.Clear();
    }
}
