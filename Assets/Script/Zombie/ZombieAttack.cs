using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public float damageTime = .4f,currentDamageTime,damage;
    
    private void Update() {
        if(this.GetComponentInParent<Zombie>().Dead==false){
            Collider[] hitColliders = Physics.OverlapSphere(transform.position,1f);
            foreach(Collider hitCollider in hitColliders){
                if (hitCollider.gameObject.tag.Equals("Player")){
                    currentDamageTime += Time.deltaTime;
                    if (currentDamageTime > damageTime && hitCollider.gameObject.GetComponent<player_manager>().Health >= damage ){
                        hitCollider.gameObject.GetComponent<player_manager>().Health -= damage;
                        currentDamageTime = 0.0f;
                        Debug.Log("Hit Player!");
                    }
                }
            }
        }
    }

    // Debug Zone 
    /*
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position,1f);
    }*/
}
