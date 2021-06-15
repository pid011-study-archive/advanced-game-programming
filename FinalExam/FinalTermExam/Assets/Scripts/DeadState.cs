using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class DeadState : StateBehaviour
    {
        protected override IEnumerator OnEnter()
        {
            Debug.Log($"{CallerName}: Dead State");
            yield break;
        }

        protected override IEnumerator OnExecute()
        {
            throw new System.NotImplementedException();
        }

        protected override IEnumerator OnExit()
        {
            throw new System.NotImplementedException();
        }
    }
}