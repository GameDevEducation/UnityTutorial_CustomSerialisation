using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DemoBase
{

}

public class DemoChild1 : DemoBase { }
public class DemoChild2 : DemoBase { }

public class SerializableTypeTestScript : MonoBehaviour
{
    public SerializableType<DemoBase> DemoSelection = null;
    public List<SerializableType<DemoBase>> DemoSelectionList = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DemoSelection.Type);

        foreach (var Entry in DemoSelectionList)
            Debug.Log(Entry.Type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
