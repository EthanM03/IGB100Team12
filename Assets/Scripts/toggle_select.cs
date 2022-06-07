using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class toggle_select : MonoBehaviour
{
    ToggleGroup toggleGroup;
    
    public Toggle currenSelection
    {
        get { return toggleGroup.ActiveToggles().FirstOrDefault(); }
    }
    // Start is called before the first frame update
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void select_Toggle(int id)
    {

    }
    
}
