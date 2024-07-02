CREATE PROCEDURE AgregarAlCliente
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
    INSERT INTO Cliente (nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo, telefono, telefonoEmergencia, correo, fechaInscripcion , metodoDePago, valorDeCuota)
    VALUES (@nombre, @apellido, @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion , @metodoDePago, @valorDeCuota);
END
