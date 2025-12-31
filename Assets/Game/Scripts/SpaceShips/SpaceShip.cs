using Game.Interface;
using Game.SpaceShips.BaseStat;
using Game.SpaceShips.Strategy.Attack;
using Game.SpaceShips.Strategy.Move;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.SpaceShips
{
    public abstract class SpaceShip : MonoBehaviour, IHittable
    {
        protected MoveStrategy moveStrategy;
        protected Attackstrategy attackStrategy;

        [SerializeField]
        protected SpaceShipStat baseStat;
        protected float currentHP;
        protected float currentShield;
        protected bool isDead;
        protected float shieldRegenTimer;

        public float CurrentHP => currentHP;
        public float CurrentShield => currentShield;
        public bool IsDead => isDead;

        protected virtual void Awake()
        {
            Init();
            InitializeStrategies();
        }
        protected virtual void Update()
        {
            if (isDead) return;

            moveStrategy?.MoveUpdate();
            attackStrategy?.AttackUpdate();

            ShieldRegenUpdate();
        }
        protected virtual void Init()
        {
            currentHP = baseStat.maxHp;
            currentShield = baseStat.maxShield;
            shieldRegenTimer = 0;
            isDead = false;
        }
        protected abstract void InitializeStrategies();
        public virtual void TakeHit(float damage)
        {
            if (isDead) return;

            float remainingDamage = damage;

            if (currentShield > 0)
            {
                float shieldDamage = Mathf.Min(currentShield, remainingDamage);
                currentShield -= shieldDamage;
                remainingDamage -= shieldDamage;

                ResetShieldRegenDelay();
            }
            if (remainingDamage > 0)
            {
                currentHP -= remainingDamage;
            }
            if (currentHP <= 0)
            {
                Die();
            }

        }
        protected void ResetShieldRegenDelay()
        {
            shieldRegenTimer = baseStat.shieldRegenDelay;
        }
        protected void ShieldRegenUpdate()
        {
            if (currentShield >= baseStat.maxShield) return;

            shieldRegenTimer -= Time.deltaTime;
            if (shieldRegenTimer > 0) return;

            currentShield = Mathf.Min(
                currentShield + baseStat.shieldRegenRate * Time.deltaTime,
                baseStat.maxShield
            );
        }
        protected virtual void Die()
        {
            isDead = true;
            OnDead();
        }
        protected abstract void OnDead();

        public MoveStrategy GetMoveStrategy() => moveStrategy;
        public Attackstrategy GetAttackStrategy() => attackStrategy;

        public void SetMoveStrategy(MoveStrategy strategy) => moveStrategy = strategy;
        public void SetAttackStrategy(Attackstrategy strategy) => attackStrategy = strategy;
    }
}
