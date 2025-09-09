using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject _SlotPrefab;
    private int RowCount = 5;
    private int ColCount = 5;

    private float Position_X_Axis = 0f;
    private float Position_Z_Axis = 0f;

    [SerializeField]
    private GameObject MainPlot;

    private void Start()
    {

        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                GameObject SlotClone = Instantiate(_SlotPrefab);
                //SlotClone.transform.SetParent(MainPlot.transform, false);
                SlotClone.transform.position = new Vector3(Position_X_Axis, MainPlot.transform.position.y + SlotClone.transform.localScale.y, Position_Z_Axis);

                Position_X_Axis += _SlotPrefab.transform.localScale.x;
            }

            Position_X_Axis = 0f;
            Position_Z_Axis += _SlotPrefab.transform.localScale.z;
        }
    }
}
