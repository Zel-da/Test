using UnityEngine;

[CreateAssetMenu(fileName = "New Playable Character", menuName = "New Playable Character/Character")]
public class PlayableCharInfo : ScriptableObject
{
    public string charName; // ĳ���� �̸�
    public Sprite charIcon; // ĳ���� ������
    public GameObject charPrefab; // ĳ���� ������
    [TextArea]
    public string charDesc; //ĳ���� ����
    public float maxHealth; // �ִ� ü��
    public float moveSpeed; // �̵� �ӵ�
    public float attackRange; // ���� ����
    public float attackDamage; // ���� ���ط�
    public float attackSpeed; // ���� ��Ÿ��
    public float attackAngle; // ���� ����
    public float recoverTime; // �˴ٿ� ȸ�� �ð�
    public Skill[] skills; // ĳ���� ��ų ���
    //public float skill1Damage; // ��ų 1 ������
    //public float skill1Cooldown; // ��ų 1 ��Ÿ��
    //public float skill1MoveRange; // ��ų 1 �̵� ����
}


