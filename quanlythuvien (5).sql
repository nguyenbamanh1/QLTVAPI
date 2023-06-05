-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th6 05, 2023 lúc 10:22 AM
-- Phiên bản máy phục vụ: 10.4.21-MariaDB
-- Phiên bản PHP: 7.3.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlythuvien`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_docgia`
--

CREATE TABLE `tb_docgia` (
  `madg` char(30) NOT NULL,
  `madk` char(30) NOT NULL,
  `ngaycap` date NOT NULL,
  `hansudung` date NOT NULL,
  `tinhtrang` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_docgia`
--

INSERT INTO `tb_docgia` (`madg`, `madk`, `ngaycap`, `hansudung`, `tinhtrang`) VALUES
('401', '301', '2023-05-22', '2024-05-22', 'HOAT DONG'),
('402', '302', '2023-04-13', '2024-04-13', 'Hoạt Động'),
('403', '303', '2023-04-17', '2024-04-17', 'Hoạt Động'),
('404', '304', '2023-06-05', '2024-06-05', 'Khoa');

--
-- Bẫy `tb_docgia`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_madg` BEFORE INSERT ON `tb_docgia` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(madg AS INT) AS madg FROM tb_docgia order by madg desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.madg = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_khoa`
--

CREATE TABLE `tb_khoa` (
  `makhoa` char(30) NOT NULL,
  `tenkhoa` varchar(50) NOT NULL,
  `DiaChi` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_khoa`
--

INSERT INTO `tb_khoa` (`makhoa`, `tenkhoa`, `DiaChi`) VALUES
('1', 'Công nghệ thông tin', 'Tầng 7 Tòa Polyco'),
('2', 'Oto', 'Tầng 2 Gara oto'),
('3', 'Dược', 'Tầng 6 Tòa Đinh Trọng Duật'),
('4', 'Kế toán', 'Tầng 3 Toà EAUT');

--
-- Bẫy `tb_khoa`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_khoa` BEFORE INSERT ON `tb_khoa` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(makhoa AS INT) AS makhoa FROM tb_khoa order by makhoa desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.makhoa = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_lop`
--

CREATE TABLE `tb_lop` (
  `malop` char(30) NOT NULL,
  `makhoa` char(30) NOT NULL,
  `tenlop` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_lop`
--

INSERT INTO `tb_lop` (`malop`, `makhoa`, `tenlop`) VALUES
('101', '2', 'Oto 3'),
('102', '1', 'Công nghệ thông tin 1'),
('103', '4', 'Kế toán 5'),
('104', '1', 'Công nghệ thông tin 2');

--
-- Bẫy `tb_lop`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_lop` BEFORE INSERT ON `tb_lop` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(malop AS INT) AS malop FROM tb_lop order by malop desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.malop = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_nhaxuatban`
--

CREATE TABLE `tb_nhaxuatban` (
  `manxb` char(30) NOT NULL,
  `tennxb` varchar(100) NOT NULL,
  `diachi` char(100) NOT NULL,
  `sdt` char(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_nhaxuatban`
--

INSERT INTO `tb_nhaxuatban` (`manxb`, `tennxb`, `diachi`, `sdt`) VALUES
('601', 'Kim Đồng', 'Số 55 Quang Trung, Nguyễn Du, Hai Bà Trưng, Hà Nội', '1900571595'),
('602', 'Trẻ', '161B Lý Chính Thắng, Phường Võ Thị Sáu, Quận 3 , TP. Hồ Chí Minh', '0283843729'),
('603', 'Giáo Dục', 'Số 81 Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '0243822080');

--
-- Bẫy `tb_nhaxuatban`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_nxb` BEFORE INSERT ON `tb_nhaxuatban` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(manxb AS INT) AS manxb FROM tb_nhaxuatban order by manxb desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.manxb = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_phieumuontra`
--

CREATE TABLE `tb_phieumuontra` (
  `mamt` char(30) NOT NULL,
  `matt` char(30) NOT NULL,
  `madg` char(30) NOT NULL,
  `matl` char(30) NOT NULL,
  `hinhthuc` varchar(50) NOT NULL,
  `ghichu` varchar(200) NOT NULL,
  `tinhtrang` varchar(200) NOT NULL,
  `gia` float NOT NULL,
  `ngaymuon` date NOT NULL,
  `ngaytra` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_phieumuontra`
--

INSERT INTO `tb_phieumuontra` (`mamt`, `matt`, `madg`, `matl`, `hinhthuc`, `ghichu`, `tinhtrang`, `gia`, `ngaymuon`, `ngaytra`) VALUES
('901', '203', '402', '803', 'mượn về đọc', 'có để lại 1 thẻ sinh viên', 'đang mượn', 0, '2023-05-15', '2023-06-15'),
('902', '202', '404', '801', 'mượn đọc tại chỗ', '', 'đã trả', 0, '2023-06-03', '2023-06-03'),
('903', '204', '401', '803', 'mượn về đọc', '', 'cố ý quá hạn', 0, '2023-04-15', '2023-05-30'),
('904', '203', '403', '802', 'mượn đọc tại chỗ', '', 'làm hỏng sách', 0, '2023-05-01', '2023-05-20');

--
-- Bẫy `tb_phieumuontra`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_phieumuontra` BEFORE INSERT ON `tb_phieumuontra` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(mamt AS INT) AS mamt FROM tb_phieumuontra order by mamt desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.mamt = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_tacgia`
--

CREATE TABLE `tb_tacgia` (
  `matg` char(30) NOT NULL,
  `tentg` varchar(100) NOT NULL,
  `gioitinh` int(11) NOT NULL,
  `quequan` char(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_tacgia`
--

INSERT INTO `tb_tacgia` (`matg`, `tentg`, `gioitinh`, `quequan`) VALUES
('701', 'Lưu Kiếm Thanh', 0, 'Trung Quốc'),
('702', 'Michel Beaud', 0, 'Pháp'),
('703', 'Đại Học Bách Khoa Hà Nội', 0, 'Hà Nội'),
('704', 'Tạp Chí Công Thương', 0, 'Hà Nội');

--
-- Bẫy `tb_tacgia`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_tacgia` BEFORE INSERT ON `tb_tacgia` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(matg AS INT) AS matg FROM tb_tacgia order by matg desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.matg = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_taikhoan`
--

CREATE TABLE `tb_taikhoan` (
  `maTT` char(30) NOT NULL,
  `taikhoan` char(30) NOT NULL,
  `matkhau` char(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_taikhoan`
--

INSERT INTO `tb_taikhoan` (`maTT`, `taikhoan`, `matkhau`) VALUES
('201', 'manhhdc', '12345'),
('204', 'minhquan206', '12345'),
('203', 'manhhdc2', '12345'),
('202', 'minhquan123', '12345');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_tailieu`
--

CREATE TABLE `tb_tailieu` (
  `matl` char(30) NOT NULL,
  `tentl` varchar(100) NOT NULL,
  `matheloai` char(30) NOT NULL,
  `matg` char(30) NOT NULL,
  `manxb` char(30) NOT NULL,
  `namxb` char(30) NOT NULL,
  `giabia` float NOT NULL,
  `soluong` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_tailieu`
--

INSERT INTO `tb_tailieu` (`matl`, `tentl`, `matheloai`, `matg`, `manxb`, `namxb`, `giabia`, `soluong`) VALUES
('801', 'Lịch sử các học thuyết chính trị trên thế giới', '501', '701', '603', '2001', 235000, 124),
('802', 'Lịch sử chủ nghĩa tư bản từ 1500 đến 2000', '502', '702', '601', '2002', 215000, 98),
('803', 'Bài giảng điều khiển số - Phần 1', '503', '703', '603', '', 86000, 60),
('804', 'Các kết quả nghiên cứu khoa học và ứng dụng công nghệ', '505', '704', '602', '', 95000, 73);

--
-- Bẫy `tb_tailieu`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_tailieu` BEFORE INSERT ON `tb_tailieu` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(matl AS INT) AS matl FROM tb_tailieu order by matl desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.matl = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_thedangky`
--

CREATE TABLE `tb_thedangky` (
  `madk` char(30) NOT NULL,
  `malop` char(30) NOT NULL,
  `hoten` varchar(100) NOT NULL,
  `namsinh` text NOT NULL,
  `gioitinh` int(2) NOT NULL,
  `chucdanh` varchar(50) NOT NULL,
  `khoahoc` char(30) NOT NULL,
  `sdt` char(10) NOT NULL,
  `email` char(100) NOT NULL,
  `loaidk` varchar(50) NOT NULL,
  `ngaydk` date NOT NULL,
  `lephi` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_thedangky`
--

INSERT INTO `tb_thedangky` (`madk`, `malop`, `hoten`, `namsinh`, `gioitinh`, `chucdanh`, `khoahoc`, `sdt`, `email`, `loaidk`, `ngaydk`, `lephi`) VALUES
('301', '102', 'Nguyễn Hữu Hoàng', '2000-04-09', 0, 'Sinh Viên', 'Khóa 9', '0338959595', '', 'Thẻ Sinh Viên', '2023-05-20', 50000),
('302', 'null', 'Lê Thị Quỳnh', '1990-01-15', 1, 'Giáo Viên', '', '0966789555', 'quynhle555@eaut.edu.vn', 'Thẻ Giáo Viên', '2023-04-11', 50000),
('303', 'null', 'Phạm Văn Đồng', '1980-03-05', 1, 'Giáo Viên', '', '0958888999', 'dongpham@eaut.edu.vn', 'Thẻ Giáo Viên', '2023-04-15', 50000),
('304', '104', 'Trương Văn An', '2002-10-25', 0, 'Sinh Viên', 'Khóa 11', '0964745444', 'vanan@eaut.edu.vn', 'Thẻ Sinh Viên', '2023-06-03', 50000),
('305', '104', 'Mai Van Linh', '2002', 0, 'Giáo Viên', '2020', '0123456789', 'manh@mail.com', 'The Giao Vien', '2020-01-23', 50000);

--
-- Bẫy `tb_thedangky`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_thedangky` BEFORE INSERT ON `tb_thedangky` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(madk AS INT) AS madk FROM tb_thedangky order by madk desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.madk = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_theloai`
--

CREATE TABLE `tb_theloai` (
  `matheloai` char(30) NOT NULL,
  `tentheloai` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_theloai`
--

INSERT INTO `tb_theloai` (`matheloai`, `tentheloai`) VALUES
('501', 'Sách Giáo Trình'),
('502', 'Sách Tham Khảo'),
('503', 'Đề Cương'),
('504', 'Luận Văn'),
('505', 'Tạp Chí');

--
-- Bẫy `tb_theloai`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_matheloai` BEFORE INSERT ON `tb_theloai` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(matheloai AS INT) AS matheloai FROM tb_theloai order by matheloai desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.matheloai = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_thuthu`
--

CREATE TABLE `tb_thuthu` (
  `matt` char(30) NOT NULL,
  `tentt` varchar(100) NOT NULL,
  `gioitinh` int(11) NOT NULL,
  `sdt` char(10) NOT NULL,
  `diachi` char(100) NOT NULL,
  `email` char(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_thuthu`
--

INSERT INTO `tb_thuthu` (`matt`, `tentt`, `gioitinh`, `sdt`, `diachi`, `email`) VALUES
('201', 'Nguyễn Tiến Nam', 0, '0966111666', 'Nam Từ Liêm - Hà Nội', 'tiennam@gmail.com'),
('202', 'Phạm Thùy Duyên', 1, '0388654455', 'Bắc Từ Liêm - Hà Nội', 'duyenpham111@gmail.com'),
('203', 'Hoàng Thùy Uyên', 1, '0933012321', 'Thanh Xuân - Hà Nội', 'thuyuyen1223@gmail.com'),
('204', 'Trương Văn Đa', 0, '0999666888', 'Đống Đa - Hà Nội', 'davan999@gmail.com');

--
-- Bẫy `tb_thuthu`
--
DELIMITER $$
CREATE TRIGGER `trg_generate_thuthu` BEFORE INSERT ON `tb_thuthu` FOR EACH ROW BEGIN
    DECLARE new_id INT;

    -- Lấy giá trị mới của cột số nguyên tự động tăng
    SET new_id = (SELECT CAST(matt AS INT) AS matt FROM tb_thuthu order by matt desc limit 1) + 1;

    -- Tạo giá trị mới cho cột CHAR
    SET NEW.matt = new_id;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `tb_xulyvipham`
--

CREATE TABLE `tb_xulyvipham` (
  `mamt` char(30) NOT NULL,
  `hinhthucxl` varchar(100) NOT NULL,
  `ngayxl` date NOT NULL,
  `ngaymothe` date NOT NULL,
  `tienphat` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Đang đổ dữ liệu cho bảng `tb_xulyvipham`
--

INSERT INTO `tb_xulyvipham` (`mamt`, `hinhthucxl`, `ngayxl`, `ngaymothe`, `tienphat`) VALUES
('904', 'Khóa Thẻ', '2023-05-25', '2023-07-30', 0),
('903', 'Khóa Thẻ và Phạt Tiền', '2023-05-10', '2023-07-15', 86000);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `tb_docgia`
--
ALTER TABLE `tb_docgia`
  ADD PRIMARY KEY (`madg`),
  ADD KEY `fk_madk` (`madk`);

--
-- Chỉ mục cho bảng `tb_khoa`
--
ALTER TABLE `tb_khoa`
  ADD PRIMARY KEY (`makhoa`);

--
-- Chỉ mục cho bảng `tb_lop`
--
ALTER TABLE `tb_lop`
  ADD PRIMARY KEY (`malop`),
  ADD KEY `fk_mak` (`makhoa`);

--
-- Chỉ mục cho bảng `tb_nhaxuatban`
--
ALTER TABLE `tb_nhaxuatban`
  ADD PRIMARY KEY (`manxb`);

--
-- Chỉ mục cho bảng `tb_phieumuontra`
--
ALTER TABLE `tb_phieumuontra`
  ADD PRIMARY KEY (`mamt`),
  ADD KEY `fk_mattmt` (`matt`),
  ADD KEY `fk_madg` (`madg`),
  ADD KEY `fk_matl` (`matl`);

--
-- Chỉ mục cho bảng `tb_tacgia`
--
ALTER TABLE `tb_tacgia`
  ADD PRIMARY KEY (`matg`);

--
-- Chỉ mục cho bảng `tb_taikhoan`
--
ALTER TABLE `tb_taikhoan`
  ADD KEY `fk_tk` (`maTT`);

--
-- Chỉ mục cho bảng `tb_tailieu`
--
ALTER TABLE `tb_tailieu`
  ADD PRIMARY KEY (`matl`),
  ADD KEY `fk_matheloai` (`matheloai`),
  ADD KEY `fk_matg` (`matg`),
  ADD KEY `fk_manxb` (`manxb`);

--
-- Chỉ mục cho bảng `tb_thedangky`
--
ALTER TABLE `tb_thedangky`
  ADD PRIMARY KEY (`madk`),
  ADD KEY `fk_malop` (`malop`);

--
-- Chỉ mục cho bảng `tb_theloai`
--
ALTER TABLE `tb_theloai`
  ADD PRIMARY KEY (`matheloai`);

--
-- Chỉ mục cho bảng `tb_thuthu`
--
ALTER TABLE `tb_thuthu`
  ADD PRIMARY KEY (`matt`);

--
-- Chỉ mục cho bảng `tb_xulyvipham`
--
ALTER TABLE `tb_xulyvipham`
  ADD KEY `fk_mamt` (`mamt`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `tb_docgia`
--
ALTER TABLE `tb_docgia`
  ADD CONSTRAINT `fk_madk` FOREIGN KEY (`madk`) REFERENCES `tb_thedangky` (`madk`);

--
-- Các ràng buộc cho bảng `tb_lop`
--
ALTER TABLE `tb_lop`
  ADD CONSTRAINT `fk_mak` FOREIGN KEY (`makhoa`) REFERENCES `tb_khoa` (`makhoa`);

--
-- Các ràng buộc cho bảng `tb_phieumuontra`
--
ALTER TABLE `tb_phieumuontra`
  ADD CONSTRAINT `fk_madg` FOREIGN KEY (`madg`) REFERENCES `tb_docgia` (`madg`),
  ADD CONSTRAINT `fk_matl` FOREIGN KEY (`matl`) REFERENCES `tb_tailieu` (`matl`),
  ADD CONSTRAINT `fk_mattmt` FOREIGN KEY (`matt`) REFERENCES `tb_thuthu` (`matt`);

--
-- Các ràng buộc cho bảng `tb_taikhoan`
--
ALTER TABLE `tb_taikhoan`
  ADD CONSTRAINT `fk_tk` FOREIGN KEY (`maTT`) REFERENCES `tb_thuthu` (`matt`);

--
-- Các ràng buộc cho bảng `tb_tailieu`
--
ALTER TABLE `tb_tailieu`
  ADD CONSTRAINT `fk_manxb` FOREIGN KEY (`manxb`) REFERENCES `tb_nhaxuatban` (`manxb`),
  ADD CONSTRAINT `fk_matg` FOREIGN KEY (`matg`) REFERENCES `tb_tacgia` (`matg`),
  ADD CONSTRAINT `fk_matheloai` FOREIGN KEY (`matheloai`) REFERENCES `tb_theloai` (`matheloai`);

--
-- Các ràng buộc cho bảng `tb_xulyvipham`
--
ALTER TABLE `tb_xulyvipham`
  ADD CONSTRAINT `fk_mamt` FOREIGN KEY (`mamt`) REFERENCES `tb_phieumuontra` (`mamt`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
