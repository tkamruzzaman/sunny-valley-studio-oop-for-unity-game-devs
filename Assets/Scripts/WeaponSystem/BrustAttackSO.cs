using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Attack/BrustAttack")]
    public class BrustAttackSO : AttackPatternSO
    {
        [SerializeField] private float bulletVerticalOffset = 1;

        public override void PerformAttack(Transform shootingStartPoint)
        {
            Instantiate(projectile, shootingStartPoint.position, shootingStartPoint.rotation);
            Instantiate(projectile, new Vector3(shootingStartPoint.position.x, shootingStartPoint.position.y + bulletVerticalOffset, shootingStartPoint.position.z), shootingStartPoint.rotation);
            Instantiate(projectile, new Vector3(shootingStartPoint.position.x, shootingStartPoint.position.y - bulletVerticalOffset, shootingStartPoint.position.z), shootingStartPoint.rotation);
        }
    }
}