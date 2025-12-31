using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SpaceShips.BaseStat
{
    [System.Serializable]
    public struct SpaceShipStat
    {
        public int maxHp;
        public float moveSpeed;
        public float Damage;
        public float projectileSpeed; 
        public float criticalRate;
        public float criticalDamage;
        public float maxShield;
        public float shieldRegenRate;
        public float shieldRegenDelay;
    }
}
