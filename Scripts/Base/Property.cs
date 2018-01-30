using UnityEngine;
using System.Collections;

public enum EPropertyType
{
    EPropertyType_Byte,
    EPropertyType_Bool,
    EPropertyType_Short,
    EPropertyType_Int,
    EPropertyType_Long,
    EPropertyType_Float,
    EPropertyType_Double,
    EPropertyType_Vector3,
    EPropertyType_Vector4,
    EPropertyType_Vector2,
    EPropertyType_Quaternion,
    EPropertyType_Matrix4x4,
    EPropertyType_Color,
    EPropertyType_String,
    EPropertyType_Object
}

 
public class Property
{

    protected object m_value;
    protected string m_name;
    protected EPropertyType m_type;

    public EPropertyType type
    {
        get
        {
            return type;
        }
    }

    public string name
    {
        get
        {
            return m_name;
        }
        set
        {
            m_name = value;
        }
    }

    public object value
    {
        get
        {
            return m_value;
        }
        set
        {
            m_value = value;
            
            
        }
    }


    public void SetValue(object value)
    {
        string typeName = value.GetType().ToString();
        switch (typeName)
        {
            case "byte":
                {
                    if (type == EPropertyType.EPropertyType_Byte)
                    {
                        ByteProperty prop = this as ByteProperty;
                        prop.SetValue((byte)value);
                        return;
                    }
                        
                }
                break;
            case "bool":
                {
                    if (type == EPropertyType.EPropertyType_Bool)
                    {
                        BoolProperty prop = this as BoolProperty;
                        prop.SetValue((bool)value);
                        return;
                    }
                }
                break;
            case "short":
                {
                    if (type == EPropertyType.EPropertyType_Short)
                    {
                        ShortProperty prop = this as ShortProperty;
                        prop.SetValue((short)value);
                        return;
                    }
                }
                break;
            case "int":
                {
                    if (type == EPropertyType.EPropertyType_Int)
                    {
                        IntProperty prop = this as IntProperty;
                        prop.SetValue((int)value);
                        return;
                    }
                }
                break;
            case "long":
                {
                    if (type == EPropertyType.EPropertyType_Long)
                    {
                        LongProperty prop = this as LongProperty;
                        prop.SetValue((long)value);
                        return;
                    }
                }
                break;
            case "float":
                {
                    if (type == EPropertyType.EPropertyType_Float)
                    {
                        FloatProperty prop = this as FloatProperty;
                        prop.SetValue((float)value);
                        return;
                    }
                }
                break;
            case "double":
                {
                    if (type == EPropertyType.EPropertyType_Double)
                    {
                        DoubleProperty prop = this as DoubleProperty;
                        prop.SetValue((double)value);
                        return;
                    }
                }
                break;
            case "Vector2":
                {
                    if (type == EPropertyType.EPropertyType_Vector2)
                    {
                        Vector2Property prop = this as Vector2Property;
                        prop.SetValue((Vector2)value);
                        return;
                    }
                }
                break;
            case "Vector3":
                {
                    if (type == EPropertyType.EPropertyType_Vector3)
                    {
                        Vector3Property prop = this as Vector3Property;
                        prop.SetValue((Vector3)value);
                        return;
                    }
                }
                break;
            case "Vector4":
                {
                    if (type == EPropertyType.EPropertyType_Vector4)
                    {
                        Vector4Property prop = this as Vector4Property;
                        prop.SetValue((Vector4)value);
                        return;
                    }
                }
                break;
            case "Quaternion":
                {
                    if (type == EPropertyType.EPropertyType_Quaternion)
                    {
                        QuaternionProperty prop = this as QuaternionProperty;
                        prop.SetValue((Quaternion)value);
                        return;
                    }
                }
                break;
            case "Matrix4x4":
                {
                    if (type == EPropertyType.EPropertyType_Matrix4x4)
                    {
                        Matrix4x4Property prop = this as Matrix4x4Property;
                        prop.SetValue((Matrix4x4)value);
                        return;
                    }
                }
                break;
            case "Color":
                {
                    if (type == EPropertyType.EPropertyType_Color)
                    {
                        ColorProperty prop = this as ColorProperty;
                        prop.SetValue((Color)value);
                        return;
                    }
                }
                break;
            case "string":
                {
                    if (type == EPropertyType.EPropertyType_String)
                    {
                        StringProperty prop = this as StringProperty;
                        prop.SetValue((string)value);
                        return;
                    }
                }
                break;
            case "object":
                {
                    if (type == EPropertyType.EPropertyType_Object)
                    {
                        m_value = value;
                        return;
                    }
                }
                break;
        }
        return;

    }

    public Property(string name)
    {
        m_name = name;
        m_type = EPropertyType.EPropertyType_Object;
        m_value = null;
    }

    public Property(string name, object val)
    {
        m_name = name;
        m_type = EPropertyType.EPropertyType_Object;
        m_value = val;
    }


    public override string ToString()
    {
        return m_value.ToString();
    }

    public bool equals(Property other)
    {
        return m_value == other.m_value;
    }
    
     
}

public class ByteProperty : Property
{
    public ByteProperty(string name):base(name)
    {
        m_type = EPropertyType.EPropertyType_Byte;
        m_value = 0;
    }

