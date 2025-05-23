using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;


[XmlInclude(typeof(DienTu))]
[XmlInclude(typeof(GiaDung))]
[XmlInclude(typeof(ThoiTrang))]
[Serializable]
public abstract class HangHoa : ISerializable, ICloneable
{
    private string id;
    private string ten_hang;
    private uint so_luong;
    private ulong don_gia;
    private ulong gia_ban;
    private string img;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string TenHang
    {
        get { return ten_hang; }
        set { ten_hang = value; }
    }

    public uint SoLuong
    {
        get { return so_luong; }
        set { so_luong = value; }
    }
    
    public ulong GiaBan
    {
        get { return gia_ban;}
        set { gia_ban = value; }
    }

    public ulong DonGia
    {
        get { return don_gia; }
        set { don_gia = value; }
    }

    public string Img
    {
        get { return img; }
        set { img = value; }
    }

    protected HangHoa() { }

    public HangHoa(string id, string ten_hang, uint so_luong, ulong don_gia, string img, ulong gia_ban)
    {
        this.id = id;
        this.ten_hang = ten_hang;
        this.so_luong = so_luong;
        this.don_gia = don_gia;
        this.gia_ban = gia_ban;
        this.img = img;
    }

    public object Clone()
    {
        HangHoa clone = (HangHoa)this.MemberwiseClone();
        clone.id = this.id;
        clone.ten_hang = this.ten_hang;
        clone.don_gia = this.don_gia;
        clone.gia_ban = this.gia_ban;
        return clone;
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id", id);
        info.AddValue("ten_hang", ten_hang);
        info.AddValue("so_luong", so_luong);
        info.AddValue("don_gia", don_gia);
        info.AddValue("gia_ban", gia_ban);
        info.AddValue("img", img);
    }

    protected HangHoa(SerializationInfo info, StreamingContext context)
    {
        id = info.GetString("id");
        ten_hang = info.GetString("ten_hang");
        so_luong = info.GetUInt32("so_luong");
        don_gia = info.GetUInt64("don_gia");
        gia_ban = info.GetUInt64("gia_ban");
        img = info.GetString("img");
    }
}

[Serializable]
public class DienTu : HangHoa
{
    private DienTu() { }

    public DienTu(string id, string ten_hang, uint so_luong, ulong don_gia, string img, ulong gia_ban) : base(id, ten_hang, so_luong, don_gia, img,gia_ban)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private DienTu(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class GiaDung : HangHoa
{
    private GiaDung() { }

    public GiaDung(string id, string ten_hang, uint so_luong, ulong don_gia, string img, ulong gia_ban) : base(id, ten_hang, so_luong, don_gia, img,gia_ban)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private GiaDung(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}

[Serializable]
public class ThoiTrang : HangHoa
{
    private ThoiTrang() { }

    public ThoiTrang(string id, string ten_hang, uint so_luong, ulong don_gia, string img, ulong gia_ban) : base(id, ten_hang, so_luong, don_gia, img,gia_ban)
    {
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);
    }

    private ThoiTrang(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
