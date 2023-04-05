using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSystem : MonoBehaviour
{
    static MapSystem instance;
    //public static Vector3 MapCenter { get => instance.gridSystem.CenterPosition(); }

    [SerializeField] Vector2Int mapSzie;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    //void Update()
    //{
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    Vector2Int mosueOnGrid = gridSystem.WorldToGrid(mousePos);
    //}

    //void OnDrawGizmos()
    //{
    //    if (gridSystem == null) return;

    //    gridSystem.Gizmo_DrawGrid();
    //}
}
