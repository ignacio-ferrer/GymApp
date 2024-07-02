CREATE PROCEDURE EditarAlCliente
    @ClienteId INT,
	@nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @edad INT,
    @dni int,
    @sexo NVARCHAR(10),
    @fechaNacimiento DATETIME,
    @direccion NVARCHAR(100),
    @localidad NVARCHAR(50),
    @codigoPostal int,
    @grupoSanguineo NVARCHAR(10),
    @telefono int,
    @telefonoEmergencia int,
    @correo NVARCHAR(50),
    @fechaInscripcion DATETIME,
    @metodoDePago NVARCHAR(20),
    @valorDeCuota int
AS
BEGIN

	SET @fechaNacimiento = CASE WHEN @fechaNacimiento < '1753-01-01' THEN '1753-01-01' ELSE @fechaNacimiento END;
    SET @fechaInscripcion = CASE WHEN @fechaInscripcion < '1753-01-01' THEN '1753-01-01' ELSE @fechaInscripcion END;

    UPDATE Cliente
    SET 
        nombre = @nombre,
        apellido = @apellido,
        edad = @edad,
        dni = @dni,
        sexo = @sexo,
        fechaNacimiento = @fechaNacimiento,
        direccion = @direccion,
        localidad = @localidad,
        codigoPostal = @codigoPostal,
        grupoSanguineo = @grupoSanguineo,
        telefono = @telefono,
        telefonoEmergencia = @telefonoEmergencia,
        correo = @correo,
        fechaInscripcion = @fechaInscripcion,
        metodoDePago = @metodoDePago,
        valorDeCuota = @valorDeCuota
    WHERE ClienteId = @ClienteId;  
END
