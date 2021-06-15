using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class SpecialAttackState : StateBehaviour
    {
        protected override IEnumerator OnEnter()
        {
            Debug.Log($"{CallerName}: SpecialAttack State");
            yield break;
        }

        protected override IEnumerator OnExecute()
        {
            if (Info.hp == 0)
            {
                NextState = typeof(DeadState);
                yield break;
            }

            var attackPower = Info.specialAttackPower;
            Info.targetInfo.hp -= Mathf.Max(Info.targetInfo.hp - attackPower, 0);
            Debug.Log($"{CallerName} -> {Info.targetInfo.gameObject.name} : damaged {attackPower} by special attack");

            if (Info.hp <= Info.hp * 0.2f)
            {
                NextState = typeof(RunawayState);
                yield break;
            }

            yield return new WaitForSeconds(Info.attackSpeed);
            NextState = typeof(AttackState);
        }

        protected override IEnumerator OnExit()
        {
            yield break;
        }
    }
}