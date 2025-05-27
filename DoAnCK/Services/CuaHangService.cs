using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class CuaHangService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormCuaHang view;

        public CuaHangService(FormCuaHang view)
        {
            this.view = view;
        }

        public void LoadStores()
        {
            view.ClearStoreGrid();
            foreach (CuaHang ch in kho.ds_cua_hang)
            {
                view.AddStoreRow(ch.IdCh, ch.TenCh, ch.SdtCh, ch.DiaChiCh);
            }
            view.EnableStoreGrid(kho.ds_cua_hang.Count > 0);
        }

        public void AddStore(string id, string ten, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(ten))
            {
                view.ShowError("ID và tên cửa hàng không được để trống!");
                return;
            }

            CuaHang ch = new CuaHang(id, ten, sdt, diaChi);
            kho.ds_cua_hang.Add(ch);
            kho.LuuDanhSachCH();
            Logger.LogThemCuaHang(kho.CurrentNhanVien, ch);

            view.AddStoreRow(id, ten, sdt, diaChi);
            view.ShowMessage("Đã thêm cửa hàng thành công!");
            view.ResetForm();
        }

        public void UpdateStore(int index, string id, string ten, string sdt, string diaChi)
        {
            if (index < 0 || index >= kho.ds_cua_hang.Count)
            {
                view.ShowError("Vui lòng chọn một cửa hàng để cập nhật!");
                return;
            }

            CuaHang oldCH = new CuaHang(kho.ds_cua_hang[index].IdCh, kho.ds_cua_hang[index].TenCh, kho.ds_cua_hang[index].SdtCh, kho.ds_cua_hang[index].DiaChiCh);
            CuaHang ch = kho.ds_cua_hang[index];
            ch.IdCh = id;
            ch.TenCh = ten;
            ch.SdtCh = sdt;
            ch.DiaChiCh = diaChi;

            kho.LuuDanhSachCH();
            Logger.LogSuaThongTinCH(kho.CurrentNhanVien, oldCH, ch);

            view.UpdateStoreRow(index, id, ten, sdt, diaChi);
            view.ShowMessage("Cập nhật cửa hàng thành công!");
            view.ResetForm();
        }

        public void DeleteStore(int index)
        {
            if (index < 0 || index >= kho.ds_cua_hang.Count)
            {
                view.ShowError("Vui lòng chọn một cửa hàng để xóa!");
                return;
            }

            CuaHang ch = kho.ds_cua_hang[index];
            kho.XoaCuaHang(ch.IdCh);
            kho.ds_cua_hang.RemoveAt(index);
            kho.LuuDanhSachCH();
            Logger.LogXoaCuaHang(kho.CurrentNhanVien, ch);

            view.RemoveStoreRow(index);
            view.ShowMessage("Đã xóa cửa hàng thành công!");
            view.ResetForm();
        }

        public void SelectStore(int index)
        {
            if (index >= 0 && index < kho.ds_cua_hang.Count)
            {
                CuaHang ch = kho.ds_cua_hang[index];
                view.SetStoreInfo(ch.IdCh, ch.TenCh, ch.SdtCh, ch.DiaChiCh);
            }
        }
    }
}