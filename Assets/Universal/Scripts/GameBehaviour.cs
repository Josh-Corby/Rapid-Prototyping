using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : JMC
{
    protected static Proto1.GameManager _GM1 { get { return Proto1.GameManager.INSTANCE; } }
    protected static Proto1.UIManager _UI1 { get { return Proto1.UIManager.INSTANCE; } }
    protected static Proto1.SpawnManager _SM {  get { return Proto1.SpawnManager.INSTANCE; } }
    protected static Proto1.Scoring _S { get { return Proto1.Scoring.INSTANCE; } }
    protected static Proto2.UIManager _UI2 { get { return Proto2.UIManager.INSTANCE; } }
   
}

public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    private static T instance_;
    public static T INSTANCE
    {
        get
        {
            if (instance_ == null)
            {
                instance_ = GameObject.FindObjectOfType<T>();
                if (instance_ == null)
                {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    singleton.AddComponent<T>();
                }
            }
            return instance_;
        }
    }
    protected virtual void Awake()
    {
        if (instance_ == null)
        {
            instance_ = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
