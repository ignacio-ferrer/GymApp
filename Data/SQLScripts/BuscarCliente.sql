DECLARE @nombre NVARCHAR(50);

SELECT     
	FichaMedica.cliente_id,
    FichaMedica.LesionOsea, 
    FichaMedica.LesionMuscular, 
    FichaMedica.EnfermedadCardiovascular, 
    FichaMedica.Afixia, 
    FichaMedica.Asmatico, 
    FichaMedica.Diabetico, 
    FichaMedica.Epileptico, 
    FichaMedica.Fumador, 
    FichaMedica.Mareos, 
    FichaMedica.Desmayos, 
    FichaMedica.Respirar, 
    FichaMedica.Nauseas, 
    FichaMedica.Anemia, 
    FichaMedica.Embarazada
FROM AppGymDB.dbo.Cliente
INNER JOIN AppGymDB.dbo.FichaMedica ON AppGymDB.dbo.Cliente.ClienteId = FichaMedica.cliente_id
WHERE AppGymDB.dbo.Cliente.nombre = @nombre



