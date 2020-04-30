BEGIN --Bireysel Tablosu Oluşturma

    drop table Bireysel

    create table Bireysel (
        Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
        Ad_Soyad varchar(100) NOT NULL,
        Cep_Tel bigint NOT NULL,
        TC_No bigint NOT NULL,
        E_Posta varchar(50)NOT NULL,
        Dogum_Tarihi_Gun int NOT NULL,
        Dogum_Tarihi_Ay int NOT NULL,
        Dogum_Tarihi_Yil int NOT NULL,
        Cinsiyet int NOT NULL
    );

END

BEGIN --Kurumsal Tablosu Oluşturma

    drop table Kurumsal

    create table Kurumsal (
        Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
        Firma_Adi varchar(250) NOT NULL,
        Vergi_No bigint NOT NULL,
        Vergi_Dairesi varchar(50)NOT NULL,
        Fatura_Adresi varchar(250)NOT NULL,
        Tel bigint NOT NULL,
        Faks bigint,
        Yetkili_E_Posta varchar(50)NOT NULL
        
    );


END

BEGIN --Musteri Tablosu Oluşturma

    drop table Musteri

    create table Musteri (
        Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
        Bireysel_Kurumsal varchar(15) NOT NULL,
        Bireysel_Kurumsal_Id bigint NOT NULL,
        E_Posta varchar(50)NOT NULL,
        Sifre varchar(50)NOT NULL
 
    );

END


BEGIN --Login İçin Select Sorgusu
    BEGIN
        DECLARE @Tur varchar(15);
        DECLARE @Tur_Id bigint;

        SELECT 
            @Tur = Bireysel_Kurumsal,
            @Tur_Id = Bireysel_Kurumsal_Id
        FROM
            Musteri
        WHERE
            E_Posta = 'tnyylmz@gmail.com@gmail.com' and
            Sifre = '12345678';


        IF @Tur = 'Bireysel'
        BEGIN
            select * from Bireysel
            where
                Id = @Tur_Id;
        END
        ELSE IF @Tur = 'Kurumsal'
        BEGIN
            select * from Kurumsal
            where
                Id = @Tur_Id;
        END
    END
END

ALTER TABLE Bireysel
DROP COLUMN Cinsiyet;

select * from Musteri

BEGIN --Adres Tablosu Oluşturma

    drop table Adresler

    create table Adresler (
        Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
        MusteriId bigint NOT NULL,
        AdresMetni varchar(250) NOT NULL,
        AdresAdi varchar(50) NOT NULL,
        Lat float NOT NULL,
        Long float NOT NULL
    );

END

BEGIN --MusteriAdres Tablosu Oluşturma

    drop table MusteriAdresler

    create table MusteriAdresler (
        Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
        AdresId bigint NOT NULL,
        MusteriId bigint NOT NULL,

    );

END