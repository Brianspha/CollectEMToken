using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class TokenIDGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    private int id;

    private void Start()
    {
        GetFileID();
    }

    private void GetFileID()
    {
        PropertyInfo inspectorModeInfo = typeof(SerializedObject).GetProperty("inspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
        SerializedObject serializedObject = new SerializedObject(gameObject);
        inspectorModeInfo.SetValue(serializedObject, InspectorMode.Debug, null);
        SerializedProperty localIdProp = serializedObject.FindProperty("m_LocalIdentfierInFile");   //note the misspelling!
        id = (int)(localIdProp.intValue + new DateTime().TimeOfDay.TotalMilliseconds + Random.Range(int.MinValue, int.MaxValue));
        Debug.LogWarning("Token ID: " + id);
    }

    public int GetTokenID()
    {
        return id;
    }

}
