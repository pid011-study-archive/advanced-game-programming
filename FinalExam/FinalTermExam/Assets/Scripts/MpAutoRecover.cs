using System.Collections;

using UnityEngine;

namespace BattleGame
{
    public class MpAutoRecover : MonoBehaviour
    {
        private Info _info;

        private void Awake()
        {
            _info = GetComponent<Info>();
        }

        private IEnumerator AutoRecover()
        {
            while (true)
            {
                _info.mp += 1;
                yield return new WaitForSeconds(_info.mpRechargeSpeed);
            }
        }
    }
}