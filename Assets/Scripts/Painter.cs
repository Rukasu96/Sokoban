using UnityEngine;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEditor.TerrainTools;
using System;
using System.Collections.Generic;
using UnityEditor.SearchService;

public class Painter : EditorWindow
{
    public GameObject objectPrefab;
    public int width = 2;
    public int height = 2;
    public float cellSize;
    public int[,] gridArray;
    public List<GameObject> cells;
    bool paintTog;
    bool eraseTog;

    public GameObject cell;

    [MenuItem("Tools/Grid")]
    public static void ShowWindow()
    {
        GetWindow<Painter>("Grid");
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn objects on grid", EditorStyles.boldLabel);

        objectPrefab = EditorGUILayout.ObjectField("Prefab to spawn", objectPrefab, typeof(GameObject), false) as GameObject;
        cell = EditorGUILayout.ObjectField("Plane as cell", cell, typeof(GameObject), false) as GameObject;
        width = EditorGUILayout.IntField("szerokosc", width);
        height = EditorGUILayout.IntField("wysokoœæ", height);
        cellSize = EditorGUILayout.FloatField("Cell", cellSize);

        paintTog = EditorGUILayout.ToggleLeft("Paint", paintTog);
        eraseTog = EditorGUILayout.ToggleLeft("Erase", eraseTog);

        gridArray = new int[width, height];

    }

    void OnSceneGUI(SceneView sceneView)
    {
        Event current = Event.current;

        if (paintTog)
        {
            MakeDebugLines();
            
            if (current.type == EventType.MouseDown && current.button == 0)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(current.mousePosition);
                if (Physics.Raycast(ray,out RaycastHit hit))
                {
                    GameObject clone = Instantiate(objectPrefab, hit.transform.position, Quaternion.identity);
                    DestroyImmediate(hit.transform.gameObject);
                    cells.Add(clone);
                }
            }
        }
        else
        {
            cells.Clear();
        }

        if (eraseTog && current.type == EventType.MouseDown && current.button == 0)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(current.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit) && !hit.transform.CompareTag("GridPlane"))
            {
                cells.Remove(hit.transform.gameObject);
                DestroyImmediate(hit.transform.gameObject);
                GameObject cellClone = Instantiate(cell, GetWorldPosition((int)hit.transform.position.x, (int)hit.transform.position.z) + new Vector3(cellSize, 0f, cellSize) * 0.5f, Quaternion.identity);
                cells.Add(cellClone);
            }
        }

    }

    void MakeDebugLines()
    {
        if(cells.Count >= width * height)
        {
            return;
        }

        cells = new List<GameObject>();

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                Handles.Label(GetWorldPosition(x, z), gridArray[x, z].ToString());
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x, z + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, z), GetWorldPosition(x + 1, z), Color.white, 100f);
                GameObject cellClone = Instantiate(cell, GetWorldPosition(x, z) + new Vector3(cellSize, 0f, cellSize) * 0.5f, Quaternion.identity);
                cellClone.transform.localScale = new Vector3(cellSize, 0.1f, cellSize);
                cells.Add(cellClone);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize;
    }



}
