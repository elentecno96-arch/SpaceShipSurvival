using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SpaceShips.Strategy.Attack
{
    public abstract class Attackstrategy : MonoBehaviour
    {
        protected SpaceShip owner;
        public virtual void Initialize(SpaceShip owner)
        {
            this.owner = owner;
        }
        public abstract void AttackUpdate();
        public abstract void PerformAttack();
    }
}
