using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class StateMachine : MonoBehaviour
    {
        [SerializeField] private StateBehaviour[] states;
        public StateBehaviour CurrentState { get; private set; }

        public void Start()
        {
            StartCoroutine(RunStates());
        }

        private IEnumerator RunStates()
        {
            CurrentState = states[0];

            yield return StartCoroutine(CurrentState.Execute());

            while (true)
            {
                var nextState = CurrentState.NextState ?? states[0].GetType();

                foreach (var state in states)
                {
                    if (state.GetType() != nextState) continue;

                    CurrentState = state;
                    break;
                }

                yield return StartCoroutine(CurrentState.Execute());
            }
        }
    }
}
