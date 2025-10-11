using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace NeuroQuest.Infrastructure
{
    public class AddressablesLoader
    {
        private static readonly Dictionary<string, object> _cache = new();

        public static async Task<T> LoadAsync<T>(string address) where T : Object
        {
            if (string.IsNullOrEmpty(address))
            {
                Debug.LogError("[AddressablesLoader] Пустой адрес ресурса!");
                return null;
            }

            if (_cache.TryGetValue(address, out var cached))
            {
                return cached as T;
            }

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(address);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _cache[address] = handle.Result;
                return handle.Result;
            }

            Debug.LogError($"[AddressablesLoader] Ошибка загрузки ресурса: {address}");
            return null;
        }

        public static void ClearCache()
        {
            foreach (var kvp in _cache)
            {
                Addressables.Release(kvp.Value);
            }

            _cache.Clear();
        }
    }
}

