using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork 
{
    //存储烟花的基本信息

    //烟花的ID号
    public int fireWorkID;
    //烟花颜色
    public Color fireWorkColor;
    //烟花形状
    public FireWorkShape fireWorkShape;

    public FireWork(int id, Color color, FireWorkShape shape)
    {
        fireWorkID = id;
        fireWorkColor = color;
        fireWorkShape = shape;
    }
}

public enum FireWorkShape
{
    fireWorkType1,
    fireWorkType2,
    fireWorkType3,
    fireWorkType4,
    fireWorkType5,
    fireWorkType6,
    fireWorkType7,
    fireWorkType8,
    fireWorkType9

}
