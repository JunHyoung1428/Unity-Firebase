using System.Threading.Tasks;
using UnityEngine;

public class AsyncTest : MonoBehaviour
{

    public new string name;
    void Start()
    {
        Work();
        Debug.Log($"{name} Wrong Finish");
    }

    private async void Work()
    {
        await Task.Run(Test).ContinueWith(task => {Debug.Log($"{name} Finish");});
        
    }

    private void Test()
    {
        for(int i = 0; i<100; i++ )
        {
            Debug.Log($"{name} {i}");
        }
    }
}
