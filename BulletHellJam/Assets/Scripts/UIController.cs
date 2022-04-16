using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance = null;

    [Header("Base")]
    [SerializeField] private TextMeshProUGUI baseHP;

    [Header("Tint")]
    [SerializeField] private TextMeshProUGUI projectileTint;
    [SerializeField] private TextMeshProUGUI shieldTint;

    [Header("Time")]
    [SerializeField] private TextMeshProUGUI gameTime;
    
    [Header("Enemies")]
    [SerializeField] private TextMeshProUGUI enemiesDestroyed;

    private void Awake() 
    {
        if(instance==null)
            instance=this;
        else
            Destroy(this);
    }


    public void UpdateBaseHP(int currentHP, int maxHP)
    {
        baseHP.SetText("HP: " + currentHP + "/" + maxHP);
    }

    public void UpdateProjectileTint(float currentTint, float maxTint)
    {
        projectileTint.SetText("P: " + (int)currentTint + "/" + maxTint);
    }

    public void UpdateShieldTint(float currentTint, float maxTint)
    {
        shieldTint.SetText("S: " + (int)currentTint + "/" + maxTint);
    }

    public void UpdateGameTime(float currentGameTime)
    {
        gameTime.SetText(TextController.FormatTimeToText(currentGameTime));
    }

    public void UpdateEnemiesDestroyed(int amount)
    {
        enemiesDestroyed.SetText("ENEMIES: " + amount);
    }

}
