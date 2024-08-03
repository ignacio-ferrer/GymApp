USE AppGymDB;
GO

CREATE PROCEDURE RegistrarClienteYFichaMedicas    
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @edad int,
    @dni int,
    @sexo NVARCHAR(10),
    @fechaNacimiento DATETIME,
    @direccion NVARCHAR(50),
    @localidad NVARCHAR(50),
    @codigoPostal int,
    @grupoSanguineo NVARCHAR(10),
    @telefono int,
    @telefonoEmergencia int,
    @correo NVARCHAR(50),
    @fechaInscripcion DATETIME,
    @metodoDePago NVARCHAR(10),
    @valorDeCuota int
AS
BEGIN
    -- Comienza una transacción
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Inserta el nuevo cliente
        INSERT INTO Cliente (nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo, telefono, telefonoEmergencia, correo, fechaInscripcion , metodoDePago, valorDeCuota)
        VALUES (@nombre, @apellido, @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion , @metodoDePago, @valorDeCuota);

        -- Obtén el ID del cliente recién insertado
        DECLARE @ClienteId INT;
        SET @ClienteId = SCOPE_IDENTITY();

        -- Inserta la ficha médica asociada
        INSERT INTO FichaMedica (cliente_id)
        VALUES (@ClienteId);

        -- Si todo va bien, confirma la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si hay un error, deshace la transacción
        ROLLBACK TRANSACTION;
        -- Lanza el error para manejo adicional
        THROW;
    END CATCH
END
