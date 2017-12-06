using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UAV))]
[ExecuteInEditMode]
public class UAVEditor : Editor {
    UAV uav;

    SerializedProperty setHeight;

	void OnEnable()
	{
        uav = target as UAV;
        setHeight = serializedObject.FindProperty("HeightSet");
        heightSet = uav.HeightPreSet;
	}

    float heightSet = 0;
    bool PIDParamShow = true;
   
    [ExecuteInEditMode]
    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        EditorGUILayout.LabelField("Acceleration: " + uav.Acceleration.ToString());
        EditorGUILayout.LabelField("Velocity: " + uav.rigidbody.velocity);
        EditorGUILayout.LabelField("Time: " + uav.TimeCost.ToString());
        EditorGUILayout.Space();
        uav.AccelerationLimit = EditorGUILayout.FloatField("Acceleration Limit", uav.AccelerationLimit);
        EditorGUILayout.Space();
        heightSet = EditorGUILayout.Slider("Height Set",heightSet, 0, 100);
        if(GUILayout.Button("Set Height"))
        {
            serializedObject.FindProperty("HeightPreSet").floatValue = heightSet;
            uav.HeightSet = heightSet;
        }
        EditorGUILayout.Space();
        if (PIDParamShow = EditorGUILayout.Foldout(PIDParamShow, "PID Parameters"))
        {
            if (Application.isEditor)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Kp"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Ki"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Kd"));
            }
            else
            {
                uav.Kp = EditorGUILayout.FloatField("Kp", uav.Kp);
                uav.Ki = EditorGUILayout.FloatField("Ki", uav.Ki);
                uav.Kd = EditorGUILayout.FloatField("Kd", uav.Kd);
            }
            EditorGUILayout.LabelField("Integral: " + uav.Integral.ToString());
            EditorGUILayout.LabelField("Derivative: " + uav.Derivative.ToString());
        }
        if (Application.isEditor)
            serializedObject.ApplyModifiedProperties();
    }
}
