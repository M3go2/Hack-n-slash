using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public CharacterMovement charMove;
    public void PlayerAttack()
    {
        Debug.Log("Player Attacked!");
        charMove.DoAttack();
    }
    public void PlayerDamage()
    {
        transform.GetComponentInParent<EnemyController>().DamagePlayer();
    }
}