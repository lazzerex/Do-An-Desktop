using System.Runtime.Serialization;
using System.Xml.Serialization;
using System;

namespace DoAnCK
{
    [XmlInclude(typeof(HoaDonNhap))]
    [XmlInclude(typeof(HoaDonXuat))]
    [Serializable]
    public abstract class HoaDon : ISerializable
    {
        private string id_hoa_don;
        private DateTime ngay_tao_don;
        private QuanLyNhapXuat qlnx;
        private NhanVien nv_lap;
        private ulong tong_tien;

        public string IdHoaDon
        {
            get { return id_hoa_don; }
            set { id_hoa_don = value; }
        }

        public DateTime NgayTaoDon
        {
            get { return ngay_tao_don; }
            set { ngay_tao_don = value; }
        }

        public QuanLyNhapXuat Qlnx
        {
            get { return qlnx; }
            set { qlnx = value; }
        }

        public NhanVien NvLap
        {
            get { return nv_lap; }
            set { nv_lap = value; }
        }

        public ulong TongTien
        {
            get { return tong_tien; }
            set { tong_tien = value; }
        }

        protected HoaDon() { }

        public HoaDon(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, ulong tong_tien)
        {
            this.ngay_tao_don = DateTime.Now;
            this.id_hoa_don = id_hoa_don;
            this.qlnx = qlnx;
            this.nv_lap = nv_lap;
            this.tong_tien = tong_tien;
        }

        public abstract string SetID();

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id_hoa_don", id_hoa_don);
            info.AddValue("ngay_tao_don", ngay_tao_don);
            info.AddValue("qlnx", qlnx);
            info.AddValue("nv_lap", nv_lap);
            info.AddValue("tong_tien", tong_tien);
        }

        protected HoaDon(SerializationInfo info, StreamingContext context)
        {
            id_hoa_don = info.GetString("id_hoa_don");
            ngay_tao_don = (DateTime)info.GetValue("ngay_tao_don", typeof(DateTime));
            qlnx = (QuanLyNhapXuat)info.GetValue("qlnx", typeof(QuanLyNhapXuat));
            nv_lap = (NhanVien)info.GetValue("nv_lap", typeof(NhanVien));
            tong_tien = info.GetUInt64("tong_tien");
        }
    }

    [Serializable]
    public class HoaDonNhap : HoaDon
    {
        private NhaCungCap nha_cung_cap;

        public NhaCungCap NhaCungCap
        {
            get { return nha_cung_cap; }
            set { nha_cung_cap = value; }
        }

        private HoaDonNhap() { }

        public HoaDonNhap(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, NhaCungCap nha_cung_cap, ulong tong_tien)
            : base(qlnx, id_hoa_don, nv_lap, tong_tien)
        {
            this.nha_cung_cap = nha_cung_cap;
            NgayTaoDon = DateTime.Now;
        }

        public override string SetID()
        {
            return "HDN";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("nha_cung_cap", nha_cung_cap);
        }

        private HoaDonNhap(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            nha_cung_cap = (NhaCungCap)info.GetValue("nha_cung_cap", typeof(NhaCungCap));
        }
    }

    [Serializable]
    public class HoaDonXuat : HoaDon
    {
        private CuaHang cua_hang;

        public CuaHang CuaHang
        {
            get { return cua_hang; }
            set { cua_hang = value; }
        }

        private HoaDonXuat() { }

        public HoaDonXuat(QuanLyNhapXuat qlnx, string id_hoa_don, NhanVien nv_lap, CuaHang cua_hang, ulong tong_tien)
            : base(qlnx, id_hoa_don, nv_lap, tong_tien)
        {
            NgayTaoDon = DateTime.Now;
            this.cua_hang = cua_hang;
        }

        public override string SetID()
        {
            return "HDX";
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("cua_hang", cua_hang);
        }

        private HoaDonXuat(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            cua_hang = (CuaHang)info.GetValue("cua_hang", typeof(CuaHang));
        }
    }
}