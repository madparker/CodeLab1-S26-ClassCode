using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Scriptable Objects/Location")]
// ScriptableObject data container for one node in the location graph.
public class Location : ScriptableObject
{
    // Name shown in the location title UI.
    public string name;
    // Description shown in the location body UI.
    public string description;

    // Neighbor references used for directional movement.
    public Location northLocation;
    public Location southLocation;
    public Location eastLocation;
    public Location westLocation;

    private void OnValidate()
    {
        // Called in the editor whenever this asset is changed/reloaded.
        // Keep west/east links symmetric when possible.
        if (westLocation != null && westLocation.eastLocation != this)
        {
            westLocation.eastLocation = this;
        }

        // If the game is running and a manager exists, refresh UI immediately.
        if (GameManager.instance != null)
        {
            UpdateLocationDisplay(GameManager.instance);
        }
    }

    // Writes this location's content into the UI and toggles valid direction buttons.
    public void UpdateLocationDisplay(GameManager gm)
    {
        // Update the text content.
        gm.locationNameDisplay.text = name;
        gm.locationDescriptionDisplay.text = description;

        // Hide North button if this location has no north exit.
        if (northLocation == null)
        {
            gm.NorthButton.SetActive(false);
        }
        else
        {
            gm.NorthButton.SetActive(true);
        }

        // Hide South button if this location has no south exit.
        if (southLocation == null)
        {
            gm.SouthButton.SetActive(false);
        }
        else
        {
            gm.SouthButton.SetActive(true);
        }

        // Hide East button if this location has no east exit.
        if (eastLocation == null)
        {
            gm.EastButton.SetActive(false);
        }
        else
        {
            gm.EastButton.SetActive(true);
        }
        
        // West uses the compact equivalent of the if/else patterns above.
        gm.WestButton.SetActive(westLocation != null);
    }

}
