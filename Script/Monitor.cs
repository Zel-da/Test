using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    //✅
    [SerializeField] public PlayerController playerController;
    //필요한 컴포넌트
    [SerializeField]
    private GameObject Room1_Monitor;
    [SerializeField]
    private GameObject Room1MQ;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;

    // bool값
    private bool Openscreen = false;
    public bool IsTouch = false;

    public Door door;
    public Paper paper;
    public Case Case;
    void Start()
    {

    }

    void Update()
    {
        TryOpenScreen();
        CloseText();
        TryCloseScreen();
        OpenPaper();
        TryOpenCase();
    }


    //모니터 보기
    private void TryOpenScreen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("PC"))
            {
                TextUI.text = " 화면을 보려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playerController.SetCanMove(false);  // 이동 금지
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                    Room1MQ.SetActive(true);
                    Openscreen = true;
                }


            }
        }
    }

    //모니터 닫기
    private void TryCloseScreen()
    {
        if (Openscreen == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true); //이동 허용
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
                Room1MQ.SetActive(false);
                Openscreen = false;
            }
        }

    }

    //상호작용키 지우기
    public void CloseText()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (!hit.transform.CompareTag("PC") && !hit.transform.CompareTag("Door") && !hit.transform.CompareTag("Paper") && !hit.transform.CompareTag("Case"))
            {
                TextUI.text = " ";
            }
        }
        else
        {
            TextUI.text = "";
        }
    }

    //종이보는 상호작용키 띄우기
    private void OpenPaper()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Paper"))
            {
                TextUI.text = "종이를 보려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playerController.SetCanMove(false);  // 이동 금지
                    paper.OpenPaper();
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    playerController.SetCanMove(true);  // 이동 허용
                    Text_UI.SetActive(true);
                    Crosshair.SetActive(true);
                }

            }
        }
    }

    //사물함 열기
    private void TryOpenCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow);
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Case"))
            {
                TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playerController.SetCanMove(false);  // 이동 금지
                    Case.OpenCase();
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }

            }
        }
    }
}