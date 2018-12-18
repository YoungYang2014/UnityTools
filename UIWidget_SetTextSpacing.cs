using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UGUI Text 文字间隔调整
/// </summary>
[RequireComponent(typeof(Text))]
public class UIWidget_SetTextSpacing : BaseMeshEffect
{
    //文字间隔
    public float m_Spacing = 1;
    public override void ModifyMesh(VertexHelper vh)
    {
        Text text = GetComponent<Text>();
        if (text == null) return;

        //List<UIVertex> vertexs = new List<UIVertex>();
        //vh.GetUIVertexStream(vertexs);
        //Debug.LogError(vh.currentVertCount);//=字符数*4
        //Debug.LogError(vertexs.Count);//=字符数*6
        UIVertex vt = new UIVertex();
        Vector3 vecOffset = Vector3.zero;
        int charCount = vh.currentVertCount / 4;

        for (int j = 0; j < vh.currentVertCount; j++)
        {
            vh.PopulateUIVertex(ref vt, j);
            vecOffset = new Vector3((j / 4) * m_Spacing, 0, 0);
            if (j >= vh.currentVertCount - 4)
            {
                vecOffset -= new Vector3(m_Spacing, 0, 0);
            }
            vt.position += vecOffset;
            vh.SetUIVertex(vt, j);
        }
        vh.SetUIVertex(vt, vh.currentVertCount - 1);

    }
}
