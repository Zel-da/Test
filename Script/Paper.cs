using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    [SerializeField]
    private GameObject Paper1;
    [SerializeField]
    private GameObject Paper2;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;

    private bool IsTouch = false;

    private bool Showing1 = false;


    Monitor monitor;
    void Start()
    {
        
    }

    void Update()
    {
        ClosePaper();
    }

    public void OpenPaper()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.gameObject.name == ("Room1_Paper1"))
            {
                Paper1.SetActive(true);
                Showing1 = true;
            }
        }

    }

    private void ClosePaper()
    {
        if(Showing1 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Paper1.SetActive(false);
                Showing1 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
    }
}
