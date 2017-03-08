using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIcontrol : MonoBehaviour {

    private ItsHighNoon player;
    private GM gameManger;
    public Image Energy1;
    public Image Energy2;
    public Image Energy3;
    public Image HP;
    public Text EnergyText;
    public Text gunSumText;
    public Text HPText;
    public GameObject starUI;
    public GameObject menuUI;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<ItsHighNoon>();
	}
	
	// Update is called once per frame
	void Update () {
        Energy1.fillAmount = (float)player.Energy/100;
        HP.fillAmount = (float)player.Hp / 200f;
        EnergyText.text = Mathf.CeilToInt(player.Energy).ToString() + "%";
        gunSumText.text = player.bsum.ToString() + "/" + player.bulletSum.ToString();
        HPText.text = player.Hp.ToString() + "/200";
        if (player.Energy > 100)
        {
            Energy1.gameObject.active = false;
            Energy2.gameObject.active = false;
            EnergyText.gameObject.active = false;
            Energy3.gameObject.active = true;
        }


    }

    public void restar()
    {
        Energy1.gameObject.active = true;
        Energy2.gameObject.active = true;
        EnergyText.gameObject.active = true;
        Energy3.gameObject.active = false;
    }

    public void start()
    {
        starUI.active = false;
        Time.timeScale = 1;
    }

    public void quit()
    {
        Application.Quit();
    }

    public void stop()
    {
        Time.timeScale = 0;
    }

    public void continuegame()
    {
        Time.timeScale = 1;
    }
}
