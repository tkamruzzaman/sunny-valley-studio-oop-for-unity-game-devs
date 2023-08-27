using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Attack/SpreadAttack")]
    public class SpreadAttackSO : AttackPatternSO
    {
        [SerializeField] float angleDegrees = 5;

        public override void PerformAttack(Transform shootingStartPoint)
        {
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation);
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation * Quaternion .Euler(Vector3.forward * angleDegrees));
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation * Quaternion.Euler(Vector3.forward * -angleDegrees));
        }

    }
}