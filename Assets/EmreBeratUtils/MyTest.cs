using UnityEngine;
using NaughtyAttributes;
using EmreBeratUtils.Extensions;

public class MyTest : MonoBehaviour
{

    [Button()]
    private void RenameAll()
    {
        transform.RenameChildren("Child");
    }

    [Button()]
    private void ParentMethod()
    {
        transform.DetachChild(18);
    }
    
}
