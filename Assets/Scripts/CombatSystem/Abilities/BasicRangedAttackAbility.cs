using System.Collections;
using Services;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Abilities
{
    [CreateAssetMenu(menuName="ScriptableObject/Abilities/BasicRangedAttackAbility")]
    public class BasicRangedAttackAbility : Ability
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileVelocity = 10f;

        public bool onCooldown = false;
        public override void Activate()
        {
            if(onCooldown) return;
            ServiceLocator.Instance.Get<MonoBehaviorService>().StartCoroutine(
                AttackCooldown(1/_attributes.attackSpeed.CurrentValue));
            GameObject projectile = Object.Instantiate(projectilePrefab,_owner.transform.position,_owner.transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = _owner.transform.up * projectileVelocity;
        }

        private IEnumerator AttackCooldown(float cooldownLength)
        {
            onCooldown = true;
            yield return new WaitForSeconds(cooldownLength);
            onCooldown = false;
        }
    }
}