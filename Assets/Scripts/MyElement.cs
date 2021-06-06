using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyElement : MonoBehaviour
{
    public string Name;
    public Point PlusPoint;
    public Point MinusPoint;

    private string plusConnectedName;
    private string minusConnectedName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Check()
    {
        plusConnectedName = PlusPoint.connectedPoint.transform.parent.GetComponent<MyElement>().Name;
        minusConnectedName = MinusPoint.connectedPoint.transform.parent.GetComponent<MyElement>().Name;

        switch (Name)
        {
            case "battary":
                return (plusConnectedName == "ampermeter" && minusConnectedName == "resister");
            case "ampermeter":
                return (plusConnectedName == "resister" && minusConnectedName == "battary");
            case "voltmeter":
                return true;
            case "resister":
                return (plusConnectedName == "battary" && minusConnectedName == "ampermeter");
        }
        return false;
    }
}
