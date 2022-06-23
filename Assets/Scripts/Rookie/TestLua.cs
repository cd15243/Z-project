using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class TestLua : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //创建Lua环境
        LuaEnv env = new LuaEnv();

        env.DoString("print('Hello world!')");

        env.Dispose();
    }
}
