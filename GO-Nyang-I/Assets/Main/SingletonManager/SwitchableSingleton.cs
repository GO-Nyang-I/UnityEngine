using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchableSingleton<T> : MonoBehaviour
    where T : SwitchableSingleton<T>
{
    private static List<T> m_Instances = new List<T>();

    public static T instance
    {
        get
        {
            lock(m_Instances)
            {
                return m_Instances.Count > 0 ?
                    m_Instances[m_Instances.Count - 1] : null;
            }
        }
    }

    protected virtual void OnEnable()
    {
        lock(m_Instances)
        {
            T oldInstance = instance;

            m_Instances.Remove(this as T);
            m_Instances.Add(this as T);

            if(oldInstance != this && oldInstance != null)
            {
                if (oldInstance.enabled)
                {
                    oldInstance.enabled = false;
                }
            }
        }
        Debug.Log("GameManager OnEnable");
    }

    protected virtual void OnDisable()
    {
        lock(m_Instances)
        {
            if (instance == this)
            {
                m_Instances.Remove(this as T);

                if (m_Instances.Count > 0)
                {
                    m_Instances.Insert(m_Instances.Count - 1, this as T);
                    if(!m_Instances[m_Instances.Count - 1].enabled)
                    {
                        m_Instances[m_Instances.Count - 1].enabled = true;
                        Debug.Log("OnDisable" + m_Instances[m_Instances.Count - 1].enabled);
                    }
                }
            }
        }
        Debug.Log("GameManager OnDisable");
    }

    protected virtual void OnDestroy()
    {
        lock (m_Instances)
        {
            bool wasBackground = instance != this;
            m_Instances.Remove(this as T);

            if (wasBackground && m_Instances.Count > 0 &&
                !m_Instances[m_Instances.Count - 1].enabled)
            {
                m_Instances[m_Instances.Count - 1].enabled = true;
                Debug.Log("OnDistroy" + m_Instances[m_Instances.Count - 1].enabled);
            }
        }

        Debug.Log("GameManager OnDistroy");
    }
}
