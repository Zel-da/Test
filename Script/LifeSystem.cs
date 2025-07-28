using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    private int currentHP;
    [SerializeField] private Image[] heartImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHeartUI();
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1)) // 숫자1 누르면 hp 1 감소(임시)
            ChangeHP(-1);

        if (Input.GetKeyDown(KeyCode.Alpha2)) // 2: 증가
            ChangeHP(1);
    }

    public void ChangeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UpdateHeartUI();

        if (currentHP == 0)
        {
            Debug.Log("Game Over");

        }
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHP)
                heartImages[i].sprite = fullHeart;
            else
                heartImages[i].sprite = emptyHeart;
        }
    }
}