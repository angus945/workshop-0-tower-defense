using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] LayerMask selectionLayer;

    Collider2D[] selection = new Collider2D[1];

    UnitGroup selectGroup;


    void Start()
    {

    }
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            GetSelection();
        }
        if (selectGroup != null)
        {
            Vector3 target = GetMousePosition();
            selectGroup.SetDestination(target);
        }
        if (Input.GetMouseButtonUp(0))
        {
            selectGroup = null;
        }
    }

    Vector3 GetMousePosition()
    {
        Vector3 mosuePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mosuePos.z = 0;

        return mosuePos;
    }
    void GetSelection()
    {
        Vector3 mosuePos = GetMousePosition();

        int count = Physics2D.OverlapCircleNonAlloc(mosuePos, 0.01f, selection, selectionLayer);

        if (count > 0)
        {
            if (selection[0].TryGetComponent<UnitGroup>(out selectGroup))
            {
                //state = SelectState.Group;
            }
        }
    }

}
