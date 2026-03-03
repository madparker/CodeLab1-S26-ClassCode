using System;
using System.IO;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    Vector3 currentMousePosition;

    string filePath = "/Resources/DraggableObject/";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filePath = Application.dataPath + filePath;
        
        string fileContents = File.ReadAllText(filePath + name + ".json");
        
        Debug.Log(fileContents);
        
        Vector3 savePosition = JsonUtility.FromJson<Vector3>(fileContents);
        
        transform.position = savePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePosition();
    }

    Vector3 GetMousePosition()
    {
        currentMousePosition = Input.mousePosition;
        
        currentMousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        
        currentMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        
        return currentMousePosition;
    }

    void OnApplicationQuit()
    {
        string jsonPosition = JsonUtility.ToJson(transform.position, true);
        
        Debug.Log(jsonPosition);
        
        File.WriteAllText(filePath + name + ".json", jsonPosition);
        
    }
}
