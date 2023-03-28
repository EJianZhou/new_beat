using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainThreadDispatcher : MonoBehaviour
{
    private static MainThreadDispatcher Instance;

    private readonly Queue<System.Action> executionQueue = new Queue<System.Action>();

    private void Awake()
    {
        Debug.Log("Main Thread");
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        lock (executionQueue)
        {
            while (executionQueue.Count > 0)
            {
                var action = executionQueue.Dequeue();
                action();
            }
        }
    }

    public static void Enqueue(System.Action action)
    {
        lock (Instance.executionQueue)
        {
            Instance.executionQueue.Enqueue(action);
        }
    }
}