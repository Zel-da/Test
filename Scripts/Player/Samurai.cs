using UnityEngine;
using UnityEngine.TestTools;

public class Samurai : PlayerMove
{

    protected override void Skill1()
    {
        switch(stateManager.skill.skillname)
        {
            case "Baldo":
                Baldo();
                break;
            default:
                Debug.LogWarning("�� �� ���� ��ų �̸�: " + stateManager.skill.skillname);
                break;
        }
    }

    private void Baldo() 
    {
        // 1. ���콺 ��ġ ���ϱ�
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z; // 2D ȯ�� ����

        // 2. �÷��̾�� ���콺 ��ġ ���� ���� �� �Ÿ� ���
        Vector2 direction = (mouseWorldPos - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, mouseWorldPos);

        // 3. ���� �̵� �Ÿ� ���� (�ִ� skill1MoveRange������ �̵�)
        float moveDistance = Mathf.Min(distance, stateManager.skill.moveRange);
        Vector3 targetPos = transform.position + (Vector3)(direction * moveDistance);

        // 4. Raycast�� ���̿� �ִ� �� ��� Ž�� �� ����
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, moveDistance, enemyLayerMask);
        bool hitAny = false;
        foreach (var hit in hits)
        {
            EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(stateManager.skill.damage);
                Debug.Log($"��ų1: ��({hit.collider.name})���� ���ظ� �־����ϴ�!");
                hitAny = true;
            }
        }
        if (!hitAny)
        {
            Debug.Log("��ų1: ��λ� ���� �����ϴ�.");
        }

        // 5. �÷��̾ targetPos�� �̵�
        transform.position = targetPos;

        // 6. ����׿� Ray �ð�ȭ
        Debug.DrawRay(transform.position, direction * moveDistance, Color.cyan, 0.5f);

        // 7. �ִϸ��̼� Ʈ���� �� �߰� ����
        if (anim != null)
        {
            anim.SetTrigger("Skill1End");
        }
    }
}
