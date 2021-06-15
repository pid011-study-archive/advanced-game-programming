using System;
using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public abstract class StateBehaviour : MonoBehaviour
    {
        private enum State
        {
            Enter, Execute, Exit
        }

        public string CallerName => gameObject.name;
        public bool Done { get; private set; }
        public Type NextState { get; protected set; }

        private State _currentState;
        protected Info Info;

        protected abstract IEnumerator OnEnter();
        protected abstract IEnumerator OnExecute();
        protected abstract IEnumerator OnExit();


        private void Awake()
        {
            Info = GetComponent<Info>();
        }

        public IEnumerator Execute()
        {
            Done = false;
            Coroutine current;

            _currentState = State.Enter;
            current = StartCoroutine(OnEnter());
            yield return current;

            _currentState = State.Execute;
            current = StartCoroutine(OnExecute());
            yield return current;

            _currentState = State.Exit;
            current = StartCoroutine(OnExit());
            yield return current;

            Done = true;
        }

        public IEnumerator StopState()
        {
            switch (_currentState)
            {
                // Enter나 Execute가 실행중일 경우
                case State.Enter:
                case State.Execute:
                    // 해당 코루틴과 Execute 모두 중지 후 OnExit 직접 실행
                    // Done 값을 직접 true로 변경
                    StopAllCoroutines();
                    yield return StartCoroutine(OnExit());
                    Done = true;
                    break;

                // Exit일 경우
                case State.Exit:
                    // 그대로 Done이 true로 변경 될 때까지 기다림
                    yield return new WaitUntil(() => Done);
                    break;
            }

            Debug.Log($"{GetType()}: Stopped");
        }
    }
}
