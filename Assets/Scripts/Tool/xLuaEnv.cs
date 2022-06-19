using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XLua;

public class xLuaEnv
{
    #region Singleton
    private static xLuaEnv _Instance = null;

    public static xLuaEnv Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = new xLuaEnv();
            }
            return _Instance;
        }
    }
    #endregion

    #region Create LuaEnv
    private LuaEnv _Env;
    private xLuaEnv()
    {
        _Env = new LuaEnv();
        _Env.AddLoader(_zProjectLoader);
    }
    #endregion

    #region Loader
    private byte[] _zProjectLoader(ref string filepath)
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
    #endregion

    #region Free LuaEnv
    public void Free()
    {
        _Env.Dispose();
        _Instance = null;
    }
    #endregion
}
