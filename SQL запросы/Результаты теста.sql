SELECT     [l-kabinet].ID, [l-kabinet].FIO, dolzhnost.dolzhnost, [l-kabinet].stazh, lpu.lpu, prohozhdenie_testa.data, prohozhdenie_testa.rezultat
FROM         dolzhnost INNER JOIN
                      [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost INNER JOIN
                      lpu ON [l-kabinet].ID_lpu = lpu.ID INNER JOIN
                      prohozhdenie_testa ON dolzhnost.ID = prohozhdenie_testa.ID_dolzhnost AND [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj
WHERE     (prohozhdenie_testa.otpravlen = 0) AND (prohozhdenie_testa.rezultat > 0) AND (prohozhdenie_testa.data IS NOT NULL)