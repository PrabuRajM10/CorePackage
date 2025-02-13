using System;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(menuName = "ScriptableObjects/Create PoolManager", fileName = "PoolManager", order = 0)]
    public class PoolManager : ScriptableObject
    {
        const string KeySuffix = "ByType";
        Dictionary<string , AbstractPool> pools = new Dictionary<string , AbstractPool>();

        public void AddPool<T>( Func<T> factoryMethod, Action<T> turnOnCallback,
            Action<T> turnOffCallback, int poolSize = 0)
        {
            if (!pools.ContainsKey(typeof(T) + KeySuffix))
            {
                pools.Add(typeof(T) + KeySuffix , new ObjectPool<T>(factoryMethod , turnOnCallback , turnOffCallback , poolSize));
            }
        }

        public void RemovePool<T>()
        {
            if (pools.ContainsKey(typeof(T) + KeySuffix))
            {
                pools.Remove(typeof(T) + KeySuffix);
            }
        }

        public ObjectPool<T> GetPool<T>()
        {
            pools.TryGetValue(typeof(T) + KeySuffix, out AbstractPool pool);
            return (ObjectPool<T>)pool;
        }

        public T GetPoolObject<T>()
        {
            pools.TryGetValue(typeof(T) + KeySuffix, out AbstractPool pool);
            return (((ObjectPool<T>)pool)!).GetObject();
        }

        public void ReturnPoolObject<T>(T poolObject)
        {
            pools.TryGetValue(typeof(T) + KeySuffix, out AbstractPool pool);
            (((ObjectPool<T>)pool)!).ReturnObject(poolObject);
        }
    }
