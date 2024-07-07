DECLARE @nombre NVARCHAR(50);

SELECT 
    Cliente.nombre, 
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
FROM Cliente
INNER JOIN FichaMedica ON Cliente.ClienteId = FichaMedica.ClienteId
WHERE Cliente.nombre = @nombre;
