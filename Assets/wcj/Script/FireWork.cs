using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    //存储烟花的基本信息

    //烟花的ID号
    public int fireWorkID;
    //烟花颜色
    public Color fireWorkColor;
    //烟花形状
    public FireWorkShape fireWorkShape;

}

public enum FireWorkShape
{
    fireWorkType1,
    fireWorkType2,
    fireWorkType3,
    fireWorkType4
}
