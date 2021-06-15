using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class IdleState : StateBehaviour
    {
        protected override IEnumerator OnEnter()
        {
            Debug.Log($"{CallerName}: IdleState");
            yield break;
        }

        protected override IEnumerator OnExecute()
        {
            yield return new WaitForSeconds(5f);
            NextState = typeof(AttackState);
        }

        protected override IEnumerator OnExit()
        {
            yield break;
        }
    }
}