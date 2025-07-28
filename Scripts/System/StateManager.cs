using UnityEngine;

public class StateManager : MonoBehaviour
{
    public PlayableCharInfo[] playableCharInfo;
    public string currentPlayCharName;
    public string currentPlayerSkill;

    public float hp; // ���� �÷��̾��� ü��
    [Header("Player Stats")]
    public float Maxhp; // �÷��̾��� �ִ� ü��
    public float speed;
    public float attackRange;
    public float attackSpeed; //1�ʴ� �����Ҽ� �ִ� Ƚ��
    public float attackDamage;
    public float recoverTime; // �˴ٿ� ���¿��� ȸ���� �ɸ��� �ð�
    public float attackAngle; // ���� ����
    public Skill skill; // ���� �÷��̾��� ��ų ����

    public bool isKnockDown = false; // �÷��̾ �˴ٿ� ��������  ����
    public bool isDefend = false; // �÷��̾ ��� �������� ����

    void Start()
    {
        for (int i = 0; i < playableCharInfo.Length; i++)
        {
            if (playableCharInfo[i].charName == currentPlayCharName)
            {
                Instantiate(playableCharInfo[i].charPrefab, transform.position, Quaternion.identity);
                
                
                Maxhp = playableCharInfo[i].maxHealth;
                hp = Maxhp; // �÷��̾��� ü���� �ʱ�ȭ
                speed = playableCharInfo[i].moveSpeed;
                attackRange = playableCharInfo[i].attackRange;
                attackDamage = playableCharInfo[i].attackDamage;
                attackSpeed = playableCharInfo[i].attackSpeed;
                recoverTime = playableCharInfo[i].recoverTime;
                attackAngle = playableCharInfo[i].attackAngle;
                for (int j = 0; j < playableCharInfo[i].skills.Length; j++)
                {
                    if (playableCharInfo[i].skills[j].skillname == currentPlayerSkill)
                    {
                        skill = playableCharInfo[i].skills[j];
                    }
                }
                //skill1Damage = playableCharInfo[i].skill1Damage;
                //skill1Cooldown = playableCharInfo[i].skill1Cooldown;
                //skill1MoveRange = playableCharInfo[i].skill1MoveRange;
                Debug.Log($"Current Playable Character: {playableCharInfo[i].charName}");
            }
        }
    }

    void Update()
    {
        if (hp > 0)
        {
            isKnockDown = false; // �÷��̾ �˴ٿ� ���°� �ƴϸ� false�� ����
        }
        else
        {
            isKnockDown = true; // �÷��̾ �˴ٿ� ���·� ��ȯ
        }
    }

    public void TakeDamage(float damage) //�÷��̾ ���� ������ ȣ��
    {
        if (isDefend) // ��� ������ ��
        {
            Debug.Log("��� ��! ���ذ� ��ȿ�Ǿ����ϴ�.");
            return; // ���ظ� ���� ����
        }
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        hp -= damage;
        playerMove.anim.SetTrigger("TakeDamage");
        Debug.Log("�÷��̾ " + damage + "�� ���ظ� �޾ҽ��ϴ�. ���� ü��: " + hp);
    }

    public void Recover()
    {
        // �˴ٿ� ���¿��� ȸ�� ����
        PlayerMove playerMove = FindFirstObjectByType<PlayerMove>();
        hp = Maxhp; // ü���� �ִ�ġ�� ȸ��
        playerMove.anim.SetTrigger("Recover"); // �˴ٿ� �ִϸ��̼� Ʈ����
    }
}
