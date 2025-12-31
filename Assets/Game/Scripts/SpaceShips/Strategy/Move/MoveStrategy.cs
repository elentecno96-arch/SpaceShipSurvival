using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.SpaceShips.Strategy.Move
{
    public abstract class MoveStrategy : MonoBehaviour
    {
        protected SpaceShip owner;
        public virtual void Initialize(SpaceShip owner)
        {
            this.owner = owner;
        }
        public abstract void MoveUpdate();
        public abstract void PerformMove();
    }
}
