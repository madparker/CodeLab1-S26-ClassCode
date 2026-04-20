using UnityEngine;

public class NYUGradStudent : NYUStudent
{
    public string underGradAffiliation;

    public enum BachelorType
    {
        BA, BS, BFA, BAS, Other
    }
    
    public BachelorType bachelorType;

    public bool hasGRE = false;

    // public string concentration;

    //Default construct
    public NYUGradStudent() : base()
    {
        bachelorType = BachelorType.Other;
        hasGRE = false;
        underGradAffiliation = "Unknown";
        name = "Unknown";
        type = "NYU Grad Student";
    }

    public NYUGradStudent(
        string name, string netId, 
        float financialAid, float gpa, 
        string underGradAffiliation, BachelorType bachelorType, bool hasGre) : 
        base(name, netId, financialAid, gpa)
    {
        this.underGradAffiliation = underGradAffiliation;
        this.bachelorType = bachelorType;
        hasGRE = hasGre;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + "Bachelor Type: " + bachelorType + "\n";
    }
    
}
