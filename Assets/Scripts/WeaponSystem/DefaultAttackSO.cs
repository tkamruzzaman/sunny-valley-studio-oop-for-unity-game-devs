using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Attack/DefaultAttack")]
    public class DefaultAttackSO: AttackPatternSO
    {
        public override void PerformAttack(Transform shootingStartPoint)
        {
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation);
        }
    }
}