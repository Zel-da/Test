using UnityEngine;

public class Case : MonoBehaviour
{
    //✅
    [SerializeField] PlayerController playerController;
    [SerializeField]
    private GameObject case1;
    [SerializeField]
    private GameObject case2;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;

    private bool IsTouch = false;

    private bool Showing1 = false;
    private bool Showing2 = false;
    void Start()
    {

    }


    void Update()
    {
        CloseCase();
    }
    public void OpenCase()
    {
        Debug.Log("opencase");
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            Debug.Log($"touched: {hit.transform.gameObject.name}");

            if (hit.transform.gameObject.name == ("Room1_Case1"))
            {
                Debug.Log("open");
                playerController.SetCanMove(false);  // 이동 금지
                case1.SetActive(true);
                Showing1 = true;
            }

            else if (hit.transform.gameObject.name == ("Room1_Case2"))
            {
                playerController.SetCanMove(false);  // 이동 금지
                case2.SetActive(true);
                Showing2 = true;
            }
        }

    }

    private void CloseCase()
    {
        if (Showing1 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);  // 이동 허용
                case1.SetActive(false);
                Showing1 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
        if (Showing2 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);  // 이동 허용
                case2.SetActive(false);
                Showing2 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
    }
}