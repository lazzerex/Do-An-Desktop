using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public class CuaHang : ISerializable
{
    private string id_ch;
    private string ten_ch;
    private string sdt_ch;
    private string dia_chi_ch;

    public string IdCh
    {
        get { return id_ch; }
        set { id_ch = value; }
    }

    public string TenCh
    {
        get { return ten_ch; }
        set { ten_ch = value; }
    }

    public string SdtCh
    {
        get { return sdt_ch; }
        set { sdt_ch = value; }
    }

    public string DiaChiCh
    {
        get { return dia_chi_ch; }
        set { dia_chi_ch = value; }
    }

    private CuaHang() { }

    public CuaHang(string id_ch, string ten_ch, string sdt_ch, string dia_chi_ch)
    {
        this.id_ch = id_ch;
        this.ten_ch = ten_ch;
        this.sdt_ch = sdt_ch;
        this.dia_chi_ch = dia_chi_ch;
    }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("id_ch", id_ch);
        info.AddValue("ten_ch", ten_ch);
        info.AddValue("sdt_ch", sdt_ch);
        info.AddValue("dia_chi_ch", dia_chi_ch);
    }

    private CuaHang(SerializationInfo info, StreamingContext context)
    {
        id_ch = info.GetString("id_ch");
        ten_ch = info.GetString("ten_ch");
        sdt_ch = info.GetString("sdt_ch");
        dia_chi_ch = info.GetString("dia_chi_ch");
    }
}


public class QuanLyNhapXuat
{
    public List<HangHoa> ds_hang_hoa = new List<HangHoa>();


    public void them_hh(HangHoa hh)
    {
        ds_hang_hoa.Add(hh);
    }
    public void xoa_hh(HangHoa hh)
    {
        ds_hang_hoa.Remove(hh);
    }
    public void cap_nhat_sl(HangHoa hh, uint sl_moi)
    {
        hh.SoLuong = sl_moi;
    }

    public bool ton_tai(HangHoa hh)
    {
        foreach (HangHoa hh_check in ds_hang_hoa)
        {
            if (hh_check.Id == hh.Id)
            {
                return true;
            }
        }
        return false;
    }

    public ulong tinh_tong_tien()
    {
        ulong tong_tien = 0;
        foreach (HangHoa hh in ds_hang_hoa)
        {
            tong_tien += hh.DonGia * hh.SoLuong;
        }
        return tong_tien;
    }
}