using DoAnCK;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DoAnCK
{
    public class KhoHang
    {
        public List<HangHoa> ds_hang_hoa = new List<HangHoa>();
        public List<NhanVien> ds_nhan_vien = new List<NhanVien>();
        public List<CuaHang> ds_cua_hang = new List<CuaHang>();
        public List<NhaCungCap> ds_ncc = new List<NhaCungCap>();
        public List<HoaDonNhap> ds_hoa_don_nhap = new List<HoaDonNhap>();
        public List<HoaDonXuat> ds_hoa_don_xuat = new List<HoaDonXuat>();

        public bool kha_dung(QuanLyNhapXuat qlnx)
        {
            for (int i = 0; i < qlnx.ds_hang_hoa.Count; i++)
            {
                HangHoa hh = qlnx.ds_hang_hoa[i];
                HangHoa hh_kho = FindHangHoaById(hh.Id);
                if (hh.SoLuong > hh_kho.SoLuong)
                {
                    return false;
                }
            }
            return true;
        }

        public void capnhatkho(QuanLyNhapXuat qlnx, bool isnhap)
        {
            for (int i = 0; i < qlnx.ds_hang_hoa.Count; i++)
            {
                HangHoa hanghoa = qlnx.ds_hang_hoa[i];
                HangHoa hh_kho = FindHangHoaById(hanghoa.Id);
                if (isnhap)
                {
                    hh_kho.SoLuong += hanghoa.SoLuong;
                }
                else
                {
                    hh_kho.SoLuong -= hanghoa.SoLuong;
                }
            }
            LuuDanhSachHH();
        }

        public NhanVien dang_nhap(string username, string password)
        {
            for (int i = 0; i < ds_nhan_vien.Count; i++)
            {
                NhanVien nv = ds_nhan_vien[i];
                if (nv.Username == username && nv.Password == password)
                {
                    return nv;
                }
            }
            return null;
        }

        public void LuuDanhSachCH()
        {
            LuuDanhSach("Resources/cua_hang.dat", ds_cua_hang);
        }

        public void LuuDanhSachNCC()
        {
            LuuDanhSach("Resources/nha_cung_cap.dat", ds_ncc);
        }

        public void ThemHoaDonNhap(HoaDonNhap hoaDon)
        {
            ds_hoa_don_nhap.Add(hoaDon);
            LuuDanhSachHDN();
        }

        public void ThemHoaDonXuat(HoaDonXuat hoaDon)
        {
            ds_hoa_don_xuat.Add(hoaDon);
            LuuDanhSachHDX();
        }

        public void them_hh(HangHoa hh)
        {
            ds_hang_hoa.Add(hh);
            LuuDanhSachHH();
        }

        public void xoa_hh(HangHoa hh)
        {
            ds_hang_hoa.Remove(hh);
            LuuDanhSachHH();
        }

        public void LoadData()
        {
            ds_hang_hoa = LoadDanhSach<HangHoa>("Resources/hang_hoa.dat");
            ds_ncc = LoadDanhSach<NhaCungCap>("Resources/nha_cung_cap.dat");
            ds_cua_hang = LoadDanhSach<CuaHang>("Resources/cua_hang.dat");
            ds_hoa_don_nhap = LoadDanhSach<HoaDonNhap>("Resources/hoa_don_nhap.dat");
            ds_hoa_don_xuat = LoadDanhSach<HoaDonXuat>("Resources/hoa_don_xuat.dat");
            ds_nhan_vien = LoadDanhSach<NhanVien>("Resources/nhan_vien.dat");
        }

        private HangHoa FindHangHoaById(string id)
        {
            for (int i = 0; i < ds_hang_hoa.Count; i++)
            {
                if (ds_hang_hoa[i].Id == id)
                {
                    return ds_hang_hoa[i];
                }
            }
            return null;
        }

        private void LuuDanhSach(string filePath, object data)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(data.GetType());
                serializer.Serialize(writer, data);
            }
        }

        private void LuuDanhSachHH()
        {
            LuuDanhSach("Resources/hang_hoa.dat", ds_hang_hoa);
        }

        private void LuuDanhSachHDX()
        {
            LuuDanhSach("Resources/hoa_don_xuat.dat", ds_hoa_don_xuat);
        }

        private void LuuDanhSachHDN()
        {
            LuuDanhSach("Resources/hoa_don_nhap.dat", ds_hoa_don_nhap);
        }

        private List<T> LoadDanhSach<T>(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                return (List<T>)serializer.Deserialize(reader);
            }
        }
    }
}