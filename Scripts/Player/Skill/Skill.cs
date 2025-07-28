using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "New Playable Character/Skill")]
public class Skill : ScriptableObject
{
    public string skillname; // ��ų �̸�
    public float damage; // ��ų ������
    public float cooldown; // ��ų ��Ÿ��
    public float moveRange; // ��ų �̵� ����
    public AnimationClip clip; // ��ų �ִϸ��̼� Ŭ��
    public GameObject summonPrefab; // ��ų ��ȯ ������
    [TextArea]
    public string skillDesc; // ��ų ����
}