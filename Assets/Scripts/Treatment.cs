using UnityEngine;


public class Treatment : Weapon
{
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                Heal(enemy);
            }
        }
    }
}