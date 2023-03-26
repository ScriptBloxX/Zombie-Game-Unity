using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_manager : MonoBehaviour
{
    public float Health,Stamina,Hungry,Water;
    public Slider HealthBar,StaminaBar;
    public Image HungryBar,WaterBar;
    //private bool delay,healDelay;
    public bool ignoreRegen;
    public string Equipment;
    public Animator PlayerAnimation;
    public GameObject GameOver;
    public int ZombieKills;
    // stats variables
    public float staminaDelay,current_StaminaTime,HealthDelay,current_HealthTime;
    void Start()
    {
        Equipment = "pen";
        HealthBar.value = Health; 
        StaminaBar.value = Stamina;
        HungryBar.fillAmount = Hungry/100f;
        WaterBar.fillAmount = Water/100f;

        staminaDelay = .3f;
        HealthDelay = .5f;
    }
    void Update(){
        if(Health > 0){
        HealthBar.value = Health;
        StaminaBar.value = Stamina;
        HungryBar.fillAmount = Hungry/100f;
        WaterBar.fillAmount = Water/100f;

            if(Stamina < 100 && Hungry>=.1f && Water>=.2f && ignoreRegen == false){
                current_StaminaTime += Time.deltaTime;
                if(current_StaminaTime>=staminaDelay){
                    Stamina += 1;
                    Hungry -= .1f;
                    Water -= .2f;

                    current_StaminaTime = .0f;
                }
            }
            if(Health < 100  && Hungry>=.2f && Water>=.3f){
                current_HealthTime += Time.deltaTime;
                if(current_HealthTime>=HealthDelay){
                    Health += 1;
                    Hungry -= .2f;
                    Water -= .3f;

                    current_HealthTime = .0f;
                }
            }
            // dead end
        }
        if(Health <= 0 && PlayerAnimation.GetBool("Dead")==false){
            PlayerAnimation.SetBool("Dead",true);
            StartCoroutine(PlayerDieAnimation(4.533f));
        }
    }
    public void IncreaseHealth(int value){
        if(Health>0){
            Health += value;
            if(Health>100){
                Health=100;
            }
        }
    }
    public void IncreaseWater(int value){
        if(Health>0){
            Water += value;
            if(Water>100){
                Water=100;
            }
        }
    }
    public void IncreaseFood(int value){
        if(Health>0){
            Hungry += value;
            if(Hungry>100){
                Hungry=100;
            }
        }
    }
    public void IncreaseStamina(int value){
        if(Health>0){
            Stamina += value;
            if(Stamina>100){
                Stamina=100;
            }
        }
    }
    public void IncreaseFullFood(int value){
        if(Health>0){
            Hungry += value;
            Water += value;
            if(Hungry>100){
                Hungry=100;
            }
            if(Water>100){
                Water=100;
            }
        }
    }

    IEnumerator PlayerDieAnimation(float sec){
        yield return new WaitForSeconds(sec);
        GameOver.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        this.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = false;
        this.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = false;
    }
}
