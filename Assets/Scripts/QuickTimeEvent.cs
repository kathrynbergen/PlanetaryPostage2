using UnityEngine;

public class QuickTimeEvent : MonoBehaviour
{
    private Chuck Chuck;
    public GameObject QTEText;
    
    
    public void StartQTE(int planetsVisited)
    {
        Chuck.Shoot();
        if (planetsVisited < 2)
        {
            
        }
        else if (planetsVisited < 4){
            
        }
        else
        {
            
        }
        
    }
}
