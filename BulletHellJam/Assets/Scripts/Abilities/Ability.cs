using UnityEngine;

abstract public class Ability : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected bool isOnCooldown;
    protected bool isUsing;
    private float currentTime;

    [SerializeField] private KeyCode abilityKey;

    [Header("UI")]
    [SerializeField] private AbilityUI abilityUI;

    private void Start() 
    {
        currentTime = 0f;
        isOnCooldown = false;
        isUsing = false;
        abilityUI.UpdateUI(currentTime, cooldown, isOnCooldown);
    }

    virtual public void Update() 
    {
        if(isOnCooldown)
        {
            currentTime += Time.deltaTime;
            if(currentTime>=cooldown)
            {
                isOnCooldown = false;
                currentTime = 0f;
            }
        }
        else
        {
            if(!isUsing && Input.GetKeyDown(abilityKey))
            {
                UseAbility();
            }
        }

        abilityUI.UpdateUI(currentTime, cooldown, isOnCooldown);
    }

    virtual public void UseAbility()
    {
        isOnCooldown = true;
    }
    
}
