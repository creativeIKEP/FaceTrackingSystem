using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class UDPBlendShapeVisualizer : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField]
    float coefficientScale = 100.0f;

    public void Renering(string json){
        Dictionary<string, object> data = MiniJSON.Json.Deserialize(json) as Dictionary<string, object>;
        if(data == null){
            return;
        }
        Debug.Log("レンダリング");
        for (int key = 0; key < data.Keys.Count; key++){
            float value = System.Convert.ToSingle(data[key.ToString()]);
            skinnedMeshRenderer.SetBlendShapeWeight(key, value * coefficientScale);
        }
    }
}
