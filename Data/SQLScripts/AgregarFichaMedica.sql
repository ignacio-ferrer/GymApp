CREATE PROCEDURE MedicaaFicha		
	@LesionOsea NVARCHAR(50),
    @LesionMuscular NVARCHAR(50),
    @EnfermedadCardiovascular NVARCHAR(50),
    @Afixia NVARCHAR(50),
	@Asmatico NVARCHAR(50),
    @Diabetico NVARCHAR(50),
    @Epileptico NVARCHAR(50),
    @Fumador NVARCHAR(50),
    @Mareos NVARCHAR(50),
    @Desmayos NVARCHAR(50),
    @Respirar NVARCHAR(50),
    @Nauseas NVARCHAR(50),
    @Anemia NVARCHAR(50),
    @Embarazada NVARCHAR(50)
AS
BEGIN
    INSERT INTO FichaMedica(LesionOsea, LesionMuscular, EnfermedadCardiovascular, Afixia, Asmatico , Diabetico, Epileptico, Fumador, Mareos, Desmayos,Respirar,Nauseas,Anemia,Embarazada)
    VALUES (@LesionOsea, @LesionMuscular, @EnfermedadCardiovascular, @Afixia, @Asmatico,@Diabetico, @Epileptico, @Fumador, @Mareos, @Desmayos, @Respirar, @Nauseas, @Anemia, @Embarazada);
END
