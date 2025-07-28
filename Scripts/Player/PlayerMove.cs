using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �÷��̾��� �Ӽ�
    [SerializeField] protected LayerMask enemyLayerMask; // Inspector���� Enemy ���̾ ����

    protected bool canMove = true; // �÷��̾ �̵� �������� ����
    
    protected float currentAttackCooldown;
    protected float currentSkill1Cooldown;
    public Animator anim;
    protected SpriteRenderer spriteRenderer;
    protected StateManager stateManager;


    void Start()
    {
        currentAttackCooldown = 1f;
        currentSkill1Cooldown = 0f; // ��ų 1 ��Ÿ�� �ʱ�ȭ
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        stateManager = FindFirstObjectByType<StateManager>();
        if (anim == null)
        {
            Debug.LogError("Animator component not found on Player object.");
        }
    }

    void Update()
    {
        if (!stateManager.isKnockDown) 
        {
            
            TryMove();
            TryAttack();
            TrySkill1();
        }
        else
        {
            StartCoroutine(KnockDownRoutine());
        }

    }

    protected virtual void TryMove()
    {
        if (canMove)
        {
            Move();
        }
    }
    protected virtual void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical, 0).normalized;
        if (direction.magnitude >= 0.1f)
        {
            transform.position += direction * stateManager.speed * Time.deltaTime;
            anim.SetBool("Running", true);

            // �̵� ���⿡ ���� �ٶ󺸴� ���� ����
            if (horizontal != 0)
            {
                spriteRenderer.flipX = horizontal < 0;
            }
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }

    protected virtual void TryAttack()
    {
        if (currentAttackCooldown > 0) //���� ��Ÿ�� ���
        {
            currentAttackCooldown -= stateManager.attackSpeed * Time.deltaTime;
        }
        else
        {
            currentAttackCooldown = 0;
        }
        if (currentAttackCooldown == 0 && Input.GetButtonDown("Fire1"))
        {
            currentAttackCooldown = 1f;
            Attack();
            anim.SetTrigger("Attack");

        }
    }

    protected virtual void Attack()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 attackDir = (mouseWorldPos - transform.position).normalized;

        // ���콺 ��ġ�� ���� �ٶ󺸴� ���� ����
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = mouseWorldPos.x < transform.position.x;
        }

        // ���� ���� �ð�ȭ (��ä�� ���·� ���� Ray �׸���)
        int rayCount = 2; // ��ä���� ������ Ray ����
        float halfAngle = stateManager.attackAngle * 0.5f;
        for (int i = 0; i <= rayCount; i++)
        {
            float angle = -halfAngle + (stateManager.attackAngle * i / rayCount);
            float rad = angle * Mathf.Deg2Rad;
            Vector2 dir = Quaternion.Euler(0, 0, angle) * attackDir;
            Debug.DrawRay(transform.position, dir * stateManager.attackRange, Color.yellow, 0.5f);
        }

        // �߾� ���� Ray (������)
        Debug.DrawRay(transform.position, attackDir * stateManager. attackRange, Color.red, 0.5f);

        // ���� ���� ���� ��� �� Ž��
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, stateManager.attackRange, enemyLayerMask);
        bool hitAny = false;
        foreach (var col in hits)
        {
            Vector2 toEnemy = (col.transform.position - transform.position).normalized;
            float angle = Vector2.Angle(attackDir, toEnemy);
            if (angle <= halfAngle)
            {
                EnemyAI enemy = col.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    enemy.TakeDamage(stateManager.attackDamage);
                    Debug.Log($"��({col.name})�� �����߽��ϴ�! (����: {angle:F1}��)");
                    hitAny = true;
                }
            }
        }
        if (!hitAny)
        {
            Debug.Log("���� ���� ���� ���� �����ϴ�.");
        }
    }

    protected virtual void TrySkill1()
    {
        if (currentSkill1Cooldown > 0) // ��ų 1 ��Ÿ�� ���
        {
            currentSkill1Cooldown -= Time.deltaTime;
        }
        else
        {
            currentSkill1Cooldown = 0;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if ((currentSkill1Cooldown == 0))
            {
                anim.SetTrigger("Skill1");
                Skill1();
                currentSkill1Cooldown = stateManager.skill.cooldown; // ��ų ��Ÿ�� �ʱ�ȭ
            }
            else
            {
                Debug.Log("��ų ��ٿ���");
            }
        }
    }

    protected virtual void Skill1()
    {
        Debug.Log("��ų ���!");
    }



    protected virtual IEnumerator KnockDownRoutine()
    {
        anim.SetTrigger("Knockdown");
        Debug.Log("�÷��̾ �˴ٿ� �����Դϴ�. ȸ�� ��...");
        yield return new WaitForSeconds(stateManager.recoverTime); // 3�� ���
        stateManager.Recover(); // �˴ٿ� ���¿��� ȸ�� �Լ� ȣ��
    }
    
}
