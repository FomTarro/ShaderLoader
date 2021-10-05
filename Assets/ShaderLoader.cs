using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShaderLoader : MonoBehaviour
{

    [SerializeField]
    private Dropdown _dropdown;
    [SerializeField]
    private List<Shader> _shaders = new List<Shader>();

    [SerializeField]
    private MeshRenderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        this._renderer = GetComponent<MeshRenderer>();
        Application.OpenURL(Application.streamingAssetsPath);
        Debug.Log(Application.streamingAssetsPath);
        string[] paths = Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, "Shaders"), "*.");
        foreach(string path in paths){
            Debug.Log("Loading: " + path);
            AssetBundle bundle = AssetBundle.LoadFromFile(path);
            Object[] objects = bundle.LoadAllAssets(typeof(Shader));
            foreach(Object o in objects){
                Debug.Log("File: " + o.name);
                this._shaders.Add((Shader)o);
            }
        }
        PopulateDropdown();
    }

    private void PopulateDropdown(){
        this._dropdown.ClearOptions();
        List<Dropdown.OptionData> data = new List<Dropdown.OptionData>();
        foreach(Shader s in this._shaders){
            data.Add(new Dropdown.OptionData(s.name));
        }
        this._dropdown.AddOptions(data);
    }

    public void SetShader(int i){
        _renderer.material = new Material(this._shaders[i]);
    }
}
