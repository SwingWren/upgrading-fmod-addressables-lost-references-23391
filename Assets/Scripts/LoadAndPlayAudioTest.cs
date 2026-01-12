using Cysharp.Threading.Tasks;
using FMODUnity;
using UnityEngine;

namespace FmodTest {
  public class LoadAndPlayAudioTest : MonoBehaviour {
    [SerializeField] private FmodBankData[] banksData;
    [SerializeField] private EventReference musicOneEventRef;

    private void Awake() {
      Main().Forget();
    }

    private async UniTask Main() {
      await LoadAllBanks();
      RuntimeManager.PlayOneShot(musicOneEventRef);
    }

    private async UniTask LoadAllBanks() {
      foreach (FmodBankData bankData in banksData) {
        UniTaskCompletionSource completionTaskSource = new();
        void OnLoad() {
          completionTaskSource.TrySetResult();
        }
        RuntimeManager.LoadBank(bankData.Reference(), bankData.LoadSamples(), OnLoad);
        await completionTaskSource.Task;
      }
    }
  }
}