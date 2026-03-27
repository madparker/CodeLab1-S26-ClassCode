using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Scriptable Objects/Location")]
public class Location : ScriptableObject
{
    
    public string name;
    public string description;

    public Location northLocation;
    public Location southLocation;
    public Location eastLocation;
    public Location westLocation;

    private void OnValidate()
    {
        // Called in the editor whenever this asset is changed/reloaded.
        if (westLocation != null && westLocation.eastLocation != this)
        {
            westLocation.eastLocation = this;
        }

        if (GameManager.instance != null)
        {
            UpdateLocationDisplay(GameManager.instance);
        }
    }

    public void UpdateLocationDisplay(GameManager gm)
    {
        gm.locationNameDisplay.text = name;
        gm.locationDescriptionDisplay.text = description;

        if (northLocation == null)
        {
            gm.NorthButton.SetActive(false);
        }
        else
        {
            gm.NorthButton.SetActive(true);
        }

        if (southLocation == null)
        {
            gm.SouthButton.SetActive(false);
        }
        else
        {
            gm.SouthButton.SetActive(true);
        }

        if (eastLocation == null)
        {
            gm.EastButton.SetActive(false);
        }
        else
        {
            gm.EastButton.SetActive(true);
        }
        
        //if westLocation is null, then false, turn button off
        //if westLocation is not null, then true, turn the button on
        gm.WestButton.SetActive(westLocation != null);
    }

}
