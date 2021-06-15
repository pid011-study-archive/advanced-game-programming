using UnityEngine;

namespace BattleGame
{
    public class GameManager : MonoBehaviour
    {
        public Info player;
        public Info enemy;

        private void Update()
        {
            if (player.hp != 0 && enemy.hp != 0) return;

            StartCoroutine(player.GetComponent<StateMachine>().CurrentState.StopState());
            StartCoroutine(enemy.GetComponent<StateMachine>().CurrentState.StopState());
            Debug.Log(player.hp == 0 ? "enemy win!" : "player win!");
        }
    }
}