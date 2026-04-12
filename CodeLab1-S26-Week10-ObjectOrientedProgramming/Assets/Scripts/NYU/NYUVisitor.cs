using UnityEngine;

public class NYUVisitor: NYUPerson
{
    public string affiliation;
    public enum VisitorType
    {
        academic, 
        industry,
        creative
    }
    
    public VisitorType visitorType;
    
    public NYUVisitor()
    {
    }

    public NYUVisitor(string name, string netid, string affiliation, VisitorType visitorType) :
        base(name, netid)
    {
        this.affiliation = affiliation;
        this.visitorType = visitorType;
    }

    public override string ShowRecord()
    {
        return base.ShowRecord() + 
               "Affiliation: " + affiliation + "\n" +
               "VisitorType: " + visitorType + "\n";
            
    }

}
