using UnityEngine;

namespace WeaponSystem
{
    [CreateAssetMenu(menuName = "Attack/DoubleBarrelAttack")]
    public class DoubleBarrelAttackSO : AttackPatternSO
    {
        [SerializeField] private float offsetFromShootingPoint = 0.3f;

        public override void PerformAttack(Transform shootingStartPoint)
        {
            //rotate offset vector to fit the player ship rotation
            Vector3 offsetVector = shootingStartPoint.rotation * new Vector3(offsetFromShootingPoint, 0, 0);

            //calculate new barrel positions
            Vector3 point1 = shootingStartPoint.position + offsetVector;
            Vector3 point2 = shootingStartPoint.position - offsetVector;

            Instantiate(projectile, point1, shootingStartPoint.rotation);
            Instantiate(projectile, point2, shootingStartPoint.rotation);

        }
    }
}