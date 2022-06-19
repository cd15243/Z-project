using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class luaUseCsharp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaCallCSharpCode();
        LuaReturnData();
    }

    public void LuaCallCSharpCode()
    {
        LuaEnv env = new LuaEnv();

        //Lua����c#���루CS.�����ռ�.������(����)��
        env.DoString("CS.UnityEngine.Debug.Log('from lua')");

        //env.DoString("");
        env.Dispose();
    }

    public void LuaReturnData()
    {
        LuaEnv env = new LuaEnv();

        object[] data = env.DoString("return 100,true");
        Debug.Log("Lua�ĵ�һ������ֵ��" + data[0].ToString());
        Debug.Log("Lua�ĵڶ�������ֵ��" + data[1].ToString());
        env.Dispose();
    }
}
