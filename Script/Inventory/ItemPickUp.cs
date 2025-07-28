using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    public Monitor monitor;
    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    void Update()
    {
        FindItem();
    }

    private void FindItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (monitor.IsTouch)
        {
            if (hit.transform.CompareTag("Item"))
            {
                monitor.TextUI.text = "아이템을 획득하려면 (Z)키를 누르세요";

                if (Input.GetKeyDown(KeyCode.Z))
                {

                    ItemPickUp itemPickUp = hit.transform.GetComponent<ItemPickUp>();

                    if (itemPickUp != null && inventory != null)
                    {
                        inventory.AcquireItem(itemPickUp.item);
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            monitor.TextUI.text = "";
        }
    }
}