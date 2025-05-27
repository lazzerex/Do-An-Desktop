using System;
using System.Windows.Forms;
using DoAnCK.Models;
using DoAnCK.Utils;

namespace DoAnCK.Services
{
    public class NhaCungCapService
    {
        private KhoHang kho = KhoHang.Instance;
        private FormNhaCungCap view;

        public NhaCungCapService(FormNhaCungCap view)
        {
            this.view = view;
        }

        public void LoadSuppliers()
        {
            view.ClearSupplierGrid();
            foreach (NhaCungCap ncc in kho.ds_ncc)
            {
                view.AddSupplierRow(ncc.IdNcc, ncc.TenNcc, ncc.SdtNcc, ncc.DiaChiNcc);
            }
            view.EnableSupplierGrid(kho.ds_ncc.Count > 0);
        }

        public void AddSupplier(string id, string ten, string sdt, string diaChi)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(ten))
            {
                view.ShowError("ID và tên nhà cung cấp không được để trống!");
                return;
            }

            NhaCungCap ncc = new NhaCungCap(id, ten, sdt, diaChi);
            kho.ds_ncc.Add(ncc);
            kho.LuuDanhSachNCC();
            Logger.LogThemNhaCungCap(kho.CurrentNhanVien, ncc);

            view.AddSupplierRow(id, ten, sdt, diaChi);
            view.ShowMessage("Đã thêm nhà cung cấp thành công!");
            view.ResetForm();
        }

        public void UpdateSupplier(int index, string id, string ten, string sdt, string diaChi)
        {
            if (index < 0 || index >= kho.ds_ncc.Count)
            {
                view.ShowError("Vui lòng chọn một nhà cung cấp để cập nhật!");
                return;
            }

            NhaCungCap oldNCC = new NhaCungCap(kho.ds_ncc[index].IdNcc, kho.ds_ncc[index].TenNcc, kho.ds_ncc[index].SdtNcc, kho.ds_ncc[index].DiaChiNcc);
            NhaCungCap ncc = kho.ds_ncc[index];
            ncc.IdNcc = id;
            ncc.TenNcc = ten;
            ncc.SdtNcc = sdt;
            ncc.DiaChiNcc = diaChi;

            kho.LuuDanhSachNCC();
            Logger.LogSuaThongTinNCC(kho.CurrentNhanVien, oldNCC, ncc);

            view.UpdateSupplierRow(index, id, ten, sdt, diaChi);
            view.ShowMessage("Cập nhật nhà cung cấp thành công!");
            view.ResetForm();
        }

        public void DeleteSupplier(int index)
        {
            if (index < 0 || index >= kho.ds_ncc.Count)
            {
                view.ShowError("Vui lòng chọn một nhà cung cấp để xóa!");
                return;
            }

            NhaCungCap ncc = kho.ds_ncc[index];
            kho.XoaNhaCungCap(ncc.IdNcc);
            kho.ds_ncc.RemoveAt(index);
            kho.LuuDanhSachNCC();
            Logger.LogXoaNhaCungCap(kho.CurrentNhanVien, ncc);

            view.RemoveSupplierRow(index);
            view.ShowMessage("Đã xóa nhà cung cấp thành công!");
            view.ResetForm();
        }

        public void SelectSupplier(int index)
        {
            if (index >= 0 && index < kho.ds_ncc.Count)
            {
                NhaCungCap ncc = kho.ds_ncc[index];
                view.SetSupplierInfo(ncc.IdNcc, ncc.TenNcc, ncc.SdtNcc, ncc.DiaChiNcc);
            }
        }
    }
}