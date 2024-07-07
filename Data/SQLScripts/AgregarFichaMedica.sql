CREATE PROCEDURE AgregarLaFichaMedica
    @Id int,
	@LesionOsea NVARCHAR(10),
    @LesionMuscular NVARCHAR(10),
    @EnfermedadCardiovascular NVARCHAR(10),
    @Afixia NVARCHAR(10),
	@Asmatico NVARCHAR(10),
    @Diabetico NVARCHAR(10),
    @Epileptico NVARCHAR(10),
    @Fumador NVARCHAR(10),
    @Mareos NVARCHAR(10),
    @Desmayos NVARCHAR(10),
    @Respirar NVARCHAR(10),
    @Nauseas NVARCHAR(10),
    @Anemia NVARCHAR(10),
    @Embarazada NVARCHAR(10)
AS
BEGIN
    INSERT INTO FichaMedica(Id ,LesionOsea, LesionMuscular, EnfermedadCardiovascular, Afixia, Asmatico , Diabetico, Epileptico, Fumador, Mareos, Desmayos,Respirar,Nauseas,Anemia,Embarazada)
    VALUES (@Id,@LesionOsea, @LesionMuscular, @EnfermedadCardiovascular, @Afixia, @Asmatico,@Diabetico, @Epileptico, @Fumador, @Mareos, @Desmayos, @Respirar, @Nauseas, @Anemia, @Embarazada);
END
