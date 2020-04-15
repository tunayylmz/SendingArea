BEGIN --Insert Bireysel
	Insert Into Bireysel 
	(
		Ad_Soyad,
        Cep_Tel,
        TC_No ,
        E_Posta ,
        Dogum_Tarihi_Gun ,
        Dogum_Tarihi_Ay ,
        Dogum_Tarihi_Yil ,
        Cinsiyet
	) 
	Values
    (
        --'Ömür GÜRBÜZ',
        --5057005504,
        --58432169604,
        --'omurgurbuz@gmail.com',
        --18,
        --1,
        --1985,
        --1
        'Tunay Sabri YILMAZ',
        5454906529,
        12345678910,
        'tnyylmz@gmail.com',
        18,
        1,
        1993,
        1
    );
END

BEGIN --Insert Kurumsal
	Insert Into Kurumsal 
	(
		Firma_Adi,
        Vergi_No,
        Vergi_Dairesi,
        Fatura_Adresi,
        Tel,
        Faks,
        Yetkili_E_Posta
	) 
	Values
    (
        'MD Arge Yazılım Hizmetleri A.Ş.',
        6130951118,
        'Sarıyer',
        'Reşitpaşa Mah. Katar Cad. Arı 2 Binası B Blok No:102 Sarıyer İSTANBUL',
        2122766373,
        2122766373,
        'omur.gurbuz@mdarge.com'
    );
END

BEGIN
    Insert Into Musteri
    (
        Bireysel_Kurumsal,
        Bireysel_Kurumsal_Id,
        E_Posta,
        Sifre
    )
    Values
    (
        'Kurumsal',
        1,
        'omur.gurbuz@mdarge.com',
        '12345678'
    )
END

select * from Bireysel

select * from Kurumsal

select * from Musteri