using UnityEngine;


    public class ObjectPooler : MonoBehaviour
    {
        [SerializeField] PoolManager poolManagerSo;
        [SerializeField] PoolableObject1 poolableObject1;
        [SerializeField] PoolableObject2 poolableObject2;
        [SerializeField] private Transform spawnParent1;
        [SerializeField] private Transform spawnParent2;

        private void Awake()
        {
            if(poolableObject1 == null || poolableObject2 == null) Debug.LogError("Object to be pooled are null");
            poolManagerSo.AddPool(Object1FactoryMethod , Obj1TurnOnCallback, Obj1TurnOffCallback, 10);
            poolManagerSo.AddPool(Object2FactoryMethod , Obj2TurnOnCallback, Obj2TurnOffCallback, 10);
        }

        private void Obj2TurnOffCallback(PoolableObject2 obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void Obj2TurnOnCallback(PoolableObject2 obj)
        {
            obj.gameObject.SetActive(true);
        }

        private void Obj1TurnOffCallback(PoolableObject1 obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void Obj1TurnOnCallback(PoolableObject1 obj)
        {
            obj.gameObject.SetActive(true);
        }

        PoolableObject1 Object1FactoryMethod()
        {
            var obj = Instantiate(poolableObject1);
            return obj;
        }
        PoolableObject2 Object2FactoryMethod()
        {
            var obj = Instantiate(poolableObject2);
            return obj;
        }
    }

    public class PoolableObject1 : MonoBehaviour
    {
        
    }
    public class PoolableObject2 : MonoBehaviour
    {
        
    }
