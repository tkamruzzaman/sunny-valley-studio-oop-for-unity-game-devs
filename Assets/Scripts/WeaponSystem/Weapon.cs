using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        //public float shootingDelay = 0.2f;
        public bool shootingDelayed;

        [SerializeField] private AttackPatternSO weapon;
        [SerializeField] Transform shootingStartPoint;

        public GameObject projectile;

        public AudioSource gunAudio;

        [SerializeField] private List<AttackPatternSO> weapons;
        private int index = 0;
        [SerializeField] private AudioClip weaponSwapClip;

        public void PerformAttack()
        {
            if (shootingDelayed == false)
            {
                shootingDelayed = true;
                gunAudio.PlayOneShot(weapon.AudioSFX);
                //GameObject p = Instantiate(projectile, transform.position, Quaternion.identity);

                weapon.PerformAttack(shootingStartPoint);
                
                StartCoroutine(DelayShooting());
            }
        }

        private IEnumerator DelayShooting()
        {
            yield return new WaitForSeconds(weapon.AttackDelay);
            shootingDelayed = false;
        }

        public void SwapWeapon()
        {
            index++;
            index = index >= weapons.Count ? 0 : index;
            weapon = weapons[index];
            gunAudio.PlayOneShot(weaponSwapClip);
        }
    }
}