using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class NewGame : MonoBehaviour
{
    public Button respawn;
    public TextMeshProUGUI ZombieKills;
    public GameObject Player;
    private bool textUpdate;
    void Start(){
        Button btn = respawn.GetComponent<Button>();
        btn.onClick.AddListener(_Task);
    }
    void Update(){
        if(this.isActiveAndEnabled && textUpdate== false){
            textUpdate = true;
            ZombieKills.text = "Zombie Kills : "+Player.GetComponent<player_manager>().ZombieKills.ToString();
        }
    }
    void _Task(){
        SceneManager.LoadScene("twbt001");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorLocked = true;
        Player.GetComponent<StarterAssets.StarterAssetsInputs>().cursorInputForLook = true;
    }
}
