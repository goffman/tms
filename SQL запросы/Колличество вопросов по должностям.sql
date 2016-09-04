SELECT     dolzhnost.dolzhnost, COUNT(*) AS [Колличество вопросов]
FROM         voprosy INNER JOIN
                      specialnost ON voprosy.specialnost = specialnost.id_specialnost INNER JOIN
                      [dolzhnost-specialnost] ON specialnost.id_specialnost = [dolzhnost-specialnost].specialnost INNER JOIN
                      dolzhnost ON [dolzhnost-specialnost].dolzhnost = dolzhnost.ID
GROUP BY dolzhnost.dolzhnost
ORDER BY [Колличество вопросов]