    public ByteProperty(string name, byte val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Byte;
        m_value = val;
    }

    public byte GetValue()
    {
        return (byte)m_value; 
    }

    public void SetValue(byte val)
    {
        m_value = val;
    }

    public bool equals(ByteProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class BoolProperty : Property
{
    public BoolProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Bool;
        m_value = 0;
    }

    public BoolProperty(string name, bool val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Bool;
        m_value = val;
    }

    public bool GetValue()
    {
        return (bool)m_value;
    }

    public void SetValue(bool val)
    {
        m_value = val;
    }

    public bool equals(BoolProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class IntProperty : Property
{
    public IntProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Int;
        m_value = 0;
    }

    public IntProperty(string name, int val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Int;
        m_value = val;
    }

    public int GetValue()
    {
        return (int)m_value;
    }

    public void SetValue(int val)
    {
        m_value = val;
    }

    public bool equals(IntProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class ShortProperty : Property
{
    public ShortProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Short;
        m_value = 0;
    }

    public ShortProperty(string name, short val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Short;
        m_value = val;
    }

    public short GetValue()
    {
        return (short)m_value;
    }

    public void SetValue(short val)
    {
        m_value = val;
    }

    public bool equals(ShortProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}

public class LongProperty : Property
{
    public LongProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Long;
        m_value = 0;
    }

    public LongProperty(string name, long val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Long;
        m_value = val;
    }

    public long GetValue()
    {
        return (long)m_value;
    }

    public void SetValue(long val)
    {
        m_value = val;
    }

    public bool equals(ShortProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class FloatProperty : Property
{
    public FloatProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Float;
        m_value = 0;
    }

    public FloatProperty(string name, float val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Float;
        m_value = val;
    }

    public float GetValue()
    {
        return (float)m_value;
    }

    public void SetValue(float val)
    {
        m_value = val;
    }

    public bool equals(FloatProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class DoubleProperty : Property
{
    public DoubleProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Double;
        m_value = 0;
    }

    public DoubleProperty(string name, float val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Double;
        m_value = val;
    }

    public double GetValue()
    {
        return (double)m_value;
    }

    public void SetValue(double val)
    {
        m_value = val;
    }

    public bool equals(DoubleProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class Vector2Property : Property
{
    public Vector2Property(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector2;
        m_value = 0;
    }

    public Vector2Property(string name, Vector2 val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector2;
        m_value = val;
    }

    public Vector2 GetValue()
    {
        return (Vector2)m_value;
    }

    public void SetValue(Vector2 val)
    {
        m_value = val;
    }

    public bool equals(Vector2Property other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class Vector3Property : Property
{
    public Vector3Property(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector3;
        m_value = 0;
    }

    public Vector3Property(string name, Vector3 val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector3;
        m_value = val;
    }

    public Vector3 GetValue()
    {
        return (Vector3)m_value;
    }

    public void SetValue(Vector3 val)
    {
        m_value = val;
    }

    public bool equals(Vector3Property other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class Vector4Property : Property
{
    public Vector4Property(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector4;
        m_value = 0;
    }

    public Vector4Property(string name, Vector4 val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Vector4;
        m_value = val;
    }

    public Vector4 GetValue()
    {
        return (Vector4)m_value;
    }

    public void SetValue(Vector4 val)
    {
        m_value = val;
    }

    public bool equals(Vector4Property other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class QuaternionProperty : Property
{
    public QuaternionProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Quaternion;
        m_value = 0;
    }

    public QuaternionProperty(string name, Quaternion val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Quaternion;
        m_value = val;
    }

    public Quaternion GetValue()
    {
        return (Quaternion)m_value;
    }

    public void SetValue(Quaternion val)
    {
        m_value = val;
    }

    public bool equals(QuaternionProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}

public class ColorProperty : Property
{
    public ColorProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Color;
        m_value = Color.white;
    }

    public ColorProperty(string name, Color val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Color;
        m_value = val;
    }

    public Color GetValue()
    {
        return (Color)m_value;
    }

    public void SetValue(Color val)
    {
        m_value = val;
    }

    public bool equals(ColorProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}



public class StringProperty : Property
{
    public StringProperty(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_String;
        m_value = 0;
    }

    public StringProperty(string name, string val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_String;
        m_value = val;
    }

    public string GetValue()
    {
        return m_value.ToString();
    }

    public void SetValue(string val)
    {
        m_value = val;
    }

    public bool equals(StringProperty other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}


public class Matrix4x4Property : Property
{
    public Matrix4x4Property(string name)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Matrix4x4;
        m_value = 0;
    }

    public Matrix4x4Property(string name, string val)
        : base(name)
    {
        m_type = EPropertyType.EPropertyType_Matrix4x4;
        m_value = val;
    }

    public Matrix4x4 GetValue()
    {
        return (Matrix4x4)m_value;
    }

    public void SetValue(Matrix4x4 val)
    {
        m_value = val;
    }

    public bool equals(Matrix4x4Property other)
    {
        return this.GetValue() == other.GetValue();
    }

    public override string ToString()
    {
        return GetValue().ToString();
    }
}
