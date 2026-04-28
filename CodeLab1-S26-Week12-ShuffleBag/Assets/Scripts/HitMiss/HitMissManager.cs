using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Serialization;

public class HitMissManager : MonoBehaviour
{
    //enum for our different modes of randomness
    public enum HitMissMode
    {
        Random,
        ShuffleBag
    }
    
    public HitMissMode mode = HitMissMode.Random;
    HitMissMode previousMode = HitMissMode.Random;   
    
    public float hitProbability = 0.5f;

    int streak = 0;
    int totalAttacks = 0;
    
    string previousResult = "";
    
    [Range(2, 100)]
    public int shuffleBagSize;
    
    public TextMeshProUGUI resultText;
    [FormerlySerializedAs("probablityText")] public TextMeshProUGUI probabilityText;
    public TextMeshProUGUI streakText;

    public ShuffleBag<string> shuffleBag;

    string log;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reset();
    }

    //Resets you attacks and streak back to 0 for each
    public void Reset()
    {
        ModifyPercentage(0f);
        resultText.text = "";
        streakText.text = "Streak: 0";
        log = "\n\n";
        totalAttacks = 0;
        
        streakText.text = "Attacks: 0 Streak: 0";
    }

    // Update is called once per frame
    void Update()
    {
        CheckoutMode();
    }

    public void Attack()
    {
        totalAttacks++;
        
        string result = "";
        
        switch (mode)
        {
            case HitMissMode.Random:
                if (Random.value < hitProbability)
                {
                    result = "Hit!";
                }
                else
                {
                    result = "Miss!";
                }
                break;
            case HitMissMode.ShuffleBag:
                result = shuffleBag.Next();
                break;
        }
        
        log  += result + "\n";
        
        resultText.text = result;
        
        if(result.Equals(previousResult))
        {
            streak++;
        }
        else
        {
            streak = 1;
            previousResult = result;
        }
        
        streakText.text = "Attacks: " +  totalAttacks + 
                          " Streak: " + streak + log;
    }

    public void CheckoutMode()
    {
        if (mode != previousMode)
        {
            previousMode = mode;

            if (mode == HitMissMode.ShuffleBag)
            {
                RebuildBag();
            }
        }
    }

    public void ModifyPercentage(float percentage)
    {
        hitProbability += percentage;
        
        probabilityText.text = "Hit Probability: " + Mathf.RoundToInt(hitProbability * 100) + "%";

        RebuildBag();
    }
    
    public void RebuildBag(){
        
        shuffleBag = new ShuffleBag<string>();

        int hits = Mathf.RoundToInt(shuffleBagSize * hitProbability);

        Debug.Log(hits);
        
        for (int i = 0; i < shuffleBagSize; i++)
        {
            if (i < hits)
            {
                shuffleBag.Add("Hit");
            }
            else
            {
                shuffleBag.Add("Miss");
            }
        }
    }
}