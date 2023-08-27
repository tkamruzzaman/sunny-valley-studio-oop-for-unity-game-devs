using UnityEngine;

namespace WeaponSystem
{
    public abstract class AttackPatternSO : ScriptableObject
    {
        [SerializeField] protected GameObject projectile;

        [SerializeField] protected float attackDelay = 0.2f;

        public float AttackDelay => attackDelay;

        [SerializeField] protected AudioClip weaponSFX;

        public AudioClip AudioSFX => weaponSFX;

        public abstract void PerformAttack(Transform shootingStartPoint);

    }
}