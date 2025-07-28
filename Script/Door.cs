using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
    //✅
    [SerializeField] PlayerController playerController;
    // 문 오브젝트 입력
    [SerializeField]
    private GameObject Room1_Door;
    [SerializeField]
    private GameObject Room2_Door;
    [SerializeField]
    private GameObject Room3_Door;
    [SerializeField]
    private GameObject Room4_Door;
    [SerializeField]
    private GameObject Room5_Door;
    [SerializeField]
    private GameObject Room6_Door;
    [SerializeField]
    private GameObject Room7_Door;

    [SerializeField]
    private GameObject Bath1_Door;
    [SerializeField]
    private GameObject Bath2_Door;
    [SerializeField]
    private GameObject Bath3_Door;
    [SerializeField]
    private GameObject Bath4_Door;
    [SerializeField]
    private GameObject Bath5_Door;
    [SerializeField]
    private GameObject Bath6_Door;

    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_DoorQ;
    [SerializeField]
    private GameObject Room3_DoorQ;
    [SerializeField]
    private GameObject Room4_DoorQ;
    [SerializeField]
    private GameObject Room5_DoorQ;
    [SerializeField]
    private GameObject Room6_DoorQ;
    [SerializeField]
    private GameObject Room7_DoorQ;

    // 문 열림 판단
    private bool Opening1 = false;
    private bool Opening2 = false;
    private bool Opening3 = false;
    private bool Opening4 = false;
    private bool Opening5 = false;
    private bool Opening6 = false;
    private bool Opening7 = false;

    private bool BOpening1 = false;
    private bool BOpening2 = false;
    private bool BOpening3 = false;
    private bool BOpening4 = false;
    private bool BOpening5 = false;
    private bool BOpening6 = false;

    // 문 퀴즈 해결 판단
    public bool Solve1 = false;
    private bool Solve3 = false;
    private bool Solve4 = false;
    private bool Solve5 = false;
    private bool Solve6 = false;
    private bool Solve7 = false;

    // 문 퀴즈 나타났는지 판단
    public bool Show1 = false;
    private bool Show3 = false;
    private bool Show4 = false;
    private bool Show5 = false;
    private bool Show6 = false;
    private bool Show7 = false;

    [SerializeField]
    private OpenDoor Room1_OpenDoor;
    [SerializeField]
    private OpenDoor Room2_OpenDoor;
    /*[SerializeField]
    private OpenDoor Room3_OpenDoor;
    [SerializeField]
    private OpenDoor Room4_OpenDoor;
    [SerializeField]
    private OpenDoor Room5_OpenDoor;
    [SerializeField]
    private OpenDoor Room6_OpenDoor;
    [SerializeField]
    private OpenDoor Room7_OpenDoor;*/


    [SerializeField]
    private OpenDoor Bath1_OpenDoor;
    [SerializeField]
    private OpenDoor Bath2_OpenDoor;
    [SerializeField]
    private OpenDoor Bath3_OpenDoor;
    [SerializeField]
    private OpenDoor Bath4_OpenDoor;
    [SerializeField]
    private OpenDoor Bath5_OpenDoor;
    [SerializeField]
    private OpenDoor Bath6_OpenDoor;
    // UI
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    private TextMeshProUGUI TextUI;

    //문 접촉 판단
    private bool IsTouch = false;
    [SerializeField]
    OpenDoor opendoor;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TryOpen();

    }

    public void TryOpen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
            if (hit.transform.CompareTag("Door"))
            {
                if (hit.transform.gameObject.name == ("Room1_Door"))
                {
                    if (Opening1 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            playerController.SetCanMove(false);  // 이동 금지
                            if (Solve1 == false)
                            {
                                Room1_DoorQ.SetActive(true);
                                Show1 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve1 == true)
                            {
                                playerController.SetCanMove(true);  // 이동 허용
                                Room1_OpenDoor.StartCoroutine(Room1_OpenDoor.DoorMoveOpen());
                                Opening1 = true;
                            }


                        }
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            Debug.Log("꺼짐");
                            playerController.SetCanMove(true);  // 이동 허용
                            Room1_DoorQ.SetActive(false);
                            Show1 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                    else if (Show1 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            Debug.Log("꺼짐");
                            playerController.SetCanMove(true);  // 이동 허용
                            Room1_DoorQ.SetActive(false);
                            Show1 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                    else if (Opening1 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room1_OpenDoor.StartCoroutine(Room1_OpenDoor.DoorMoveClose());
                            Opening1 = false;
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("Room2_Door"))
                {
                    if (Opening2 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room2_OpenDoor.StartCoroutine(Room2_OpenDoor.DoorMoveOpen());
                            Opening2 = true;
                        }
                    }

                    else if (Opening2 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room2_OpenDoor.StartCoroutine(Room2_OpenDoor.DoorMoveClose());
                            Opening2 = false;
                        }
                    }

                }

                else if (hit.transform.gameObject.name == ("Room3_Door"))
                {
                    OpenDoor3();
                }

                else if (hit.transform.gameObject.name == ("Room4_Door"))
                {
                    OpenDoor4();
                }

                else if (hit.transform.gameObject.name == ("Room5_Door"))
                {
                    OpenDoor5();
                }

                else if (hit.transform.gameObject.name == ("Room6_Door"))
                {
                    OpenDoor6();
                }

                else if (hit.transform.gameObject.name == ("Room7_Door"))
                {
                    OpenDoor7();
                }

                else if (hit.transform.gameObject.name == ("ToiletDoor1"))
                {
                    if (BOpening1 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath1_OpenDoor.StartCoroutine(Bath1_OpenDoor.DoorMoveOpen());
                            BOpening1 = true;
                        }
                    }

                    else if (BOpening1 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath1_OpenDoor.StartCoroutine(Bath1_OpenDoor.DoorMoveClose());
                            BOpening1 = false;
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("ToiletDoor2"))
                {
                    if (BOpening2 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath2_OpenDoor.StartCoroutine(Bath2_OpenDoor.DoorMoveOpen());
                            BOpening2 = true;
                        }
                    }

                    else if (BOpening2 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath2_OpenDoor.StartCoroutine(Bath2_OpenDoor.DoorMoveClose());
                            BOpening2 = false;
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("ToiletDoor3"))
                {
                    if (BOpening3 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath3_OpenDoor.StartCoroutine(Bath3_OpenDoor.DoorMoveOpen());
                            BOpening3 = true;
                        }
                    }

                    else if (BOpening3 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath3_OpenDoor.StartCoroutine(Bath3_OpenDoor.DoorMoveClose());
                            BOpening3 = false;
                        }
                    }
                }
                else if (hit.transform.gameObject.name == ("ToiletDoor4"))
                {
                    if (BOpening4 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath4_OpenDoor.StartCoroutine(Bath4_OpenDoor.DoorMoveOpen());
                            BOpening4 = true;
                        }
                    }

                    else if (BOpening4 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath4_OpenDoor.StartCoroutine(Bath4_OpenDoor.DoorMoveClose());
                            BOpening4 = false;
                        }
                    }
                }
                else if (hit.transform.gameObject.name == ("ToiletDoor5"))
                {
                    if (BOpening5 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath5_OpenDoor.StartCoroutine(Bath5_OpenDoor.DoorMoveOpen());
                            BOpening5 = true;
                        }
                    }

                    else if (BOpening5 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath5_OpenDoor.StartCoroutine(Bath5_OpenDoor.DoorMoveClose());
                            BOpening5 = false;
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("ToiletDoor6"))
                {
                    if (BOpening6 == false)
                    {
                        TextUI.text = "문을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath6_OpenDoor.StartCoroutine(Bath6_OpenDoor.DoorMoveOpen());
                            BOpening6 = true;
                        }
                    }

                    else if (BOpening6 == true)
                    {
                        TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Bath6_OpenDoor.StartCoroutine(Bath6_OpenDoor.DoorMoveClose());
                            BOpening6 = false;
                        }
                    }
                }
            }
    }

    public void OpenDoor2()
    {
        if (Opening2 == false)
        {

        }

        if (Opening2 == true)
        {
            opendoor.DoorMoveOpen();
        }
    }

    public void OpenDoor3()
    {
        if (Opening3 == false)
        {

        }

        if (Opening3 == true)
        {
            opendoor.DoorMoveOpen();
        }
    }
    public void OpenDoor4()
    {
        if (Opening4 == false)
        {

        }

        if (Opening4 == true)
        {
            opendoor.DoorMoveOpen();
        }
    }
    public void OpenDoor5()
    {
        if (Opening5 == false)
        {

        }

        if (Opening5 == true)
        {
            opendoor.DoorMoveOpen();
        }
    }
    public void OpenDoor6()
    {
        if (Opening6 == false)
        {

        }

        if (Opening6 == true)
        {
            opendoor.DoorMoveOpen();
        }
    }
    public void OpenDoor7()
    {
        if (Opening7 == false)
        {

        }

        if (Opening7 == true)
        {
            opendoor.DoorMoveOpen();
        }


    }


}