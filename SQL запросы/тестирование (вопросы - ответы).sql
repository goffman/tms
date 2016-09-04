SELECT        testirovanie.ID_testiruemyj AS Expr1, testirovanie.ID_testiruemyj, testirovanie.ID_vopros, testirovanie.ID_otvet, testirovanie.ID_test, otveti.vernyj
FROM            testirovanie INNER JOIN
                         otveti ON testirovanie.ID_otvet = otveti.id
WHERE        (testirovanie.ID_testiruemyj = 12581)