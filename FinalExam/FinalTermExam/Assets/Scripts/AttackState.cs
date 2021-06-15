using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class AttackState : StateBehaviour
    {
        protected override IEnumerator OnEnter()
        {
            Debug.Log($"{CallerName}: Attack State");
            yield break;
        }

        protected override IEnumerator OnExecute()
        {
            while (true)
            {
                if (Info.hp == 0)
                {
                    NextState = typeof(DeadState);
                    yield break;
                }

                var attackPower = Random.Range(Info.minAttackPower, Info.maxAttackPower + 1);
                Info.targetInfo.hp -= Mathf.Max(Info.targetInfo.hp - attackPower, 0);
                Debug.Log($"{CallerName} -> {Info.targetInfo.gameObject.name} : damaged {attackPower}");

                if (Info.hp <= Info.hp * 0.3f)
                {
                    NextState = typeof(RunawayState);
                    yield break;
                }

                yield return new WaitForSeconds(Info.attackSpeed);
                if (Info.mp >= 100)
                {
                    NextState = typeof(SpecialAttackState);
                    yield break;
                }
            }
        }

        protected override IEnumerator OnExit()
        {
            yield break;
        }
    }
}