using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MyLoader();
    }

    public void SystemLoader()
    {
        LuaEnv env = new LuaEnv();

        env.DoString("require('test')");

        env.Dispose();
    }

    public void MyLoader()
    {
        LuaEnv env = new LuaEnv();
        env.AddLoader(zProjectLoader);
        env.DoString("require('test1')");
        env.Dispose();
    }

    //自定义加载器,且先于内置加载器
    public byte[] zProjectLoader(ref string filepath)
    {
        Debug.Log(filepath);
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 7) + "/DataPath/Lua/" + filepath + ".lua";
        Debug.Log(path);

        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            return null;
        }
    }
}
