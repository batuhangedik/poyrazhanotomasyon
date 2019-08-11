-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1
-- Üretim Zamanı: 26 Nis 2019, 05:01:34
-- Sunucu sürümü: 10.1.38-MariaDB
-- PHP Sürümü: 7.3.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `poyrazhan`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `departman`
--

CREATE TABLE `departman` (
  `departman_id` int(10) NOT NULL,
  `departman_ad` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `departman`
--

INSERT INTO `departman` (`departman_id`, `departman_ad`) VALUES
(1, 'Yonetim');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `depoyonetimi`
--

CREATE TABLE `depoyonetimi` (
  `depo_yonetimi_id` int(10) NOT NULL,
  `isim_soyisim` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `maas` int(10) NOT NULL,
  `tc_no` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `cep_no` varchar(11) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `depoyonetimi`
--

INSERT INTO `depoyonetimi` (`depo_yonetimi_id`, `isim_soyisim`, `sifre`, `maas`, `tc_no`, `cep_no`) VALUES
(5, 'deneme', 'test', 0, '', '123123'),
(9, 'depo', '', 0, '', ''),
(10, 'depotest', '123123', 0, '', '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `depo_yonetimi`
--
-- poyrazhan.depo_yonetimi tablosu için yapı okuma hatası: #1932 - Table 'poyrazhan.depo_yonetimi' doesn't exist in engine
-- poyrazhan.depo_yonetimi tablosu için veri okuma hatası: #1064 - You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'FROM `poyrazhan`.`depo_yonetimi`' at line 1

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ekstragider`
--

CREATE TABLE `ekstragider` (
  `gider_id` int(50) NOT NULL,
  `gider_tanim` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `ucret` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `gelirler`
--

CREATE TABLE `gelirler` (
  `satis_id` int(10) NOT NULL,
  `satis_fiyat` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `giderler`
--

CREATE TABLE `giderler` (
  `gider_id` int(10) NOT NULL,
  `aciklama` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL,
  `gider_fiyat` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hammadde`
--

CREATE TABLE `hammadde` (
  `hm_id` int(10) NOT NULL,
  `hm_adı` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `hm_cinsi` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `birim` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `birim_fiyat` varchar(20) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hata_durumu`
--

CREATE TABLE `hata_durumu` (
  `onay_id` int(10) NOT NULL,
  `onay_durumu` varchar(12) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hm_siparisleri`
--

CREATE TABLE `hm_siparisleri` (
  `hm_siparis_id` int(10) NOT NULL,
  `hm_id` int(10) NOT NULL,
  `miktar` int(10) NOT NULL,
  `tedarikci_id` int(10) NOT NULL,
  `siparis_tarihi` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hm_stok`
--

CREATE TABLE `hm_stok` (
  `hm_stok_id` int(10) NOT NULL,
  `hm_id` int(10) NOT NULL,
  `miktari` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hm_talep`
--

CREATE TABLE `hm_talep` (
  `talep_id` int(10) NOT NULL,
  `hm_id` int(10) NOT NULL,
  `miktar` int(10) NOT NULL,
  `tarih` varchar(8) COLLATE utf8_turkish_ci NOT NULL,
  `aciklama` varchar(100) COLLATE utf8_turkish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kalite_kontrol`
--

CREATE TABLE `kalite_kontrol` (
  `kalite_kontrol_id` int(10) NOT NULL,
  `departman_id` int(10) NOT NULL,
  `sifre` varchar(16) COLLATE utf8_turkish_ci NOT NULL,
  `isim_soyisim` varchar(60) COLLATE utf8_turkish_ci NOT NULL,
  `cep_no` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `tc_no` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `maas` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kalite_kontrol`
--

INSERT INTO `kalite_kontrol` (`kalite_kontrol_id`, `departman_id`, `sifre`, `isim_soyisim`, `cep_no`, `tc_no`, `maas`) VALUES
(10, 1, '123', 'batuhan', '123', '132', 123),
(14, 0, '313', '12313', '313', '31313', 3131),
(17, 0, 'camoon', 'deneme123', '', '', 0),
(18, 0, '', '14', '', '', 0),
(19, 0, 'oldu', 'kalitee', '12314', '123123', 0),
(23, 0, 'qwer4', 'kalitetest', '', '', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kontrol_bekleyen_siparisler`
--

CREATE TABLE `kontrol_bekleyen_siparisler` (
  `siparis_id` int(10) NOT NULL,
  `musteri_id` int(10) NOT NULL,
  `urun_adi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `miktari` int(10) NOT NULL,
  `baslangic_tarihi` date NOT NULL,
  `siparis_durum_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanıcı`
--

CREATE TABLE `kullanıcı` (
  `kullanıcı_id` int(10) NOT NULL,
  `departman_id` int(10) NOT NULL,
  `sifre` varchar(16) COLLATE utf8_turkish_ci DEFAULT NULL,
  `isim_soyisim` varchar(60) COLLATE utf8_turkish_ci DEFAULT NULL,
  `cep_no` varchar(11) COLLATE utf8_turkish_ci DEFAULT NULL,
  `baslangic` date DEFAULT NULL,
  `maas` int(6) DEFAULT NULL,
  `tc_no` varchar(11) COLLATE utf8_turkish_ci DEFAULT NULL,
  `adres` varchar(50) COLLATE utf8_turkish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kullanıcı`
--

INSERT INTO `kullanıcı` (`kullanıcı_id`, `departman_id`, `sifre`, `isim_soyisim`, `cep_no`, `baslangic`, `maas`, `tc_no`, `adres`) VALUES
(1, 1, '123', 'batuhan', '5394043044', '2019-04-01', 12000, '123456789', 'İzmir');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteriler`
--

CREATE TABLE `musteriler` (
  `musteri_id` int(10) NOT NULL,
  `firma_adi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `firma_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `firma_adres` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `firma_fax` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `firma_mail` varchar(50) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `musteriler`
--

INSERT INTO `musteriler` (`musteri_id`, `firma_adi`, `firma_tel`, `firma_adres`, `firma_fax`, `firma_mail`) VALUES
(10, 'mavi', '3435639', 'istanbul', '567890', 'iletisim@mavi.com');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satislar`
--

CREATE TABLE `satislar` (
  `satis_id` int(10) NOT NULL,
  `urun_id` int(10) NOT NULL,
  `fiyat` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `siparis_durum`
--

CREATE TABLE `siparis_durum` (
  `siparis_durum_id` int(10) NOT NULL,
  `siparis_durum_yeri` varchar(30) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tamamlanan_siparisler`
--

CREATE TABLE `tamamlanan_siparisler` (
  `siparis_id` int(10) NOT NULL,
  `musteri_id` int(10) NOT NULL,
  `bitis_tarihi` date NOT NULL,
  `onay_id` int(5) NOT NULL,
  `siparis_durum_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `tedarikciler`
--

CREATE TABLE `tedarikciler` (
  `tedarikci_id` int(10) NOT NULL,
  `firma_adi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `firma_adres` varchar(30) COLLATE utf8_turkish_ci DEFAULT NULL,
  `firma_tel` varchar(11) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `uretimdepartmani`
--

CREATE TABLE `uretimdepartmani` (
  `uretim_departman_id` int(10) NOT NULL,
  `isim_soyisim` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `sifre` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `cep_no` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `maas` int(10) NOT NULL,
  `tc_no` varchar(50) COLLATE utf8_turkish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `uretimdepartmani`
--

INSERT INTO `uretimdepartmani` (`uretim_departman_id`, `isim_soyisim`, `sifre`, `cep_no`, `maas`, `tc_no`) VALUES
(1, 'batuhan', '', '', 0, ''),
(4, 'uretim', '', '', 0, ''),
(7, 'uretimtest', '123123', '', 0, '');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `uretim_bekleyen_siparisler`
--

CREATE TABLE `uretim_bekleyen_siparisler` (
  `siparis_id` int(10) NOT NULL,
  `musteri_id` int(10) NOT NULL,
  `urun_adi` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `miktar` int(10) NOT NULL,
  `baslangic_tarihi` date NOT NULL,
  `siparis_durum_id` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

CREATE TABLE `urunler` (
  `urun_id` int(10) NOT NULL,
  `urun_adi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `urun_cinsi` varchar(30) COLLATE utf8_turkish_ci NOT NULL,
  `renk` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `birim` varchar(20) COLLATE utf8_turkish_ci NOT NULL,
  `birim_fiyat` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urun_stok`
--

CREATE TABLE `urun_stok` (
  `urun_stok_id` int(10) NOT NULL,
  `urun_id` int(10) NOT NULL,
  `miktar` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yonetici`
--

CREATE TABLE `yonetici` (
  `yonetici_id` int(10) NOT NULL,
  `kullanıcı_id` int(10) NOT NULL,
  `sifre` varchar(16) COLLATE utf8_turkish_ci NOT NULL,
  `isim_soyisim` varchar(60) COLLATE utf8_turkish_ci NOT NULL,
  `cep_no` varchar(11) COLLATE utf8_turkish_ci NOT NULL,
  `maas` int(6) DEFAULT NULL,
  `tc_no` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `yonetici`
--

INSERT INTO `yonetici` (`yonetici_id`, `kullanıcı_id`, `sifre`, `isim_soyisim`, `cep_no`, `maas`, `tc_no`) VALUES
(13, 0, 'pilavci1234', 'Emre Pilavci', '1234567', 20201, 6574858),
(15, 0, 'Batman', 'Bruce Wayne', '123456', 0, 123),
(16, 0, 'batuhancimaskim', 'Sevval Atalar', '', 80000, 0),
(17, 0, 'qwerty', 'Bilal Koç', '5339098077', 15000, 123456789),
(18, 0, 'test1', 'yöneticitest', '', 0, 0);

--
-- Dökümü yapılmış tablolar için indeksler
--

--
-- Tablo için indeksler `departman`
--
ALTER TABLE `departman`
  ADD PRIMARY KEY (`departman_id`);

--
-- Tablo için indeksler `depoyonetimi`
--
ALTER TABLE `depoyonetimi`
  ADD PRIMARY KEY (`depo_yonetimi_id`);

--
-- Tablo için indeksler `ekstragider`
--
ALTER TABLE `ekstragider`
  ADD PRIMARY KEY (`gider_id`);

--
-- Tablo için indeksler `gelirler`
--
ALTER TABLE `gelirler`
  ADD PRIMARY KEY (`satis_id`);

--
-- Tablo için indeksler `giderler`
--
ALTER TABLE `giderler`
  ADD PRIMARY KEY (`gider_id`);

--
-- Tablo için indeksler `hammadde`
--
ALTER TABLE `hammadde`
  ADD PRIMARY KEY (`hm_id`);

--
-- Tablo için indeksler `hata_durumu`
--
ALTER TABLE `hata_durumu`
  ADD PRIMARY KEY (`onay_id`);

--
-- Tablo için indeksler `hm_siparisleri`
--
ALTER TABLE `hm_siparisleri`
  ADD PRIMARY KEY (`hm_siparis_id`),
  ADD KEY `tedarikci_id` (`tedarikci_id`);

--
-- Tablo için indeksler `hm_stok`
--
ALTER TABLE `hm_stok`
  ADD PRIMARY KEY (`hm_stok_id`),
  ADD KEY `hm_id` (`hm_id`);

--
-- Tablo için indeksler `hm_talep`
--
ALTER TABLE `hm_talep`
  ADD PRIMARY KEY (`talep_id`);

--
-- Tablo için indeksler `kalite_kontrol`
--
ALTER TABLE `kalite_kontrol`
  ADD PRIMARY KEY (`kalite_kontrol_id`);

--
-- Tablo için indeksler `kontrol_bekleyen_siparisler`
--
ALTER TABLE `kontrol_bekleyen_siparisler`
  ADD PRIMARY KEY (`siparis_id`),
  ADD KEY `musteri_id` (`musteri_id`);

--
-- Tablo için indeksler `kullanıcı`
--
ALTER TABLE `kullanıcı`
  ADD PRIMARY KEY (`kullanıcı_id`),
  ADD KEY `departman_id` (`departman_id`);

--
-- Tablo için indeksler `musteriler`
--
ALTER TABLE `musteriler`
  ADD PRIMARY KEY (`musteri_id`);

--
-- Tablo için indeksler `satislar`
--
ALTER TABLE `satislar`
  ADD PRIMARY KEY (`satis_id`),
  ADD KEY `urun_id` (`urun_id`);

--
-- Tablo için indeksler `siparis_durum`
--
ALTER TABLE `siparis_durum`
  ADD PRIMARY KEY (`siparis_durum_id`);

--
-- Tablo için indeksler `tamamlanan_siparisler`
--
ALTER TABLE `tamamlanan_siparisler`
  ADD PRIMARY KEY (`siparis_id`),
  ADD KEY `musteri_id` (`musteri_id`),
  ADD KEY `siparis_durum_id` (`siparis_durum_id`);

--
-- Tablo için indeksler `tedarikciler`
--
ALTER TABLE `tedarikciler`
  ADD PRIMARY KEY (`tedarikci_id`);

--
-- Tablo için indeksler `uretimdepartmani`
--
ALTER TABLE `uretimdepartmani`
  ADD PRIMARY KEY (`uretim_departman_id`);

--
-- Tablo için indeksler `uretim_bekleyen_siparisler`
--
ALTER TABLE `uretim_bekleyen_siparisler`
  ADD PRIMARY KEY (`siparis_id`),
  ADD KEY `musteri_id` (`musteri_id`),
  ADD KEY `siparis_durum_id` (`siparis_durum_id`);

--
-- Tablo için indeksler `urunler`
--
ALTER TABLE `urunler`
  ADD PRIMARY KEY (`urun_id`);

--
-- Tablo için indeksler `urun_stok`
--
ALTER TABLE `urun_stok`
  ADD PRIMARY KEY (`urun_stok_id`),
  ADD KEY `urun_id` (`urun_id`);

--
-- Tablo için indeksler `yonetici`
--
ALTER TABLE `yonetici`
  ADD PRIMARY KEY (`yonetici_id`);

--
-- Dökümü yapılmış tablolar için AUTO_INCREMENT değeri
--

--
-- Tablo için AUTO_INCREMENT değeri `departman`
--
ALTER TABLE `departman`
  MODIFY `departman_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `depoyonetimi`
--
ALTER TABLE `depoyonetimi`
  MODIFY `depo_yonetimi_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- Tablo için AUTO_INCREMENT değeri `kalite_kontrol`
--
ALTER TABLE `kalite_kontrol`
  MODIFY `kalite_kontrol_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Tablo için AUTO_INCREMENT değeri `kullanıcı`
--
ALTER TABLE `kullanıcı`
  MODIFY `kullanıcı_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tablo için AUTO_INCREMENT değeri `musteriler`
--
ALTER TABLE `musteriler`
  MODIFY `musteri_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Tablo için AUTO_INCREMENT değeri `siparis_durum`
--
ALTER TABLE `siparis_durum`
  MODIFY `siparis_durum_id` int(10) NOT NULL AUTO_INCREMENT;

--
-- Tablo için AUTO_INCREMENT değeri `uretimdepartmani`
--
ALTER TABLE `uretimdepartmani`
  MODIFY `uretim_departman_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- Tablo için AUTO_INCREMENT değeri `yonetici`
--
ALTER TABLE `yonetici`
  MODIFY `yonetici_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `hm_siparisleri`
--
ALTER TABLE `hm_siparisleri`
  ADD CONSTRAINT `hm_siparisleri_ibfk_1` FOREIGN KEY (`tedarikci_id`) REFERENCES `tedarikciler` (`tedarikci_id`);

--
-- Tablo kısıtlamaları `hm_stok`
--
ALTER TABLE `hm_stok`
  ADD CONSTRAINT `hm_stok_ibfk_1` FOREIGN KEY (`hm_id`) REFERENCES `hammadde` (`hm_id`);

--
-- Tablo kısıtlamaları `kontrol_bekleyen_siparisler`
--
ALTER TABLE `kontrol_bekleyen_siparisler`
  ADD CONSTRAINT `kontrol_bekleyen_siparisler_ibfk_1` FOREIGN KEY (`musteri_id`) REFERENCES `musteriler` (`musteri_id`);

--
-- Tablo kısıtlamaları `kullanıcı`
--
ALTER TABLE `kullanıcı`
  ADD CONSTRAINT `kullanıcı_ibfk_1` FOREIGN KEY (`departman_id`) REFERENCES `departman` (`departman_id`);

--
-- Tablo kısıtlamaları `satislar`
--
ALTER TABLE `satislar`
  ADD CONSTRAINT `satislar_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`);

--
-- Tablo kısıtlamaları `tamamlanan_siparisler`
--
ALTER TABLE `tamamlanan_siparisler`
  ADD CONSTRAINT `tamamlanan_siparisler_ibfk_1` FOREIGN KEY (`musteri_id`) REFERENCES `musteriler` (`musteri_id`),
  ADD CONSTRAINT `tamamlanan_siparisler_ibfk_2` FOREIGN KEY (`siparis_durum_id`) REFERENCES `siparis_durum` (`siparis_durum_id`);

--
-- Tablo kısıtlamaları `uretim_bekleyen_siparisler`
--
ALTER TABLE `uretim_bekleyen_siparisler`
  ADD CONSTRAINT `uretim_bekleyen_siparisler_ibfk_1` FOREIGN KEY (`musteri_id`) REFERENCES `musteriler` (`musteri_id`),
  ADD CONSTRAINT `uretim_bekleyen_siparisler_ibfk_2` FOREIGN KEY (`siparis_durum_id`) REFERENCES `siparis_durum` (`siparis_durum_id`);

--
-- Tablo kısıtlamaları `urun_stok`
--
ALTER TABLE `urun_stok`
  ADD CONSTRAINT `urun_stok_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
