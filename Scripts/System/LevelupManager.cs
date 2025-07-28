using UnityEngine;

public class LevelupManager : MonoBehaviour
{
    private PlayerStatManager playerstat;

    private void Start()
    {
        playerstat = PlayerStatManager.instance;
    }

    void Update()
    {
        if (playerstat.exp >= playerstat.expToNextLevel)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        playerstat.level++;
        playerstat.exp -= playerstat.expToNextLevel;
        playerstat.expToNextLevel = Mathf.RoundToInt(playerstat.expToNextLevel * 1.2f);
        Debug.Log("������! ���� ����: " + playerstat.level + ", ���� ���������� �ʿ��� ����ġ: " + playerstat.expToNextLevel);
        playerstat.skillPoints++;
    }

    public void AddExp(int amount)
    {
        playerstat.exp += amount;
        Debug.Log("����ġ �߰�: " + amount + ", ���� ����ġ: " + playerstat.exp);
    }
}
