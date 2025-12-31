using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interface
{
    public interface IHittable
    {
        void TakeHit(float damage);
        float CurrentHP { get; }
    }
}
