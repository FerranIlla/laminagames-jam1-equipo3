using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    private float currentCooldown;
    enum State { Ready, Recharging}
    State state = State.Ready;
    Text cooldownDisplay;
    Button button;
    [SerializeField] private EnemyType targetEnemyType;
    [SerializeField] private EnemiesManager enemiesManager;

    // Start is called before the first frame update
    void Start()
    {
        cooldownDisplay = transform.GetChild(0).GetComponent<Text>();
        cooldownDisplay.gameObject.SetActive(false); //hide number
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(state == State.Recharging)
        {
            Recharge();
            DisplayCooldown();
        }
    }

    void Recharge()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f)
        {
            state = State.Ready;
            //hide number
            cooldownDisplay.gameObject.SetActive(false);
            //set button active
            button.interactable = true;
        }
    }

    void DisplayCooldown()
    {
        cooldownDisplay.text = (((int)currentCooldown)+1).ToString();
    }

    public void ActivateAbility()
    {
        if(targetEnemyType == EnemyType.None)
        {
            Debug.LogWarning("Not a known enemy type.");
            return;
        }
        enemiesManager.HitAllEnemiesOfType(targetEnemyType);
        state = State.Recharging;
        currentCooldown = 9.99f;
        cooldownDisplay.gameObject.SetActive(true);
        button.interactable = false;

        AudioManager.instance.PlaySoundAdditive("UseAbility");
    }
}
