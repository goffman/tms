SELECT     [l-kabinet].ID, [l-kabinet].FIO, [l-kabinet].ID_dolzhnost, [l-kabinet].stazh, [l-kabinet].email, [l-kabinet].kategoria, [l-kabinet].proba_test, [l-kabinet].on_delete, 
                      prohozhdenie_testa.rezultat, prohozhdenie_testa.data, prohozhdenie_testa.status, prohozhdenie_testa.otpravlen, lpu.lpu, dolzhnost.dolzhnost, users.Moderacija, 
                      users.UserName
FROM         [l-kabinet] INNER JOIN
                      dolzhnost ON [l-kabinet].ID_dolzhnost = dolzhnost.ID LEFT OUTER JOIN
                      prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj INNER JOIN
                      lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                      users ON [l-kabinet].ID = users.ID_l_kabinet
WHERE     ([l-kabinet].FIO LIKE N'чебо%')