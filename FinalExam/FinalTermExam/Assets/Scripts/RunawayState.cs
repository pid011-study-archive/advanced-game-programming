using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class RunawayState : StateBehaviour
    {
        private int _count;

        protected override IEnumerator OnEnter()
        {
            Debug.Log($"{CallerName}: Runaway State");
            yield break;
        }

        protected override IEnumerator OnExecute()
        {
            while (Info.hp < Info.hp * 0.7f)
            {
                if (Info.hp == 0)
                {
                    NextState = typeof(DeadState);
                    yield break;
                }

                Info.hp = Mathf.Min(Info.hp + 5, Info.maxHp);
                yield return new WaitForSeconds(1f);
            }

            if (_count == 0)
            {
                NextState = typeof(IdleState);
                ++_count;
            }
            else
            {
                while (true)
                {
                    yield return new WaitForSeconds(1f);
                }
            }
        }

        protected override IEnumerator OnExit()
        {
            yield break;
        }
    }
}