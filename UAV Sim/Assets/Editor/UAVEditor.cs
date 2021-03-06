﻿using System.Collections;
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
        EditorGUILayout.PropertyField(serializedObject.FindProperty("AccelerationLimit"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("MaxPower"));

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
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Kp"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Ki"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("Kd"));
            EditorGUILayout.LabelField("Integral: " + uav.Integral.ToString());
            EditorGUILayout.LabelField("Derivative: " + uav.Derivative.ToString());
        }
        if (Application.isEditor)
            serializedObject.ApplyModifiedProperties();
    }
}
