using UnityEngine;
using UnityEngine.UI;
using EasyUI.Tabs;

[ExecuteInEditMode]
public class TabsUIHorizontal : TabsUI
{
    #if UNITY_EDITOR
    private void Reset() {
        OnValidate();
    }
    private void OnValidate() {
        base.Validate(TabsType.Horizontal);
    }
    #endif
}
