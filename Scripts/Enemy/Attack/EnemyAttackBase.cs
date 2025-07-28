using System.Collections;
using UnityEngine;

public abstract class EnemyAttackBase : MonoBehaviour
{
    protected Enemy enemy;
    protected bool canAttack = false;

    protected GameObject player;
    protected StateManager stateManager;

    public virtual void Initialize(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void EnableAttack()
    {
        canAttack = true;
    }
    public void DisableAttack()
    {
        canAttack = false;
    }

    public void TryAttackPlayer(Vector2 direct, GameObject projectile, int damage)
    {
            AttackPlayer(direct, projectile, damage);
    }
    public void TryAttackProtectedTarget(Vector2 direct, GameObject projectile, int damage)
    {
            AttackProtectedTarget(direct, projectile, damage);
    }

    public abstract void AttackPlayer(Vector2 direction, GameObject projectile, int damage);
    public abstract void AttackProtectedTarget(Vector2 direction, GameObject projectile, int damage);
}
