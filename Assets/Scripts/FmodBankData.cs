using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
namespace FmodTest {
  [Serializable]
  public class FmodBankData {
    [SerializeField] private AssetReferenceT<TextAsset> assetReference;

    public AssetReferenceT<TextAsset> Reference() {
      return assetReference;
    }

    [SerializeField] private bool loadSamples;

    public bool LoadSamples() {
      return loadSamples;
    }
  }
}