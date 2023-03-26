using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour{
    // Aattack animation
    public Animator player;
    public AnimationClip attackClip_1,attackClip_2;
    private bool Delay,Hit;
    public GameObject Hand;
    public AudioSource source;
    public AudioClip clip;
    void Update()
    {
        if(player.GetBool("Dead")==false){    
            var WeaponStats = Hand.transform.Find(this.GetComponent<player_manager>().Equipment).gameObject.GetComponent<weapon_stats>();
            if(Input.GetKeyDown(KeyCode.Mouse0) && Delay==false && this.GetComponent<player_manager>().Stamina > WeaponStats.Stamina){
                Delay = true;
                player.SetTrigger("Attack");
                this.GetComponent<player_manager>().Stamina -= WeaponStats.Stamina;
                StartCoroutine(FinishAnimation(attackClip_1.length));
                //StartCoroutine(FinishAnimation(player.GetCurrentAnimatorStateInfo(0).length));
            }
            if(Input.GetKeyDown(KeyCode.Mouse1) && Delay==false && this.GetComponent<player_manager>().Stamina > WeaponStats.Stamina){
                Delay = true;
                player.SetTrigger("Attack2");
                this.GetComponent<player_manager>().Stamina -= WeaponStats.Stamina;
                StartCoroutine(FinishAnimation(attackClip_2.length));
                //StartCoroutine(FinishAnimation(player.GetCurrentAnimatorStateInfo(0).length));
            }
        }
    }

    IEnumerator FinishAnimation(float stateInfo){
        yield return new WaitForSeconds(stateInfo);
        Delay = false;
        Hit = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Zombie") && Delay==true && Hit==false && other.GetComponent<Zombie>().Dead==false){
            Hit = true;
            var WeaponStats = Hand.transform.Find(this.GetComponent<player_manager>().Equipment).gameObject.GetComponent<weapon_stats>();
            other.GetComponent<Zombie>().Health -= WeaponStats.Damage;
            source.PlayOneShot(clip);
            Debug.Log("Hit Zombie! -> "+other.GetComponent<Zombie>().Health);
        }
    }
}
