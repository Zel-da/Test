using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorPassword : MonoBehaviour
{
    //✅
    [SerializeField] PlayerController playerController;
    public Door door;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    // room1의 방 자물쇠 숫자
    [SerializeField]
    private TextMeshProUGUI Room1text1;
    [SerializeField]
    private TextMeshProUGUI Room1text2;
    [SerializeField]
    private TextMeshProUGUI Room1text3;
    [SerializeField]
    private TextMeshProUGUI Room1text4;
    //room1의 자물쇠의 정답
    private int answer1 = 3;
    private int answer2 = 1;
    private int answer3 = 2;
    private int answer4 = 0;
    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_DoorQ;
    void Start()
    {

    }


    void Update()
    {
        Door1PassWord();
    }
    private void Door1PassWord()
    {
        int num1 = int.Parse(Room1text1.text);
        int num2 = int.Parse(Room1text2.text);
        int num3 = int.Parse(Room1text3.text);
        int num4 = int.Parse(Room1text4.text);
        if (num1 == answer1 && num2 == answer2 && num3 == answer3 && num4 == answer4)
        {
            playerController.SetCanMove(true);  // 이동 허용
            door.Solve1 = true;
            Room1_DoorQ.SetActive(false);
            door.Show1 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            door.Solve1 = false;
        }
    }


}