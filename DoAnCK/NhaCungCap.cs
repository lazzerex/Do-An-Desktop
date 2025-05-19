using System;
using System.Runtime.Serialization;

[Serializable]
public class NhaCungCap : ISerializable
{
    private string id_ncc;
    private string ten_ncc;
    private string sdt_ncc;
    private string dia_chi_ncc;

    public string IdNcc
    {
        get { return id_ncc; }
        set { id_ncc = value; }
    }

    public string TenNcc
    {
        get { return ten_ncc; }
        set { ten_ncc = value; }
    }

    public string SdtNcc
    {
        get { return sdt_ncc; }
        set { sdt_ncc = value; }
    }

    public string DiaChiNcc
    {
        get { return dia_chi_ncc; }
        set { dia_chi_ncc = value; }
    }

    private NhaCungCap() { }

    public NhaCungCap(string id_ncc, string ten_ncc, string sdt_ncc, string dia_chi_ncc)
    {
        this.id_ncc = id_ncc;
        this.ten_ncc = ten_ncc;
        this.sdt_ncc = sdt_ncc;
        this.dia_chi_ncc = dia_chi_ncc;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_ncc", id_ncc);
        info.AddValue("ten_ncc", ten_ncc);
        info.AddValue("sdt_ncc", sdt_ncc);
        info.AddValue("dia_chi_ncc", dia_chi_ncc);
    }

    private NhaCungCap(SerializationInfo info, StreamingContext context)
    {
        id_ncc = info.GetString("id_ncc");
        ten_ncc = info.GetString("ten_ncc");
        dia_chi_ncc = info.GetString("dia_chi_ncc");
        sdt_ncc = info.GetString("sdt_ncc");
    }
}
