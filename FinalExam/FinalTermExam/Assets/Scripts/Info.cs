using UnityEngine;

namespace BattleGame
{
    public class Info : MonoBehaviour
    {
        public int maxHp;
        public int minAttackPower;
        public int maxAttackPower;
        public int specialAttackPower;
        public float attackSpeed;
        public float mpRechargeSpeed;
        public Info targetInfo;

        [HideInInspector] public int hp;
        [HideInInspector] public int mp;

        private void Awake()
        {
            hp = maxHp;
        }
    }
}
