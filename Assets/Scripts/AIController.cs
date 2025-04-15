using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private List<State> states;

    private void Update()
    {
        float maxUtility = 0;
        State targetState = null;
        foreach (var state in states) 
        {
            var utility = state.Evaluate();
            if (maxUtility < utility) 
            {
                Debug.Log(state.name);
                maxUtility = utility;
                targetState = state;
            }
        }

        targetState?.Execute();
    }
}
