# UniSetActiveExtensionMethods

複数のゲームオブジェクトのアクティブを一括で変更する拡張メソッド

## 使用例

```cs
using Kogane;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private GameObject[]                   m_gameObjects;
    private Dictionary<string, GameObject> m_gameObjectTable;

    private void Awake()
    {
        m_gameObjects = new[]
        {
            GameObject.CreatePrimitive( PrimitiveType.Sphere ),
            GameObject.CreatePrimitive( PrimitiveType.Capsule ),
            GameObject.CreatePrimitive( PrimitiveType.Cylinder ),
        };

        m_gameObjectTable = new Dictionary<string, GameObject>
        {
            { "Sphere", m_gameObjects[ 0 ] },
            { "Capsule", m_gameObjects[ 1 ] },
            { "Cylinder", m_gameObjects[ 2 ] },
        };
    }

    private void Update()
    {
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            // すべてのゲームオブジェクトを非アクティブにする
            m_gameObjects.SetActiveAll( false );
        }

        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            // すべてのゲームオブジェクトをアクティブにする
            m_gameObjects.SetActiveAll( true );
        }

        if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
        {
            // インデックス 1 のゲームオブジェクトをアクティブにする
            // それ以外のゲームオブジェクトは非アクティブにする
            m_gameObjects.SetActive( 1 );
        }

        if ( Input.GetKeyDown( KeyCode.Alpha4 ) )
        {
            // キーが Cylinder のゲームオブジェクトをアクティブにする
            // それ以外のゲームオブジェクトは非アクティブにする
            m_gameObjectTable.SetActive( "Cylinder" );
        }
    }
}
```
