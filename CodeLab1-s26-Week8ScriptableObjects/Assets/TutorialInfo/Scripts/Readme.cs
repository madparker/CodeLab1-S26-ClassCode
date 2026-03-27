using System;
using UnityEngine;

// ScriptableObject that stores tutorial/readme content shown in the Inspector.
public class Readme : ScriptableObject
{
    // Optional icon displayed in the custom readme header.
    public Texture2D icon;
    // Main title displayed at the top of the readme.
    public string title;
    // Ordered sections rendered by the custom editor.
    public Section[] sections;
    // Tracks whether the starter editor layout has already been loaded once.
    public bool loadedLayout;

    [Serializable]
    // One block of readme content.
    public class Section
    {
        // Heading text, body text, link label, and URL for this section.
        public string heading, text, linkText, url;
    }
}
