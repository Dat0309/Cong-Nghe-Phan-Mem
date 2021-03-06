using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager
            .ConnectionStrings[StrName].ConnectionString;

        /// <summary>
        /// Sinh vien
        /// </summary>
        public static string SinhVien_GetAll = "SinhVien_GetAll";
        public static string SinhVien_InsertUpdateDelete = "SinhVien_InsertUpdateDelete";

        /// <summary>
        /// Khoa + Lop
        /// </summary>
        public static string Khoa_GetAll = "Khoa_GetAll";
        public static string Lop_GetAll = "Lop_GetAll";
        /// <summary>
        /// HocPhan procedure
        /// </summary>
        public static string HocPhan_GetAll = "HocPhan_GetAll";
        public static string HocPhan_InsertUpdateDelete = "HocPhan_InsertUpdateDelete";
        public static string GetHPChuaTichLuy = "GetHPChuaTichLuy";
        public static string GetHPTheoKeHoach = "GetHPTheoKeHoach";
        public static string GetHPNgoaiKeHoach = "GetHPNgoaiKeHoach";
        public static string GetKQDK = "GetKQDK";
        public static string GetKQDK_HienTai = "GetKQDK_HienTai";
        public static string GetHocPhanTheoHocKyVaNam = "GetHocPhanTheoHocKyVaNam";

        /// <summary>
        /// TaiKhoan procedure
        /// </summary>
        public static string TaiKhoan_GetAll = "TaiKhoan_GetAll";
        public static string TaiKhoan_InsertUpdateDelete = "TaiKhoan_InsertUpdateDelete";
        public static string UpdatePassword = "UpdatePassword";

        /// <summary>
        /// Quyen procedure
        /// </summary>
        public static string Quyen_GetAll = "Quyen_GetAll";
        public static string Quyen_InsertUpdateDelete = "Quyen_InsertUpdateDelete";

        /// <summary>
        /// CTDK procedure
        /// </summary>
        public static string ChiTietDK_GetAll = "ChiTietDK_GetAll";
        public static string CTDK_InsertUpdateDelete = "CTDK_InsertUpdateDelete";
        public static string UpdateCTDKHP = "UpdateCTDKHP";
        public static string DeleteByKey = "DeleteByKey";
        public static string QLChiTietDKHP = "QLChiTietDKHP";
        public static string QLChiTietHP = "QLChiTietHP";
        public static string GetChiTietTheoHocKyVaNam = "GetChiTietTheoHocKyVaNam";
        public static string CheckSVDangKyHocPhan = "CheckSVDangKyHocPhan";

        /// <summary>
        /// Học phí
        /// </summary>
        public static string HocPhi_GetAll = "HocPhi_GetAll";
        public static string HocPhi_InsertUpdateDelete = "HocPhi_InsertUpdateDelete";
        public static string validationHocPhi = "validationHocPhi";

        /// <summary>
        /// Lịch thi
        /// </summary>
        public static string LichThi_GetAll = "LichThi_GetAll";
        public static string LichThi_InsertUpdatedelete = "LichThi_InsertUpdatedelete";
        public static string LoadLichThi = "LoadLichThi";
        public static string GetLichThiSV = "GetLichThiSV";


    }
}
