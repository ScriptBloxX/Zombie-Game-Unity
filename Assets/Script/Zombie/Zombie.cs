using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public Transform target;
    public float speed = 4f, distance = 10f, min_distance,Health;
    public Animator animator;
    private NavMeshAgent agent = null;
    public bool Dead;
    void Start()
    {
        Health = 100;
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update() {
        if(Health <= 0 && Dead==false){
            Dead = true;
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            animator.SetBool("Dead",true);
            this.GetComponent<AudioSource>().Stop();
            this.GetComponent<CapsuleCollider>().isTrigger = true;
            target.GetComponent<player_manager>().ZombieKills += 1;
        }
    }
    void FixedUpdate(){
        if (Dead == false){
            float cal_distance = Vector3.Distance(transform.position, target.transform.position);

            if (cal_distance <= distance && cal_distance > min_distance){
                animator.SetBool("Run", true);
                animator.SetBool("Attack", false);
                agent.destination = target.position;
            }else if (cal_distance <= min_distance){
                transform.LookAt(target.transform.position, Vector3.up);
                animator.SetBool("Attack", true);
            }else{
                animator.SetBool("Run", false);
                animator.SetBool("Attack", false);
            }
        }
    }
    // Debug Zone
    void OnDrawGizmos()
    {
        float cal_distance = Vector3.Distance (transform.position, target.transform.position);
        if(cal_distance <= distance){
            Gizmos.color = Color.green;
        }else{
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(transform.position,target.transform.position);
    }
}
