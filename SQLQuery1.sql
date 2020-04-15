
/* 
    MÜŞTERİ TABLOSU
*/
drop table Musteri_Kayit

create table Musteri_Kayit (
 Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
 Ad_Soyad varchar(100) NOT NULL,
 Cep_Tel bigint NOT NULL,
 TC_No bigint NOT NULL,
 E_Posta varchar(50)NOT NULL,
 sifre varchar(20)NOT NULL,
);

select * from Musteri_Kayit


insert into Musteri_Kayit(Ad_Soyad,Cep_Tel,TC_No,E_Posta,sifre)values('tunay',0,121,'tunaysabriyilmaz@gmail.com','232')


/* 
    FİRMA TABLOSU
*/
drop table Firma_Kayit

create table Firma_Kayit (
 Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
 Sirket_Adi varchar(250) NOT NULL,
 Yetkili_AdSoyad varchar(250) NOT NULL,
 Telefon_No bigint NOT NULL,
 Firma_Mail varchar(250) NOT NULL,
 Fatura_Adresi varchar(250) NOT NULL,
 Vergi_No bigint NOT NULL,
 Vergi_Dairesi varchar(250)NOT NULL,
 sifre varchar(20)NOT NULL,
 Firma newid()
);


select * from Musteri_Kayit

insert into musteri_kayit 
(
 Ad_Soyad,
 Cep_Tel,
 TC_No,
 E_Posta,
 sifre 
) values
(
 'ali veli',
 5455906526,
 12345678912,
 'a@a.com',
 '123'
)



/* 
    MOTOKURYE TABLOSU
*/
drop table Kurye_Kayit

create table Kurye_Kayit (
 Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
 Firma_Kayit_Id bigint NOT NULL,
 Ad_Soyad varchar(100) NOT NULL,
 Cep_Tel bigint NOT NULL,
 TC_No bigint NOT NULL,
 E_Posta varchar(50)NOT NULL,
 Motor_Plaka varchar(10) NOT NULL,
 Motor_Marka varchar(50)NOT NULL,
 Motor_Model varchar(50)NOT NULL,
 Motor_Model_Yili bigint NOT NULL,
 Motor_Tasima_Hacim bigint NOT NULL,
 Motor_Tasima_Agirlik bigint NOT NULL
);

select * from Kurye_Kayit


/* 
    SİPARİŞ TABLOSU
*/
drop table Kurye_Kayit

create table Kurye_Kayit (
 Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
 Firma_Kayit_Id bigint NOT NULL,
 Ad_Soyad varchar(100) NOT NULL,
 Cep_Tel bigint NOT NULL,
 TC_No bigint NOT NULL,
 E_Posta varchar(50)NOT NULL,
 Motor_Plaka varchar(10) NOT NULL,
 Motor_Marka varchar(50)NOT NULL,
 Motor_Model varchar(50)NOT NULL,
 Motor_Model_Yili bigint NOT NULL,
 Motor_Tasima_Hacim bigint NOT NULL,
 Motor_Tasima_Agirlik bigint NOT NULL
);

select * from Kurye_Kayit


/*
    Deneme Tablosu
*/


create table deneme (
 Id bigint IDENTITY(1,1) PRIMARY KEY NOT NULL,
 Firma varchar(16) newid
);

select newid from firma_kayit

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


--CREATE FUNCTION UserLogin(@e_posta varchar(50), @sifre varchar(50))  
--RETURNS table   
--AS   
---- Returns the stock level for the product.  
--RETURN   
--(  
--    DECLARE @Tur varchar(15);
--    DECLARE @Tur_Id bigint;

--    SELECT 
--        @Tur = Bireysel_Kurumsal,
--        @Tur_Id = Bireysel_Kurumsal_Id
--    FROM
--        Musteri
--    WHERE
--        E_Posta = @e_posta and
--        Sifre = @sifre;


--    IF @Tur = 'Bireysel'
--    BEGIN
--        select * from Bireysel
--        where
--            Id = @Tur_Id;
--    END
--    ELSE IF @Tur = 'Kurumsal'
--    BEGIN
--        select * from Kurumsal
--        where
--            Id = @Tur_Id;
--    END
--);  

CREATE FUNCTION FindUserType(@e_posta varchar(50), @sifre varchar(50))  
RETURNS table   
AS   
-- Returns the stock level for the product.  
RETURN   
(  
    SELECT 
        Bireysel_Kurumsal,
        Bireysel_Kurumsal_Id
    FROM
        Musteri
    WHERE
        E_Posta = @e_posta and
        Sifre = @sifre
); 

